namespace Auth.Jwt.Web.Attributes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Defines the default requirements for passwords.
    /// </summary>
    public class PasswordStringLengthAttribute : StringLengthAttribute
    {
        /// <summary>
        ///     The maximum length of a password.
        /// </summary>
        public const int MaxLength = 100;

        /// <summary>
        ///     The minimum length of a password.
        /// </summary>
        public const int MinLength = 4;

        /// <summary>
        ///     The error message for failed validations.
        /// </summary>
        public const string PasswordLengthErrorMessage = "StringLength";

        /// <summary>
        ///     Initializes a new instance of the <see cref="PasswordStringLengthAttribute" />
        ///     class.
        /// </summary>
        public PasswordStringLengthAttribute()
            : base(PasswordStringLengthAttribute.MaxLength)
        {
            this.MinimumLength = PasswordStringLengthAttribute.MinLength;
            this.ErrorMessage = PasswordStringLengthAttribute.PasswordLengthErrorMessage;
        }
    }
}
