namespace Auth.Jwt.Web.ViewModels.SignIn
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Auth.Jwt.Web.Contracts.ViewModels;

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
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(password));
            }

            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        ///     Gets or sets the password of the user.
        /// </summary>
        [Display(
            Name = nameof(SignInViewModel.Password),
            Prompt = nameof(SignInViewModel.Password) + nameof(DisplayAttribute.Prompt))]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = nameof(RequiredAttribute))]
        [DataType(DataType.Password)]
        [StringLength(
            Validations.PasswordMaxLength,
            ErrorMessage = nameof(StringLengthAttribute),
            MinimumLength = Validations.PasswordMinLength)]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        [Display(
            Name = nameof(SignInViewModel.UserName),
            Prompt = nameof(SignInViewModel.UserName) + nameof(DisplayAttribute.Prompt))]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = nameof(RequiredAttribute))]
        [DataType(DataType.Text)]
        [StringLength(
            Validations.UserNameMaxLength,
            ErrorMessage = nameof(StringLengthAttribute),
            MinimumLength = Validations.UserNameMinLength)]
        public string UserName { get; set; }
    }
}
