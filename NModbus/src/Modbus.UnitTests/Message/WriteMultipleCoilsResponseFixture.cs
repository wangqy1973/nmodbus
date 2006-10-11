using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Modbus.Message;

namespace Modbus.UnitTests.Message
{
	[TestFixture]
	public class WriteMultipleCoilsResponseFixture
	{
		[Test]
		public void CreateWriteMultipleCoilsResponse()
		{
			WriteMultipleCoilsResponse response = new WriteMultipleCoilsResponse(17, 19, 45);
			Assert.AreEqual(Modbus.WriteMultipleCoils, response.FunctionCode);
			Assert.AreEqual(17, response.SlaveAddress);
			Assert.AreEqual(19, response.StartAddress);
			Assert.AreEqual(45, response.NumberOfPoints);
		}

		[Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void CreateWriteMultipleCoilsResponseTooMuchData()
		{
			new WriteMultipleCoilsResponse(1, 2, Modbus.MaximumDiscreteRequestResponseSize + 1);
		}

		[Test]
		public void CreateWriteMultipleCoilsResponseMaxSize()
		{
			WriteMultipleCoilsResponse response = new WriteMultipleCoilsResponse(1, 2, Modbus.MaximumDiscreteRequestResponseSize);
			Assert.AreEqual(Modbus.MaximumDiscreteRequestResponseSize, response.NumberOfPoints);
		}
	}
}
