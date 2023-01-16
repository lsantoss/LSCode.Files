using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LSCode.Files.Test.Unit")]
namespace LSCode.Files.FTP.Constants
{
    /// <summary>Provides all error messages present in that package.</summary>
    internal static class Errors
    {
        /// <value>The parameter user must contain values. Cannot be null, empty or consists only of white-space characters.</value>
        internal static string UserNullEmptyOrWhiteSpace = @"The parameter user must contain values. Cannot be null, empty or consists only of white-space characters.";

        /// <value>The parameter password must contain values. Cannot be null, empty or consists only of white-space characters.</value>
        internal static string PasswordNullEmptyOrWhiteSpace = @"The parameter password must contain values. Cannot be null, empty or consists only of white-space characters.";
    }
}