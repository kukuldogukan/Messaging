using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestFixture]
    public class UserActivityTest : TestBase    
    {
        [Test]
        public void Add_methodu_yeni_user_activity_ekler()
        {
            var activity = AddUserActivity(UserActivities.Register);
            var actual = userActivityService.Object.Add(activity);

            Assert.IsTrue(actual.Success);
        }
    }
}
