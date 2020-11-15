using JPSAGE_ERP.Application.Models.Responses;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Services
{
    public interface IUploadFileToBlob
    {
        Task<FileUploadResult> UploadFile(
            string containerName,
            byte[] contentFile,
            string extension,
            string contentType,
            string contentFileName);
    }
}
