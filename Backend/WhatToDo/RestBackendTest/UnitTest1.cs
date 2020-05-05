using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestBackendTest
{
    [TestClass]
    public class UnitTest1
    {
        private ActivityController _activityController;

        [TestInitialize]
        public void init()
        {
            _actionController = new ActivityController();
        }

        [TestMethod]
        public void GetAll()
        {

            //ARRANGE
            //kan ændre sig i forhold til antallet af test data i databasen.
             int expected = 8;

            //ASSERT
            Assert.AreEqual(expected, _activityController.get().count);

        }

        [TestMethod]
        public void GetTimeOfAnActivity()
        {

        }



    }
}
