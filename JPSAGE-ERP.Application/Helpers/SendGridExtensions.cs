using System;
using System.Collections.Generic;
using System.Text;

namespace JPSAGE_ERP.Application.Helpers
{
    public static class SendGridExtensions
    {
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            return services;
        }
    }
}
