
namespace ObjectHandler.Microservice.Data
{
    public interface IFTPObjectDAL
    {
        Guid DeleteObject(string guidString);
        IResult DownloadObject(string guidString);
        string[] UploadObject(HttpRequest request);
    }
}