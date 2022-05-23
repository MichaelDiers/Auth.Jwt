namespace Auth.Jwt.Web.ViewModels.SignIn
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Auth.Jwt.Web.Attributes;

    /// <summary>
    ///     Specifies the required data for signing in a user.
    /// </summary>
    public class SignInViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the SignInViewModel class.
        /// </summary>
        public SignInViewModel()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the SignInViewModel class.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        public SignInViewModel(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(password));
            }

            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        ///     Gets or sets the password of the user.
        /// </summary>
        [Display(Name = "Password", Prompt = "PasswordPrompt")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [PasswordStringLength]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        [Display(Name = "UserName", Prompt = "UserNamePrompt")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [UserNameStringLength]
        public string UserName { get; set; }
    }
}
