namespace Auth.Jwt.Web.ViewModels.Authenticate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Auth.Jwt.Web.Contracts.ViewModels;

    /// <summary>
    ///     Describes a view model including only the name of a user.
    /// </summary>
    public class UserNameViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the UserNameViewModel class.
        /// </summary>
        protected UserNameViewModel()
        {
            this.UserName = string.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the UserNameViewModel class.
        /// </summary>
        protected UserNameViewModel(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(userName));
            }

            this.UserName = userName;
        }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        [Display(
            Name = nameof(UserNameViewModel.UserName),
            Prompt = nameof(UserNameViewModel.UserName) + nameof(DisplayAttribute.Prompt))]
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
