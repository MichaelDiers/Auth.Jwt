namespace Auth.Jwt.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Describes the form data for signing in a user.
    /// </summary>
    public class SignInViewModel
    {
        /// <summary>
        ///     Gets or sets the password of the user.
        /// </summary>
        [Display(Name = "Password", Prompt = "PasswordPrompt")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "StringLength", MinimumLength = 4)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        [Display(Name = "UserName", Prompt = "UserNamePrompt")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "StringLength", MinimumLength = 4)]
        public string UserName { get; set; } = string.Empty;
    }
}
