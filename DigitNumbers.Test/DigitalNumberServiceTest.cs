using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalNumbers.Business;
using System.Linq;

namespace DigitNumbers.Test
{
	[TestClass]
	public class DigitalNumberServiceTest
	{
		private DigitalNumberService _service;

		[TestInitialize]
		public void Init()
		{
			_service = new DigitalNumberService();
		}

		[TestMethod]
		public void TestOperations()
		{
			try
			{
				var inputs = new List<string>() { "1,12" , "2,12" };

				var result = _service.GenerateDigitalNumbers(inputs);

				Assert.AreEqual(2, result.Count());

				var first = result.FirstOrDefault();
				Assert.IsNotNull(first);

				var last = result.LastOrDefault();
				Assert.IsNotNull(last);

				//Valida el #1
				Assert.AreEqual("|", first[1, 2]);
				Assert.AreEqual("|", first[3, 2]);
				//Valida el #2
				Assert.AreEqual("-", first[0, 4]);
				Assert.AreEqual("|", first[1, 5]);
				Assert.AreEqual("-", first[2, 4]);
				Assert.AreEqual("|", first[3, 3]);
				Assert.AreEqual("-", first[4, 4]);

				//Valida el #1
				Assert.AreEqual("|", last[1, 3]);
				Assert.AreEqual("|", last[2, 3]);
				Assert.AreEqual("|", last[4, 3]);
				Assert.AreEqual("|", last[5, 3]);
				//Valida el #2
				Assert.AreEqual("-", last[0, 5]);
				Assert.AreEqual("-", last[0, 6]);
				Assert.AreEqual("|", last[1, 7]);
				Assert.AreEqual("|", last[2, 7]);
				Assert.AreEqual("-", last[3, 5]);
				Assert.AreEqual("-", last[3, 6]);
				Assert.AreEqual("|", last[4, 4]);
				Assert.AreEqual("|", last[5, 4]);
				Assert.AreEqual("-", last[6, 5]);
				Assert.AreEqual("-", last[6, 6]);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
