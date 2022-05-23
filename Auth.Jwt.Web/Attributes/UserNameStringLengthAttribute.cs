namespace Auth.Jwt.Web.Attributes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Specifies the default requirements for the name of a user.
    /// </summary>
    public class UserNameStringLengthAttribute : StringLengthAttribute
    {
        /// <summary>
        ///     Maximum length of a user name.
        /// </summary>
        public const int MaxLength = 100;

        /// <summary>
        ///     Minimum length of a user name.
        /// </summary>
        public const int MinLength = 3;

        /// <summary>
        ///     The error message for failed validations.
        /// </summary>
        public const string UserNameLengthErrorMessage = "StringLength";

        /// <summary>
        ///     Initializes a new instance of the UserNameStringLengthAttribute class.
        /// </summary>
        public UserNameStringLengthAttribute()
            : base(UserNameStringLengthAttribute.MaxLength)
        {
            this.MinimumLength = UserNameStringLengthAttribute.MinLength;
            this.ErrorMessage = UserNameStringLengthAttribute.UserNameLengthErrorMessage;
        }
    }
}
