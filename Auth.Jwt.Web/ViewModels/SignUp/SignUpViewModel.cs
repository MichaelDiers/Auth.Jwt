namespace Auth.Jwt.Web.ViewModels.SignUp
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Auth.Jwt.Web.Contracts.ViewModels;

    /// <summary>
    ///     Describes the required data for signing up a new user.
    /// </summary>
    public class SignUpViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the SignUpViewModel class.
        /// </summary>
        public SignUpViewModel()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.PasswordRepeat = string.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the SignUpViewModel class.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="passwordRepeat">The <paramref name="password" /> and <paramref name="passwordRepeat" /> should be equal.</param>
        public SignUpViewModel(string userName, string password, string passwordRepeat)
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

            if (string.IsNullOrWhiteSpace(passwordRepeat))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(passwordRepeat));
            }

            this.UserName = userName;
            this.Password = password;
            this.PasswordRepeat = passwordRepeat;
        }

        /// <summary>
        ///     Gets or sets the password of the user.
        /// </summary>
        [Display(
            Name = nameof(SignUpViewModel.Password),
            Prompt = nameof(SignUpViewModel.Password) + nameof(DisplayAttribute.Prompt))]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = nameof(RequiredAttribute))]
        [DataType(DataType.Password)]
        [StringLength(
            Validations.PasswordMaxLength,
            ErrorMessage = nameof(StringLengthAttribute),
            MinimumLength = Validations.PasswordMinLength)]
        [Compare(
            nameof(SignUpViewModel.PasswordRepeat),
            ErrorMessage = nameof(CompareAttribute))]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the password of the user.
        /// </summary>
        [Display(
            Name = nameof(SignUpViewModel.PasswordRepeat),
            Prompt = nameof(SignUpViewModel.PasswordRepeat) + nameof(DisplayAttribute.Prompt))]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = nameof(RequiredAttribute))]
        [DataType(DataType.Password)]
        [StringLength(
            Validations.PasswordMaxLength,
            ErrorMessage = nameof(StringLengthAttribute),
            MinimumLength = Validations.PasswordMinLength)]
        [Compare(
            nameof(SignUpViewModel.Password),
            ErrorMessage = nameof(CompareAttribute))]
        public string PasswordRepeat { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        [Display(
            Name = nameof(SignUpViewModel.UserName),
            Prompt = nameof(SignUpViewModel.UserName) + nameof(DisplayAttribute.Prompt))]
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
