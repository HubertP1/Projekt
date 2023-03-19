namespace App.HelloWorldTest
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void OutputTest()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            HelloWorld.Main(null);
            string output = stringWriter.ToString().Trim();
            Assert.AreEqual("Hello World!", output);
        }
    }
}