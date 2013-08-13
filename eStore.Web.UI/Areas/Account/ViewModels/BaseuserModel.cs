using eStore.Domain;
using System.ComponentModel.DataAnnotations;

namespace eStore.Web.UI.Areas.Account.ViewModels
{
    public class BaseUserModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(12, ErrorMessage = "Must be between 3 and 12 characters", MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, ErrorMessage = "Must be between 3 and 10 characters", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }

    }
}