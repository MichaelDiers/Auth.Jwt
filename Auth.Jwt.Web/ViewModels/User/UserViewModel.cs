namespace Auth.Jwt.Web.ViewModels.User
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Auth.Jwt.Web.Contracts.ViewModels;

    /// <summary>
    ///     Specifies the data of a user.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the UserViewModel class.
        /// </summary>
        public UserViewModel()
        {
            this.UserName = string.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the UserViewModel class.
        /// </summary>
        public UserViewModel(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(userName));
            }

            this.UserName = userName;
        }

        /// <summary>
        ///     Gets or sets the name of a user.
        /// </summary>
        [Display(
            Name = nameof(UserViewModel.UserName),
            Prompt = nameof(UserViewModel.UserName) + nameof(DisplayAttribute.Prompt))]
        [Required(AllowEmptyStrings = false, ErrorMessage = nameof(RequiredAttribute))]
        [DataType(DataType.Text)]
        [StringLength(
            Validations.UserNameMaxLength,
            ErrorMessage = nameof(StringLengthAttribute),
            MinimumLength = Validations.UserNameMinLength)]
        public string UserName { get; set; }
    }
}
