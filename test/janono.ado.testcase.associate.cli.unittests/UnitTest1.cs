using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace janono.ado.testcase.associate.cli.unittests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            string[] input = System.Array.Empty<string>();

            // Act
            var a = janono.ado.testcase.associate.cli.Program.Main(input);

            // Assert
            Assert.AreEqual(a, 1);
        }
    }
}
