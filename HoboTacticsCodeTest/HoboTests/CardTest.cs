using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HoboTacticsCodeTest.Cards;
namespace HoboTests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestCardNames()
        {
            Card testcard1 = new Card("string name");
        }
    }
}
