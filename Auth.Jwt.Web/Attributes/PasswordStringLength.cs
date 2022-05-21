namespace Auth.Jwt.Web.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class PasswordStringLength : StringLengthAttribute
    {
        public const string PasswordErrorMessage = "StringLength";
        public const int PasswordMaximumLength = 100;

        public const int PasswordMinimumLength = 4;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PasswordStringLength" />
        ///     class.
        /// </summary>
        public PasswordStringLength()
            : base(PasswordStringLength.PasswordMaximumLength)
        {
            this.MinimumLength = PasswordStringLength.PasswordMinimumLength;
            this.ErrorMessage = PasswordStringLength.PasswordErrorMessage;
        }
    }
}
