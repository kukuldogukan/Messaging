using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestFixture]
    public class UserManagerTest : TestBase
    {
        [Test]
        public void GetByUserCode_methodu_userCode_ile_sorgu_yapilinca_userı_doner()
        {
            var userCode = "userTest";
            SetupUser(userCode);

            var actual = userService.Object.GetByUserCode(userCode);

            Assert.AreEqual(userCode, actual.UserCode);
        }

        [Test]
        public void GetByEmail_methodu_userCode_ile_sorgu_yapilinca_userı_doner()
        {
            var email = "emailTest";
            SetupUser("test", email);

            var actual = userService.Object.GetByMail(email);

            Assert.AreEqual(email, actual.Email);
        }
    }
}
