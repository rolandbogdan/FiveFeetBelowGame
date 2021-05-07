// <copyright file="Test.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        /// <summary>
        /// This function tests inserting a single object into the repo.
        /// </summary>
        [Test]
        public void TestInsertOne()
        {
            HighscoreLogic hsl = new HighscoreLogic(this.repo.Object);

            Highscore newHs = new Highscore("Kathi Béla", 150, 3);

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

            Highscore newHs = new Highscore("Kathi Béla", 150, 3);

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
                        new Highscore("Kathi Béla", 150, 3),
                        new Highscore("Bohos Kornél", 150, 3),
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
                        new Highscore("Kathi Béla", 150, 3),
                        new Highscore("Bohos Kornél", 150, 3),
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
                        new Highscore("Bohos Kornél", 250, 5),
                        new Highscore("Kathi Béla", 500, 10),
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
    }
}
