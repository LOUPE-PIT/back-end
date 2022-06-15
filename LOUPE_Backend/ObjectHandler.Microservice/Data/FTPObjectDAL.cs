namespace ObjectHandler.Microservice.Data
{
    public class FTPObjectDAL : IFTPObjectDAL
    {
        private readonly FluentFTP.FtpClient client;

        public FTPObjectDAL()
        {
            var builder = WebApplication.CreateBuilder();
            client = new FluentFTP.FtpClient(builder.Configuration["FTP:IpAddress"], builder.Configuration["FTP:User"], builder.Configuration["FTP:Password"]);
        }

        public string[] UploadObject(HttpRequest request)
        {
            // We use Guid because they can be easily generated and be controlled.
            Guid id = Guid.NewGuid();
            // Get all files from the request
            var files = request.Form.Files;
            var description = request.Form["description"].ToString();
            // For each file, start the upload process
            foreach (var file in files)
            {
                // Get the file extension
                var extension = new FileInfo(file.FileName).Extension;

                // Connect to my FTP server
                client.AutoConnect();

                // Turn the file into a byte[]
                var ms = new MemoryStream();
                file.CopyTo(ms);
                ms.Close();
                var array = ms.ToArray();

                // Upload the file to FTP
                var x = client.Upload(array, id.ToString() + ".zip");

                Console.WriteLine(client.GetWorkingDirectory());

                // Disconnect the client
                client.Disconnect();


                Console.WriteLine(id);
            }
            string[] data = { id.ToString(), description };
            return data;
        }

        public IResult DownloadObject(string guidString)
        {
            Guid id = Guid.Parse(guidString);
            // Connect to FTP server
            client.AutoConnect();

            // Creating a new memory stream to save the file to
            var ms = new MemoryStream();

            // Download the file to the memory stream
            client.Download(ms, id.ToString() + ".zip");

            // Turn the memory stream into a byte[]
            var array = ms.ToArray();

            // Close the memory stream
            ms.Close();

            // Close the FTP connection
            client.Disconnect();

            // Return the file to the user
            return Results.File(array, contentType: "application/zip");
        }

        public Guid DeleteObject(string guidString)
        {
            Guid id = Guid.Parse(guidString);
            client.AutoConnect();

            client.DeleteFile(id.ToString() + ".zip");

            client.Disconnect();

            return id;
        }
    }
}
