using Hra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void ArePositionsInitialized()
        {
            HerniPostava postava = new HerniPostava();
            Assert.AreEqual(postava.poziceX, 0);
            Assert.AreEqual(postava.poziceY, 0);
        }

        [TestMethod]
        public void CanChangePositions()
        {
            HerniPostava postava = new HerniPostava();
            postava.changePosition(5, 5);
            Assert.AreEqual(postava.poziceX, 5);
            Assert.AreEqual(postava.poziceY, 5);
        }

        [TestMethod]
        public void Jmeno_SetValid_SavesValue()
        {
            var postava = new HerniPostava("Legolas");
            Assert.AreEqual("Legolas", postava.Jmeno);
        }

        [TestMethod]
        public void Jmeno_TooLong_ShowsWarning()
        {
            var postava = new HerniPostava("Krátké");
            postava.Jmeno = "Extrémně dlouhé jméno přes 10 znaků";
            Assert.AreNotEqual("Extrémně dlouhé jméno přes 10 znaků", postava.Jmeno);
        }

        [TestMethod]
        public void Level_InitializedTo1()
        {
            var postava = new HerniPostava("Gandalf");
            Assert.AreEqual(1, postava.Level);
        }

        [TestMethod]
        public void ZmenaPozice_UpdatesOnClick()
        {
            var postava = new HerniPostava("Gimli");
            postava.ZmenaPozice(5, 10);
            Assert.AreEqual(5, postava.poziceX);
            Assert.AreEqual(10, postava.poziceY);
        }

        [TestMethod]
        public void ToString_ContainsAllData()
        {
            var postava = new HerniPostava("Boromir");
            var result = postava.ToString();
            StringAssert.Contains(result, "Boromir");
            StringAssert.Contains(result, "Level: 1");
            StringAssert.Contains(result, "Pozice: [0,0]");
        }

    
        [TestMethod]
        public void Specializace_ValidValue_Saves()
        {
            var hrac = new Hrac("Geralt", "Berserker", /* params */);
            Assert.AreEqual("Berserker", hrac.Specializace);
        }

        [TestMethod]
        public void Specializace_InvalidValue_Throws()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Hrac("Triss", "Programátor", /* params */));
        }

        [TestMethod]
        public void PridejXP_LevelUpOnce()
        {
            var hrac = new Hrac("Yennefer", "Kouzelník", /* params */);
            hrac.PridejXP(100);
            Assert.AreEqual(2, hrac.Level);
        }

        [TestMethod]
        public void PridejXP_MultipleLevelUps()
        {
            var hrac = new Hrac("Ciri", "Cizák", /* params */);
            hrac.PridejXP(250);
            Assert.AreEqual(3, hrac.Level); 
        }

        [TestMethod]
        public void PridejXP_NegativeValue_Throws()
        {
            var hrac = new Hrac("Vesemir", "Inženýr", /* params */);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => hrac.PridejXP(-50));
        }

        [TestMethod]
        public void VzhledAttributes_Initialized()
        {
            var hrac = new Hrac("Zoltan", "Berserker", /* params */);
            Assert.IsNotNull(hrac.Vlasy);
            Assert.IsNotNull(hrac.Oblicij);
        }

        [TestMethod]
        public void ToString_IncludesXPandSpec()
        {
            var hrac = new Hrac("Dandelion", "Kouzelník", /* params */);
            var result = hrac.ToString();
            StringAssert.Contains(result, "XP: 0");
            StringAssert.Contains(result, "Kouzelník");
        }

        [TestMethod]
        public void Prace_EnumSetCorrectly()
        {
            var npc = new NPC("Vesničan", "obchodník", /* params */);
            Assert.AreEqual(Prace.obchodník, npc.Prace);
        }

        [TestMethod]
        public void Sila_DefaultNonBoss()
        {
            var npc = new NPC("Strážný", "obyvatel");
            Assert.IsFalse(npc.Sila);
        }

        [TestMethod]
        public void Sila_BossSetCorrectly()
        {
            var npc = new NPC("Dracula", "nepřítel", sila: true);
            Assert.IsTrue(npc.Sila);
        }

        [TestMethod]
        public void ZmenaPozice_StaticAfterSet()
        {
            var npc = new NPC("Kovář", "obchodník");
            npc.ZmenaPozice(10, 20);
            npc.ZmenaPozice(30, 40); 
            Assert.AreEqual(10, npc.PoziceX);
            Assert.AreEqual(20, npc.PoziceY);
        }

        [TestMethod]
        public void ToString_IncludesPraceSila()
        {
            var npc = new NPC("Barman", "obyvatel", sila: false);
            var result = npc.ToString();
            StringAssert.Contains(result, "Práce: obyvatel");
            StringAssert.Contains(result, "BOSS: Ne");
        }

        [TestMethod]
        public void HerniPostava_AbstractCheck()
        {
            Assert.IsFalse(typeof(HerniPostava).IsAbstract);
        }

        
    }
}
