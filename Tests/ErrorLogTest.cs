using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestClass]
    public class ErrorLogTest : TestBase
    {
        [Test]
        public void Add_methodu_error_log_kaydi_atar()
        {
            var errorLog = AddErrorLog("test", 1);
            var actual = errorLogService.Object.Add(errorLog);

            Assert.IsTrue(actual.Success);
        }
    }
}
