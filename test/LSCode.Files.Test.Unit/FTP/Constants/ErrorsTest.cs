using LSCode.Files.FTP.Constants;
using NUnit.Framework;

namespace LSCode.Files.Test.Unit.FTP.Constants
{
    internal class ErrorsTest
    {
        [Test]
        public void UserNullEmptyOrWhiteSpace_Text_Valid()
        {
            //Assert
            Assert.That(
                Errors.UserNullEmptyOrWhiteSpace,
                Is.EqualTo("The parameter user must contain values. Cannot be null, empty or consists only of white-space characters."));
        }

        [Test]
        public void PasswordNullEmptyOrWhiteSpace_Text_Valid()
        {
            //Assert
            Assert.That(
                Errors.PasswordNullEmptyOrWhiteSpace,
                Is.EqualTo("The parameter password must contain values. Cannot be null, empty or consists only of white-space characters."));
        }
    }
}