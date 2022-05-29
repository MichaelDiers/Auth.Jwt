namespace Auth.Jwt.Web.ViewModels.Authenticate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Auth.Jwt.Web.Contracts.ViewModels;

    /// <summary>
    ///     Specifies the required data for validating an email address.
    /// </summary>
    public class ValidateEmailViewModel : UserNameViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the ValidateEmailViewModel class.
        /// </summary>
        public ValidateEmailViewModel()
        {
            this.ValidationCode = string.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the ValidateEmailViewModel class.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="validationCode">The email validation code.</param>
        public ValidateEmailViewModel(string userName, string validationCode)
            : base(userName)
        {
            if (string.IsNullOrWhiteSpace(validationCode))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(validationCode));
            }

            this.ValidationCode = validationCode;
        }

        /// <summary>
        ///     Gets or sets the validation code.
        /// </summary>
        [Display(
            Name = nameof(ValidateEmailViewModel.ValidationCode),
            Prompt = nameof(ValidateEmailViewModel.ValidationCode) + nameof(DisplayAttribute.Prompt))]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = nameof(RequiredAttribute))]
        [DataType(DataType.Text)]
        [StringLength(
            Validations.UserNameMaxLength,
            ErrorMessage = nameof(StringLengthAttribute),
            MinimumLength = Validations.UserNameMinLength)]
        public string ValidationCode { get; set; }
    }
}
