using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Core.API.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid userId { get; set; }
        public string ?name { get; set; }
        public string ?email { get; set; }
    }
}