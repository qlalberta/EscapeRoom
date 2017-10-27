using System;
using System.Collections.Generic;
using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTest
{
    [TestClass]
    public class DisplayTest
    {
        [TestMethod]
        public void ShowSingleText()
        {
            Display display = new Display();
            display.Show("Quinn");
            Assert.AreEqual(display.LastShow, "Quinn");
        }

        [TestMethod]
        public void ShowList()
        {
            List<string> list = new List<string>(new string[] { "test1", "test2", "test3" });
            Display display = new Display();
            display.Show(list);
            Assert.AreEqual
                (display.LastShow, "test1" + Environment.NewLine + "test2" + Environment.NewLine + "test3" + Environment.NewLine);
        }
    }
}
