// <copyright file="Test.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FiveFeetBelowGame.BL;
    using FiveFeetBelowGame.VM;
    using Logic;
    using Model;
    using Moq;
    using NUnit.Framework;
    using Repository;

    /// <summary>
    /// The unit testing class.
    /// </summary>
    [TestFixture]
    public class Test
    {
        private Mock<IStorageRepository<Highscore>> repo = new Mock<IStorageRepository<Highscore>>();
        private GameModel model;
        private GameLogic logic;

        /// <summary>
        /// Initializes model and logic for this class.
        /// </summary>
        public void Init()
        {
            this.model = new GameModel(600, 1000);
            this.logic = new GameLogic(this.model, "testfile.json");
        }

        /// <summary>
        /// This function tests inserting a single object into the repo.
        /// </summary>
        [Test]
        public void TestInsertOne()
        {
            HighscoreLogic hsl = new HighscoreLogic(this.repo.Object);

            Highscore newHs = new Highscore("Kathi Béla", 150, 3, 10);

            this.repo.Setup(x => x.Insert(It.IsAny<Highscore>()));
            hsl.Insert(newHs);

            this.repo.Verify(x => x.Insert(newHs), Times.Once);
        }

        /// <summary>
        /// This function tests deleting a single object from the repo.
        /// </summary>
        [Test]
        public void TestDeleteOne()
        {
            HighscoreLogic hsl = new HighscoreLogic(this.repo.Object);

            Highscore newHs = new Highscore("Kathi Béla", 150, 3, 10);

            this.repo.Setup(x => x.Delete(It.IsAny<Highscore>()));
            hsl.Delete(newHs);

            this.repo.Verify(x => x.Delete(newHs), Times.Once);
        }

        /// <summary>
        /// This function tests reading a single object from the repo.
        /// </summary>
        [Test]
        public void TestGetOneHighscore()
        {
            HighscoreLogic hsl = new HighscoreLogic(this.repo.Object);

            List<Highscore> newHs = new List<Highscore>()
                  {
                        new Highscore("Kathi Béla", 150, 3, 15),
                        new Highscore("Bohos Kornél", 150, 3, 15),
                  };

            Highscore expectedout = new Highscore();
            expectedout = newHs[0];

            this.repo.Setup(x => x.GetOne(newHs[0].HsID)).Returns(newHs[0]);

            var output = hsl.GetOneHighscore(newHs[0].HsID);
            Assert.That(output.HsID, Is.EquivalentTo(expectedout.HsID));
        }

        /// <summary>
        /// This function tests reading all objects from the repo.
        /// </summary>
        [Test]
        public void TestGetAllHighscore()
        {
            HighscoreLogic hsl = new HighscoreLogic(this.repo.Object);

            List<Highscore> newHs = new List<Highscore>()
                  {
                        new Highscore("Kathi Béla", 150, 3, 20),
                        new Highscore("Bohos Kornél", 150, 3, 25),
                  };

            List<Highscore> expectedout = new List<Highscore>()
                  {
                        newHs[0], newHs[1],
                  };

            this.repo.Setup(x => x.GetAll()).Returns(newHs.AsQueryable());

            var output = hsl.GetAllHighscore();

            Assert.That(output, Is.EquivalentTo(expectedout));
            Assert.That(output.Count, Is.EqualTo(expectedout.Count));
        }

        /// <summary>
        /// This function tests the ordering of objects in the repo.
        /// </summary>
        [Test]
        public void TestOrderedHighscore()
        {
            List<Highscore> newHs = new List<Highscore>()
                  {
                        new Highscore("Bohos Kornél", 250, 5, 50),
                        new Highscore("Kathi Béla", 500, 10, 200),
                  };

            List<Highscore> expectedout = new List<Highscore>()
                  {
                        newHs[1], newHs[0],
                  };

            this.repo.Setup(x => x.GetAll()).Returns(newHs.AsQueryable());
            HighscoreOrderingLogic hol = new HighscoreOrderingLogic(this.repo.Object);
            var output = hol.OrderedByDepth();

            Assert.That(output, Is.EquivalentTo(expectedout));
            Assert.That(output.Count, Is.EqualTo(expectedout.Count));
            this.repo.Verify(x => x.GetAll(), Times.AtLeastOnce);
        }

        /// <summary>
        /// This function tests if player gaining money function is working.
        /// </summary>
        [Test]
        public void TestPlayerMoneyGain()
        {
            this.Init();
            this.model.PlayerBalance = 0;
            this.logic.PlayerGainedMoney(10);

            Assert.That(this.model.PlayerBalance == 10);
        }

        /// <summary>
        /// This function tests if player's pickaxe levelup function is working.
        /// </summary>
        [Test]
        public void TestPickaxeLvlup()
        {
            this.Init();
            this.model.PlayerPickaxe = 2;
            this.logic.IncreasePickaxeLevel();

            Assert.That(this.model.PlayerPickaxe == 3);
        }

        /// <summary>
        /// This function tests if player gaining health function is working.
        /// </summary>
        [Test]
        public void HealPlayerTest()
        {
            this.Init();
            this.model.PlayerMaxHealth = 4;
            this.model.PlayerHealth = 1;
            this.logic.HealPlayer(5);

            Assert.That(this.model.PlayerHealth == 4);
        }

        /// <summary>
        /// This function tests if player losing health function is working.
        /// </summary>
        [Test]
        public void PlayerLostHealthTest()
        {
            this.Init();
            this.model.PlayerMaxHealth = 10;
            this.model.PlayerHealth = 10;
            this.logic.PlayerLostHealth(3);

            Assert.That(this.model.PlayerHealth == 7);
        }

        /// <summary>
        /// This function tests if neighboring block checking is working.
        /// </summary>
        [Test]
        public void IsNeighboringTest()
        {
            this.Init();
            this.model.PlayerPos = new System.Windows.Point(10, 10);

            Assert.That(this.logic.IsNeighboring(11, 10));
        }
    }
}
