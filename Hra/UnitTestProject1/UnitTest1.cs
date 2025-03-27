using Hra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace UnitTestProject1
{
    [TestClass]
    public class HerniPostavaTests
    {
        [TestMethod]
        public void ArePositionsInitialized()
        {
            HerniPostava postava = new HerniPostava("Test");
            Assert.AreEqual(0, postava.PoziceX);
            Assert.AreEqual(0, postava.PoziceY);
        }

        [TestMethod]
        public void CannotSetLongName()
        {
            HerniPostava postava = new HerniPostava("DlouhéJméno123");
            Assert.AreNotEqual("DlouhéJméno123", postava.Jmeno);
        }

        [TestMethod]
        public void CanSetValidName()
        {
            HerniPostava postava = new HerniPostava("Hrdina");
            Assert.AreEqual("Hrdina", postava.Jmeno);
        }

        [TestMethod]
        public void LevelIsInitializedToOne()
        {
            HerniPostava postava = new HerniPostava("Test");
            Assert.AreEqual(1, postava.Level);
        }
    }

    [TestClass]
    public class HracTests
    {
        [TestMethod]
        public void CanSetValidSpecialization()
        {
            Hrac hrac = new Hrac("Hrdina", "Kouzelník", 0, 0, 0);
            Assert.AreEqual("Kouzelník", hrac.Specializace);
        }

        [TestMethod]
        public void CannotSetInvalidSpecialization()
        {
            Hrac hrac = new Hrac("Hrdina", "Neznámý", 0, 0, 0);
            Assert.AreNotEqual("Neznámý", hrac.Specializace);
        }

        [TestMethod]
        public void AddXpLevelsUp()
        {
            Hrac hrac = new Hrac("Hrdina", "Berserker", 0, 0, 0);
            hrac.PridejXP(200);
            Assert.AreEqual(2, hrac.Level);
        }

        [TestMethod]
        public void XpIsInitializedToZero()
        {
            Hrac hrac = new Hrac("Hrdina", "Inženýr", 0, 0, 0);
            Assert.AreEqual(0, hrac.XP);
        }

        [TestMethod]
        public void AddNegativeXpDoesNotChangeXp()
        {
            Hrac hrac = new Hrac("Hrdina", "Cizák", 0, 0, 0);
            hrac.PridejXP(-50);
            Assert.AreEqual(0, hrac.XP);
        }

        [TestMethod]
        public void LevelUpWithExactThreshold()
        {
            Hrac hrac = new Hrac("Hrdina", "Kouzelník", 0, 0, 0);
            hrac.PridejXP(100);
            Assert.AreEqual(2, hrac.Level);
        }
    }

    [TestClass]
    public class NPCTests
    {
        [TestMethod]
        public void NPC_PositionCannotChange()
        {
            NPC npc = new NPC("Obchodník", "obchodník", false);
            npc.ZmenaPozice(5, 5);
            Assert.AreEqual(0, npc.PoziceX);
            Assert.AreEqual(0, npc.PoziceY);
        }

        [TestMethod]
        public void NPC_CorrectJobAssignment()
        {
            NPC npc = new NPC("Nepřítel", "nepřítel", true);
            Assert.AreEqual("nepřítel", npc.Prace);
        }

        [TestMethod]
        public void NPC_DefaultIsNotBoss()
        {
            NPC npc = new NPC("Obchodník", "obchodník");
            Assert.IsFalse(npc.Sila);
        }

        [TestMethod]
        public void NPC_CanBeBoss()
        {
            NPC npc = new NPC("Boss", "nepřítel", true);
            Assert.IsTrue(npc.Sila);
        }

        [TestMethod]
        public void NPC_PositionRemainsStatic()
        {
            NPC npc = new NPC("Statická postava", "obyvatel", false);
            npc.ZmenaPozice(10, 10);
            Assert.AreEqual(0, npc.PoziceX);
            Assert.AreEqual(0, npc.PoziceY);
        }
    }


}

