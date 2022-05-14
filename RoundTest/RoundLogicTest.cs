using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundProject;
using RoundProject.Entities;
using RoundProject.BLL;
using RoundProject.DAL;
using RoundProject.PLL;
using System.Collections.Generic;

namespace RoundTest
{
    [TestClass]
    public class RoundLogicTest
    {

        [TestMethod]
        public void TestCreate()
        {
            IRoundRepo repo = new RoundInMemoryRepo();
            IRoundLogic logic = new RoundLogicImpl(repo);

            Point pointExpected = new Point { X = 2, Y = 2 };
            Round roundExpected = new Round { A = pointExpected, RADIUS = 10 };

            Round roundActual = logic.Create(2, 2, 10);
            
            Assert.AreEqual(1, roundActual.Id);
            Assert.AreEqual(roundExpected.A.X, roundActual.A.X);
            Assert.AreEqual(roundExpected.A.Y, roundActual.A.Y);
            Assert.AreEqual(roundExpected.RADIUS, roundActual.RADIUS);
        }

        [TestMethod]
        public void TestUpdate()
        {
            IRoundRepo repo = new RoundInMemoryRepo();
            IRoundLogic logic = new RoundLogicImpl(repo);

            Point pointExpected = new Point { X = 3, Y = 3 };
            Round roundExpected = new Round { A = pointExpected, RADIUS = 20 };

            Round roundActual = logic.Create(2, 2, 10);
            roundActual = logic.Update(1, 3, 3, 20);

            Assert.AreEqual(roundExpected.A.X, roundActual.A.X);
            Assert.AreEqual(roundExpected.A.Y, roundActual.A.Y);
            Assert.AreEqual(roundExpected.RADIUS, roundActual.RADIUS);
        }
        [TestMethod]
        public void TestDelete()
        {
            IRoundRepo repo = new RoundInMemoryRepo();
            IRoundLogic logic = new RoundLogicImpl(repo);

            logic.Create(2, 2, 10);
            Assert.AreEqual(true, logic.Delete(1));
        }
        [TestMethod]
        public void TestFind()
        {
            IRoundRepo repo = new RoundInMemoryRepo();
            IRoundLogic logic = new RoundLogicImpl(repo);

            Round roundExpected = logic.Create(2, 2, 10);
            Round findRound = logic.Find(1);

            Assert.AreEqual(roundExpected.Id, findRound.Id);
            Assert.AreEqual(roundExpected.A, findRound.A);
            Assert.AreEqual(roundExpected.RADIUS, findRound.RADIUS);
        }

        [TestMethod]
        public void TestFindAll()
        {
            IRoundRepo repo = new RoundInMemoryRepo();
            IRoundLogic logic = new RoundLogicImpl(repo);

            List<Round> rounds= new List<Round>();
            List<Round> findAllRounds = new List<Round>();
            Round roundExpectedFirst = logic.Create(2, 2, 10);
            Round roundExpectedSecond = logic.Create(2, 2, 10);
            rounds.Add(roundExpectedFirst);
            rounds.Add(roundExpectedSecond);

            findAllRounds = logic.FindAll();
            
            Assert.AreEqual(rounds[0], findAllRounds[0]);
            Assert.AreEqual(rounds[1], findAllRounds[1]);
        }

        [TestMethod]
        public void TestLengthCircle()
        {
            IRoundRepo repo = new RoundInMemoryRepo();
            IRoundLogic logic = new RoundLogicImpl(repo);

            Round roundActual = logic.Create(2, 2, 10);

            Assert.AreEqual(62.83185307179586, roundActual.LengthCircle(roundActual.RADIUS));
        }

        [TestMethod]
        public void TestSquareCircle()
        {
            IRoundRepo repo = new RoundInMemoryRepo();
            IRoundLogic logic = new RoundLogicImpl(repo);

            Round roundActual = logic.Create(2, 2, 10);

            Assert.AreEqual(314.1592653589793, roundActual.SquareCircle(roundActual.RADIUS));
        }
    }
}
