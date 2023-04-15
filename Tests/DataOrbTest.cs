using Data;

namespace Tests
{
    [TestClass]
    public class DataOrbTest
    {
        Orb orb = new(20, 5, 10, 2, 3);
        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(20, orb.Radius);
            Assert.AreEqual(5, orb.PositionX);
            Assert.AreEqual(10, orb.PositionY);
            Assert.AreEqual(2, orb.VelocityX);
            Assert.AreEqual(3, orb.VelocityY);
        }

        [TestMethod]
        public void SetterTest()
        {
            orb.PositionX = 15;
            orb.PositionY = 25;

            orb.VelocityX = 5;
            orb.VelocityY = 4;

            Assert.AreEqual(15, orb.PositionX);
            Assert.AreEqual(25, orb.PositionY);

            Assert.AreEqual(5, orb.VelocityX);
            Assert.AreEqual(4, orb.VelocityY);
        }
    }
}