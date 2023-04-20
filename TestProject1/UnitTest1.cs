using System.Drawing;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Point gridSize = new Point(7, 15);
            GridRunner runner = new GridRunner(4, 10, "Left", gridSize);
            var movement = "FLFLFRFFLF";
            runner.MoveCell(movement);
            var resulkt = runner.GetPosition();

            Assert.AreEqual(runner.GetPosition(), "5 7 Right");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Point gridSize = new Point(10, 10);
            GridRunner runner = new GridRunner(0, 10, "Right", gridSize);
            var movement = "LFFLFFRRRFRFFFLFRFFRFFFRFLFRF";
            runner.MoveCell(movement);
            var resulkt = runner.GetPosition();

            Assert.AreEqual(runner.GetPosition(), "2 10 Right");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Point gridSize = new Point(5, 5);
            GridRunner runner = new GridRunner(0, 0, "Up", gridSize);
            var movement = "FRFFFLFRRRRFFFLLFLF";
            runner.MoveCell(movement);
            var resulkt = runner.GetPosition();

            Assert.AreEqual(runner.GetPosition(), "4 4 Right");
        }
    }
}