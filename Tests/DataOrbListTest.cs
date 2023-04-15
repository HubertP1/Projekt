using Data;

namespace Tests
{
    [TestClass]
    public class DataOrbListTest
    {
        [TestMethod]
        public void AddOrbTest()
        {
            IData dataApi = new DataApi();    

            Assert.AreEqual(0, dataApi.GetOrbs().Count);

            dataApi.AddOrb(20, 10, 15, 2, 3);

            Assert.AreEqual(1, dataApi.GetOrbs().Count);

            dataApi.ClearOrbs();

            Assert.AreEqual(0, dataApi.GetOrbs().Count);
        }
    }
}
