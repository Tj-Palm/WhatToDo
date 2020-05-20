using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestApi.Models;
using Sensor;
using UDPreciever;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private Activity _emptyActivity;
        private Activity _fullActivity;
        private User _emptyUser;
        private User _fullUser;
        private SensorData _emptySensorData;
        private SensorData _fullSensorData;
        private Measurement _measurement;
        private Sensordata _emptyUdpSensordata;
        private Sensordata _fullUdpSensordata;


        [TestInitialize]
        public void Initialize()
        {
            _emptyActivity = new Activity();
            _emptyUser = new User();
            _emptySensorData = new SensorData();
            _emptyUdpSensordata = new Sensordata();
            _fullActivity = new Activity("Name", 20, "Type", "Environment");
            _fullUser = new User("Username", "Password");
            _fullSensorData = new SensorData(new DateTime(2020, 5, 18), 2, 4);
            _measurement = new Measurement(new DateTime(2020,05,18), 15.5 );
            _fullUdpSensordata = new Sensordata(new DateTime(2020,05,18), 20);
        }
        
        #region Test REST

        #region Models
        
        [TestMethod]
        public void TestActivityId()
        {
            _fullActivity.id = 2;
            Assert.AreEqual(2, _fullActivity.id);
        }

        [TestMethod]
        public void TestFullActivity()
        {
            _fullActivity.id = 2;
            Assert.AreEqual(2, _fullActivity.id);
            _fullActivity.ActivityLevel = "Work";
            Assert.AreEqual("Work", _fullActivity.ActivityLevel);
            _fullActivity.Environment = "Indoor";
            Assert.AreEqual("Indoor", _fullActivity.Environment);
            _fullActivity.Name = "Read a book";
            Assert.AreEqual("Read a book", _fullActivity.Name);
            _fullActivity.TimeInterval = 20;
            Assert.AreEqual(20, _fullActivity.TimeInterval);
        }

        [TestMethod]
        public void TestEmptyActivity()
        {
            _emptyActivity.id = 0;
            Assert.AreEqual(0, _emptyActivity.id);
            _emptyActivity.ActivityLevel = null;
            Assert.AreEqual(null, _emptyActivity.ActivityLevel);
            _emptyActivity.Environment = null;
            Assert.AreEqual(null, _emptyActivity.Environment);
            _emptyActivity.Name = null;
            Assert.AreEqual(null, _emptyActivity.Name);
            _emptyActivity.TimeInterval = 0;
            Assert.AreEqual(0, _emptyActivity.TimeInterval);
        }

        [TestMethod]
        public void TestUserId()
        {
            _fullUser.UserId = 3;
            Assert.AreEqual(3, _fullUser.UserId);
        }

        [TestMethod]
        public void TestFullUser()
        {
            _fullUser.Username = "Username";
            Assert.AreEqual("Username", _fullUser.Username);
            _fullUser.Password = "Password";
            Assert.AreEqual("Password", _fullUser.Password);
        }

        [TestMethod]
        public void TestEmptyUser()
        {
            _emptyUser.Username = null;
            Assert.AreEqual(null, _emptyUser.Username);
            _emptyUser.Password = null;
            Assert.AreEqual(null, _emptyUser.Password);
        }

        [TestMethod]
        public void TestSensorDataId()
        {
            _fullSensorData.Id = 2;
            Assert.AreEqual(2, _fullSensorData.Id);
        }

        [TestMethod]
        public void TestFullSensorData()
        {
            _fullSensorData.GrassLengt = 20;
            Assert.AreEqual(20, _fullSensorData.GrassLengt);
        }

        [TestMethod]
        public void TestEmptySensorData()
        {
            _emptySensorData.GrassLengt = 0;
            Assert.AreEqual(0, _emptySensorData.GrassLengt);
        }

        #endregion

        #endregion

        #region TestSensor
        
        [TestMethod]
        public void TestSensor()
        {
            _measurement.Compound = "Something";
            Assert.AreEqual("Something", _measurement.Compound);
            _measurement.MeasurementValue = 15.3;
            Assert.AreEqual(15.3, _measurement.MeasurementValue);
            //_measurement.MeasureTime = new DateTime(2020,05,18,00,00,00);
            
            
        }

        [TestMethod]
        public void TestSensorDateTime()
        {
            Assert.AreEqual(new DateTime(2020,05,18,00,00,00), _fullSensorData.Time);
        }

        [TestMethod]
        public void TestToString()
        {
            _measurement.Compound = "AnotherThing";
            _measurement.MeasurementValue = 20.5;
            _measurement.MeasureTime = new DateTime(2020,05,18,00,00,00);

            _measurement.ToString();
            Assert.AreEqual(_measurement.MeasureTime + " " +  _measurement.Compound + " " + _measurement.MeasurementValue, _measurement.ToString());
        }

        #endregion

        #region TestUDPReciever

        [TestMethod]
        public void TestFullUDP()
        {
            _fullUdpSensordata.GrassLengt = 20;
            Assert.AreEqual(20, _fullUdpSensordata.GrassLengt);
            Assert.AreEqual(new DateTime(2020,05,18,00,00,00) , _fullUdpSensordata.Time);
        }

        [TestMethod]
        public void TestEmptyUDP()
        {
            _emptyUdpSensordata.GrassLengt = 0;
            Assert.AreEqual(0, _emptyUdpSensordata.GrassLengt);
        }

        #endregion
    }
}
