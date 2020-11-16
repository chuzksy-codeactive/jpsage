using JPSAGE_ERP.Application.Models.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Services
{
    public class UploadFileToBlob : IUploadFileToBlob
    {
        public UploadFileToBlob(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public async Task<FileUploadResult> UploadFile(string containerName, byte[] contentFile, string extension, string contentType, string contentFileName)
        {
            var account = CloudStorageAccount.Parse(Configuration["AzureBlobConnectionString"]);
            var client = account.CreateCloudBlobClient();

            var container = client.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();

            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            var fileName = $"{contentFileName}-{Guid.NewGuid()}{extension}";
            fileName = fileName.Replace(" ", "-");

            var blob = container.GetBlockBlobReference(fileName);
            await blob.UploadFromByteArrayAsync(contentFile, 0, contentFile.Length);

            blob.Properties.ContentType = contentType;
            await blob.SetPropertiesAsync();

            return new FileUploadResult
            {
                FileName = fileName,
                Url = blob.Uri.ToString()
            };
        }
    }
}
