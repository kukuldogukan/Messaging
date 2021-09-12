using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestClass]
    public class MessageManagerTest : TestBase
    {
   
        [Test]
        public void GetByReceiverUserId_methodu_gonderici_idsi_ile_mesaji_getirir()
        {
            var senderId = 1;
            var receiverId = 2;
            var text = "TestText";

            MockMessage(receiverId, senderId, text);

            var actual = messageService.Object.GetByReceiverUserId(receiverId).Data;

            Assert.AreEqual(senderId, actual.SenderUserId);
            Assert.AreEqual(receiverId, actual.ReceiverUserId);
            Assert.AreEqual(text, actual.MessageText);
        }

        [Test]
        public void GetBySenderUserId_methodu_gonderici_idsi_ile_mesaji_getirir()
        {
            var senderId = 1;
            var receiverId = 2;
            var text = "TestText";

            MockMessage(receiverId, senderId, text);

            var actual = messageService.Object.GetBySenderUserId(senderId).Data;

            Assert.AreEqual(senderId, actual.SenderUserId);
            Assert.AreEqual(receiverId, actual.ReceiverUserId);
            Assert.AreEqual(text, actual.MessageText);
        }

        //[Test]
        //public void Send_methodu_kullanici_engellendiyse_mesaj_gondermez()
        //{
        //    var sender = SetupUser("sender");
        //    var receiver = SetupUser("receiver");
        //    var text = "TestText";

        //    AddUserBlockedUserMapping(receiver.Id, sender.Id);

        //    var actual = messageService.Object.Send(receiver.UserCode, sender.UserCode, text);

        //    Assert.AreEqual(actual.Message, Messages.CanNotSendMessageDueToTheBlock);
        //}
    }
}
