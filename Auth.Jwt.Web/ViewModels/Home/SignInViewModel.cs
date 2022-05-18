namespace Auth.Jwt.Web.ViewModels.Home
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class SignInViewModel
    {
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "StringLength", MinimumLength = 4)]
        public string Password { get; set; }

        [DisplayName("UserName")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "StringLength", MinimumLength = 4)]
        public string UserName { get; set; }
    }
}
