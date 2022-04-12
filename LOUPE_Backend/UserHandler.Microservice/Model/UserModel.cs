using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Model
{
    public class UserModel
    {
        [Key]
        public string userID { get; set; }
        public string name { get; set; }
    }
}
