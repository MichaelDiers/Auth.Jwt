namespace Auth.Jwt.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    public class SignInViewModel
    {
        [Display(Name = "Password", Prompt = "PasswordPrompt")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "StringLength", MinimumLength = 4)]
        public string Password { get; set; }

        [Display(Name = "UserName", Prompt = "UserNamePrompt")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "StringLength", MinimumLength = 4)]
        public string UserName { get; set; }
    }
}
