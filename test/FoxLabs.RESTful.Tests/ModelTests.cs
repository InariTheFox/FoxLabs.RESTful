using FoxLabs.RESTFul.Metadata.Internal;

namespace FoxLabs.RESTful.Tests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var model = new Model();

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void ConstuctorBuilderNotNullTest()
        {
            var model = new Model();

            Assert.IsNotNull(model.Builder);
        }
    }
}