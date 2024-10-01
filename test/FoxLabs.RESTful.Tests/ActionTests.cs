using FoxLabs.RESTFul.Metadata.Internal;

namespace FoxLabs.RESTful.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void GetActionTest()
        {
            var model = new Model();

            var typeMetadata = model.AddType(typeof(SimpleTestClass));
            var actionMetadata = typeMetadata?.GetAction(nameof(SimpleTestClass.DoSomething));
            
            Assert.IsNotNull(actionMetadata);
        }

        [TestMethod]
        public void ActionReturnTypeValid()
        {
            var model = new Model();
            
            var typeMetadata = model.AddType(typeof(SimpleTestClass));
            var actionMetadata = typeMetadata?.GetAction(nameof(SimpleTestClass.DoSomething));

            var expectedType = model.FindType(typeof(void));
            
            Assert.AreEqual(actionMetadata?.ReturnType, expectedType);
        }
    }
}