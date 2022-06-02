using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectHandler.Microservice.Test.Stubs
{
    internal class FTPDALStub
    {
        public bool? testValue = null;
        public Guid DeleteObject(string guidString)
        {
            if (testValue == true)
            {
                return new Guid();
            }
            else
            {
                return new Guid();  
            }
        }

        public IResult DownloadObject(string guidString)
        {
            if (testValue == true)
            {
                return Results.File("");
            }
            else
            {
                return null; 
            }
        }

        public Guid UploadObject(HttpRequest request)
        {
            if (testValue == true)
            {
                return new Guid();
            }
            else
            {
                return new Guid();
            }
        }
    }
}
