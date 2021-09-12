using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestClass]
    public class UserBlockedUserMappingTest : TestBase
    {
        [Test]
        public void GetByBlockerUserId_methodu_user_ile_kayitlari_getirir()
        {
            var blockerUser = 1;
            var receiverUser = 2;
            AddUserBlockedUserMapping(blockerUser, receiverUser);

            var actual = blockerUserService.Object.GetByBlockerUserId(blockerUser);

            Assert.AreEqual(blockerUser, actual.Data.BlockerUserId);
        }
    }
}
