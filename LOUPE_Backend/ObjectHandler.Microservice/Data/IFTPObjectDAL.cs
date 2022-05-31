
namespace ObjectHandler.Microservice.Data
{
    public interface IFTPObjectDAL
    {
        Guid DeleteObject(string guidString);
        IResult DownloadObject(string guidString);
        Guid UploadObject(HttpRequest request);
    }
}