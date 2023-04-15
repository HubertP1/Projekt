using Data;
using Logic;

namespace Tests
{
    [TestClass]
    public class SceneTest
    {
        [TestMethod]
        public void GetterTest()
        {
            IData apiData = new DataApi();
            ILogic apiLogic = new LogicApi(apiData);

            apiLogic.CreateScene(100, 300, 10, 20);
            apiLogic.Enable();

            Assert.AreEqual(100, apiData.SceneYDimension);
            Assert.AreEqual(300, apiData.SceneXDimension);
        }

        [TestMethod]
        public void SceneOrbCountTest()
        {
            IData apiData = new DataApi();
            ILogic apiLogic = new LogicApi(apiData);

            apiLogic.CreateScene(100, 300, 10, 20);

            Assert.AreEqual(10, apiData.GetOrbs().Count);
            Assert.AreEqual(20, apiData.GetOrbs()[0].Radius);
        }

        [TestMethod]
        public void EnableTest()
        {
            IData apiData = new DataApi();
            ILogic apiLogic = new LogicApi(apiData);

            Assert.IsFalse(apiData.IsEnabled);

            apiLogic.Enable();

            Assert.IsTrue(apiData.IsEnabled);

            apiLogic.Disable();

            Assert.IsFalse(apiData.IsEnabled);
        }
    }
}
