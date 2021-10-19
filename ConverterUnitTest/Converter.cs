using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterTest
{
	// Task:
	//
	// We have designed a new magical number system called "alpha-end".  This number system is 
	// similar to hexadecimal but has the following characters:  0 1 2 3 4 5 6 7 8 9 x y z
	// (basically the decimal number system plus the 3 characters x, y and z)
	//
	// Therefore converting from decimal to alpha-end gives the following:
	//    5   =>   5
	//    10  =>   x
	//    13  =>   10
	//    20  =>   17
	//
	// Your task is to implement the Converter.Convert method for this new number system to get all the 
	// unit tests passing.  Feel free to add more unit tests as you work if it helps you test drive to the goal.
	// You will be judged based on the accuracy and design of your code.
	//
	// Good luck!
	//
	// Extra challenge:
	// Try extending from your Converter to support other number systems such as binary, octal and hexadecimal.  
	// Is there an easy way to refactor your code/algorithm to support this?
	public class Converter
	{
		public string Convert(int number)
		{
			throw new NotImplementedException();
		}

	}

	[TestClass]
	public class ConverterTests
	{
		[TestMethod]
		public virtual void TestsForAlphaEndConversions()
		{
			Assert.AreEqual("5", new Converter().Convert(5));
			Assert.AreEqual("x", new Converter().Convert(10));
			Assert.AreEqual("10", new Converter().Convert(13));
			Assert.AreEqual("17", new Converter().Convert(20));
			Assert.AreEqual("2381", new Converter().Convert(5006));
			Assert.AreEqual("20z1879", new Converter().Convert(9999999));
		}

		[TestMethod]
		public virtual void TestsForExtraChallenge()
		{
			Assert.AreEqual("111", new BinaryConverter().Convert(7));
			Assert.AreEqual("55", new OctalConverter().Convert(45));
			Assert.AreEqual("1f", new HexConverter().Convert(31));
		}
	}
}
