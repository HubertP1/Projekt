using NUnit.Framework;


namespace App.UnitTests
{
    class SumaTest
    {
        [Test]
        public void SumTest()
        {
            Suma suma = new Suma();
            Assert.AreEqual(3, suma.Sum(1, 2));
        }
    }
}
