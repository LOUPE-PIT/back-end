using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Authentication.Microservice.Data;
using Authentication.Microservice.Model;
using System;

namespace AuthenticationService.Microservice.Test.Stubs
{
    internal class AuthenticationDALStub : IAuthenticationDAL
    {
        public bool? testValue = null;

        public ActionResult AddUser(UserModel user)
        {
            if (testValue == true)
            {
                return new OkResult();
            }
            else
            {
                return new NotFoundResult();
            }
        }

        public List<UserModel> GetUsers()
        {
            if (testValue == true)
            {
                return new List<UserModel>();
            }
            else
            {
                return null;
            }

        }

        public UserModel UpdateUser(UserModel user)
        {
            if (testValue == true)
            {
                return new UserModel();
            }
            else
            {
                return null;
            }
        }

        public UserModel GetUserById(Guid id)
        {
            return new UserModel();
        }

        public ActionResult DeleteUserById(Guid id)
        {
            if (testValue == true)
            {
                return new OkResult();
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}