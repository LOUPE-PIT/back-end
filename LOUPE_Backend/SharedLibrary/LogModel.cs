﻿using System.ComponentModel.DataAnnotations;

namespace SharedLibrary
{
    public class LogModel
    {
        [Key]
        public string logId { get; set; }
        //[ForeignKey("User")]
        public string userId { get; set; }
        public string log { get; set; }
    }
}