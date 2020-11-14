using JPSAGE_ERP.Application.Helpers;
using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Application.Models.Account;
using JPSAGE_ERP.Application.Services;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    /// <summary>
    /// This controller is in charge of the authentication and authorization in the application
    /// </summary>
    [Route("api/v1/users")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IRepository<TblCountry> _countryRepository;
        private readonly IRepository<TblCity> _cityRepository;
        private readonly IRepository<TblState> _stateRepository;
        private readonly IRepository<TblStaffBioData> _staffRepository;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            IRepository<TblCountry> countryRepository,
            IRepository<TblCity> cityRepository,
            IRepository<TblState> stateRepository,
            IRepository<TblStaffBioData> staffRepository,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _stateRepository = stateRepository;
            _staffRepository = staffRepository;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Registers a User
        /// </summary>
        /// /// <remarks>
        /// Rest-api-key : "ebfb7ff0-b2f6-41c8-bef3-4fba17be410c"
        /// Return Format: 
        /// POST/api/v1/users/Register
        /// ()
        /// { 
        ///     username = "",
        ///     email = "", 
        ///     status = 1, 
        ///     message = "Registration Successful" 
        /// } 
        /// </remarks>
        /// <response code="200"> Returns registered username and email with a success message</response>
        /// <response code="400">Returns all error description</response>
        /// <param name="RegData"></param>
        /// <returns></returns>
        //[Authorize("RequireAdministratorRole")]
        //[ApiKeyAuth]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize("RequireAdministratorRole")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            //[FromHeader(Name = "REST-api-key"), Required] string apiKey, 
            [FromBody] RegisterViewModel RegData)
        {
            // Will hold all errors related to registration 
            List<string> errorList = new List<string>();

            // server side validation for User object
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = RegData.Email,
                    UserName = RegData.Email,
                    FirstName = RegData.FirstName,
                    LastName = RegData.LastName,
                    PhoneNumber = RegData.PhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                // create identity user in the database 
                var result = await _userManager.CreateAsync(user, RegData.Password);


                // tasks to do if user was created successfully
                if (result.Succeeded)
                {
                    // adding default identity user role to created user
                    await _userManager.AddToRoleAsync(user, "Staff");

                    // create Staff bio data
                    var newStaff = new TblStaffBioData
                    {
                        AspnetUserId = user.Id,
                        StaffNumber = RegData.StaffNumber,
                        OfficeEmailAddress = RegData.Email,
                        FirstName = RegData.FirstName,
                        LastName = RegData.LastName,
                        OfficePhoneNumber = RegData.PhoneNumber,

                    };

                    await _staffRepository.CreateAsync(newStaff);


                    // Sending Confirmation Email

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserId = user.Id, Code = code }, protocol: HttpContext.Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "JPSAGE.com - Confirm Your Email", "Please confirm your e-mail by clicking this link: <a href=\"" + callbackUrl + "\">click here</a>");

                    // return success message
                    return Ok(new { username = user.UserName, email = user.Email, status = 1, message = "Registration Successful. Staff created successfully" });
                }
                // tasks to do if user was not created successfully
                else
                {
                    // looping throught process errors and adding them to error list object
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        errorList.Add(error.Description);
                    }
                }
            }

            // return bad request response if process fails
            return BadRequest(new JsonResult(errorList));
        }

        /// <summary>
        /// Returns a User token containing authentication details and user properties 
        /// </summary>
        /// <remarks>
        /// Rest-api-key : "ebfb7ff0-b2f6-41c8-bef3-4fba17be410c"
        /// POST/api/v1/users/register
        /// (Response)
        /// {
        ///     "token": "",
        ///     "expiration": "2020-10-10T17:32:37Z",
        ///     "username": "example@example.com",        
        ///      userRoles = [],
        ///      phoneNumber = "",
        ///      firstName = "",
        ///      lastName = "",
        ///      otherName = "",
        ///      dateOfBirth = "",
        ///      emailAddress = "",
        ///      emailConfirmed = 
        ///      addressLine1 = "",
        ///      addressLine2 = "",
        ///      country = "",
        ///      city = "",
        ///      state = "",
        /// }
        /// </remarks>
        /// <param name="LoginData"></param>
        /// <returns></returns>
        //[ApiKeyAuth]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel LoginData)
        {
            if (ModelState.IsValid)
            {
                // Get the User from The database
                var user = await _userManager.FindByNameAsync(LoginData.Email);

                //var roles = await _userManager.GetRolesAsync(user);

                var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Secret"]));

                var tokenExpiryTime = Convert.ToDouble(Configuration["ExpireTime"]);

                if (user != null && await _userManager.CheckPasswordAsync(user, LoginData.Password))
                {

                    // Then Check If Email Is confirmed
                    //if (!await _userManager.IsEmailConfirmedAsync(user))
                    //{
                    //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    //    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserId = user.Id, Code = code }, protocol: HttpContext.Request.Scheme);

                    //    await _emailSender.SendEmailAsync(user.Email, "JPSAGE.com - Confirm Your Email", "Please confirm your e-mail by clicking this link: <a href=\"" + callbackUrl + "\">click here</a>");


                    //    ModelState.AddModelError(string.Empty, "User Has not Confirmed Email.");

                    //    return Unauthorized(new { LoginError = "We sent you an Confirmation Email. Please Confirm Your Registration With JPSAGE.com To Log in." });
                    //}

                    // get user Role
                    var roles = await _userManager.GetRolesAsync(user);

                    // Generate Token
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                       new Claim(JwtRegisteredClaimNames.Sub, LoginData.Email),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                       new Claim(ClaimTypes.NameIdentifier, user.Id),
                       //new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                       new Claim("LoggedOn", DateTime.Now.ToString()),
                        }),
                        SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature),
                        Issuer = Configuration["Site"],
                        Audience = Configuration["Audience"],
                        Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                    };
                    tokenDescriptor.Subject.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                    //Generate Token
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    var userCity = "";
                    var userState = "";
                    var userCountry = "";

                    if (user.CountryId != 0)
                    {
                        var tblCountry = await _countryRepository.FirstOrDefaultAsync(x => x.CountryId == user.CountryId);
                        userCountry = tblCountry.CountryName;
                    }

                    if (user.StateId != 0)
                    {
                        var tblState = await _stateRepository.FirstOrDefaultAsync(x => x.StateId == user.StateId);
                        userState = tblState.StateName;
                    }


                    if (user.CityId != 0 && user.CityId != null)
                    {
                        var tblCity = await _cityRepository.FirstOrDefaultAsync(x => x.CityId == user.CityId);
                        userCity = tblCity.CityName;
                    }

                    return Ok(
                        new
                        {
                            token = tokenHandler.WriteToken(token),
                            expiration = token.ValidTo,
                            username = user.UserName,
                            userRoles = roles,
                            phoneNumber = user.PhoneNumber,
                            firstName = user.FirstName,
                            lastName = user.LastName,
                            otherName = user.OtherName,
                            dateOfBirth = user.DateOfBirth,
                            emailAddress = user.Email,
                            emailConfirmed = user.EmailConfirmed,
                            addressLine1 = user.AddressLine1,
                            addressLine2 = user.AddressLine2,
                            country = userCountry,
                            city = userCity,
                            state = userState,
                            profilePicture = user.ProfilePicture,
                            rating = user.Rating,
                            review = user.Review,
                            createDate = user.CreateDate

                        });
                }
            }
            // return Error
            ModelState.AddModelError("", "UserName/Password was not found sorry");
            return Unauthorized(new { LoginError = "Please Check the Login Credentials - Invalid Username/Password was Entered" });
        }

        /// <summary>
        /// Confirms a User's Email
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);

            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new JsonResult("ERROR");
            }

            if (user.EmailConfirmed)
            {
                return Ok(new { message = "User email confirmed sucessfully. Please sign in to the application." });
                //return Redirect("/login");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {

                return RedirectToAction("EmailConfirmed", "Notifications", new { userId, code });

            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.ToString());
                }
                return new JsonResult(errors);
            }
        }

        /// <summary>
        /// This api is responsible for sending password reset emails to users of the application
        /// </summary>
        /// <remarks>
        /// Rest-api Key : "ebfb7ff0-b2f6-41c8-bef3-4fba17be410c"
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        //[ApiKeyAuth]
        [HttpPost("restorepassword")]
        //[ValidateAntiForgeryToken]
        //[Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(
            //[FromHeader(Name = "REST-api-key"), Required] string apiKey,
            [FromBody] ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                // If user has to activate his email to confirm his account, the use code listing below
                //if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                //{
                //    return Ok();
                //}
                if (user == null)
                {
                    return Ok(new { message = "Please check your email to reset your password." });
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);

                //var message = new Message(new string[] { "codemazetest@gmail.com" }, "Reset password token", callback);
                //await _emailSender.SendEmailAsync(message);

                await _emailSender.SendEmailAsync(user.Email, "JPSAGE.com - Reset password token", "Please reset your Password by clicking this link: <a href=\"" + callback + "\">click here</a>");
                return Ok(new { message = "Please check your email to reset your password." });
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(ModelState);
        }

        /// <summary>
        /// This receives the reset password token and email of the user
        /// </summary>
        /// <remarks>
        /// Rest-api Key : ebfb7ff0-b2f6-41c8-bef3-4fba17be410c
        /// </remarks>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        //[ApiKeyAuth]
        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult ResetPassword(
            //[FromHeader(Name = "REST-api-key"), Required] string apiKey, 
            string token, string email)
        {
            //var model = new ResetPasswordViewModel { Token = token, Email = email };
            return Ok(new { Token = token, Email = email });
        }

        /// <summary>
        /// This resets the password of the user
        /// </summary>
        /// <param name="resetPasswordModel"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "User Id and token are required");
                return BadRequest(ModelState);
            }
            //return View(resetPasswordModel);

            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);

            // Don't reveal that the user does not exist
            if (user == null)
                return Ok(new { message = "Password was reset successfully. Please sign in to the application." });

            //RedirectToAction(nameof(ResetPasswordConfirmation));

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest();
            }

            return Ok(new { message = "Password was reset successfully. Please sign in to the application." });
        }
    }
}
