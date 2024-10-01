using FoxLabs.RESTFul.Metadata.Internal;

namespace FoxLabs.RESTful.Tests
{
    [TestClass]
    public class ClrTypeTests
    {
        [TestMethod]
        public void AddClrTypeTest()
        {
            var model = new Model();

            var metadata = model.AddType(typeof(SimpleTestClass));

            Assert.IsNotNull(metadata);
        }

        [TestMethod]
        public void ClrTypeFullNameTest()
        {
            var model = new Model();
            
            var metadata = model.AddType(typeof(SimpleTestClass));

            Assert.IsFalse(string.IsNullOrEmpty(metadata?.FullName));
        }

        [TestMethod]
        public void ClrTypeShortNameTest()
        {
            var model = new Model();
            
            var metadata = model.AddType(typeof(SimpleTestClass));
            
            Assert.IsFalse(string.IsNullOrEmpty(metadata?.ShortName));
        }

        [TestMethod]
        public void ClrTypeIsInterfaceTest()
        {
            var model = new Model();
            
            var metadata = model.AddType(typeof(ISimpleTestInterface));
            
            Assert.IsTrue(metadata?.IsInterface);

            metadata = model.AddType(typeof(SimpleTestClass));
            
            Assert.IsFalse(metadata?.IsInterface);
        }

        [TestMethod]
        public void ClrTypeIsCollectionTest()
        {
            var model = new Model();
            
            var metadata = model.AddType(typeof(List<SimpleTestClass>));
            
            Assert.IsTrue(metadata?.IsCollection);
            
            metadata = model.FindType(typeof(SimpleTestClass));
            
            Assert.IsFalse(metadata?.IsCollection);
        }

        [TestMethod]
        public void ClrTypePropertiesNotEmptyTest()
        {
            var model = new Model();

            var metadata = model.AddType(typeof(SimpleTestClass));
            
            Assert.IsTrue(metadata?.Properties.Any());
        }
    }
}