using FoxLabs.RESTFul.Metadata.Internal;

namespace FoxLabs.RESTful.Tests
{
    [TestClass]
    public class PropertyTests
    {
        [TestMethod]
        public void GetPropertyTest()
        {
            var model = new Model();

            var typeMetadata = model.AddType(typeof(SimpleTestClass));
            var propMetadata = typeMetadata?.GetProperty(nameof(SimpleTestClass.TestProp));
            
            Assert.IsNotNull(propMetadata);
        }

        [TestMethod]
        public void PropertyTypeValidTest()
        {
            var model = new Model();
            
            var typeMetadata = model.AddType(typeof(SimpleTestClass));
            var propMetadata = typeMetadata?.GetProperty(nameof(SimpleTestClass.TestProp));

            var expectedType = model.FindType(typeof(string));
            
            Assert.AreEqual(propMetadata?.ReturnType, expectedType);
        }
    }
}