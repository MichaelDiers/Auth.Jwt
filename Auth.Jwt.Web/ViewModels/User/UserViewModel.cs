namespace Auth.Jwt.Web.ViewModels.User
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Auth.Jwt.Web.Attributes;

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
        [Display(Name = "UserName", Prompt = "UserNamePrompt")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [UserNameStringLength]
        public string UserName { get; set; }
    }
}
