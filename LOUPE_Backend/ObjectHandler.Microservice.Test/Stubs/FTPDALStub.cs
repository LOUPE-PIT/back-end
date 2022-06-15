using Microsoft.AspNetCore.Http;
using ObjectHandler.Microservice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectHandler.Microservice.Test.Stubs
{
    internal class FTPDALStub : IFTPObjectDAL
    {
        // mock data layer to guarantee succesful tests
        public bool? testValue {  get; set; }   
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

        public string[] UploadObject(HttpRequest request)
        {
            if (testValue == true)
            {
                string[] data = { Guid.NewGuid().ToString(), "test" };
                return data;
            }
            else
            {
                string[] data = { Guid.NewGuid().ToString(), "test" };
                return data;
            }
        }
    }
}
