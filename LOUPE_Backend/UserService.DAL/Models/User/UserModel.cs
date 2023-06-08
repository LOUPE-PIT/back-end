using System.ComponentModel.DataAnnotations;

namespace UserService.DataLayer.Models.User
{
    public class UserModel
    {
        [Key]
        public Guid userId { get; set; }
        public string ?name { get; set; }
        public string ?email { get; set; }
        public bool ?isStudent { get; set; }
    }
}
