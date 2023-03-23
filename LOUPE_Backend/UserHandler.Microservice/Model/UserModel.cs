﻿using System.ComponentModel.DataAnnotations;

namespace Authentication.Microservice.Model
{
    public class UserModel
    {
        [Key]
        public Guid userId { get; set; }
        public string name { get; set; }
    }
}
