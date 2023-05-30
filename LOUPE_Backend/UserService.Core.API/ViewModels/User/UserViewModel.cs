using System.ComponentModel.DataAnnotations;

namespace UserService.Core.API.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid userId { get; set; }
        public string ?name { get; set; }
        public string ?email { get; set; }
        public bool ?isStudent { get; set; }
    }
}