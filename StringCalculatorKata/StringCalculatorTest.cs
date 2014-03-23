using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculatorKata
{
    class StringCalculatorTest
    {
        private StringCalculator stringCalculator;

        [SetUp]
        public void ConstructStringCalculator()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void stringCalculatorAdd_EmptyStringReturns0() 
        {
            Assert.That(stringCalculator.Add(string.Empty), Is.EqualTo(0));
        }

        [Test]
        public void AddOneNumber_ReturnsNumber()
        {
            Assert.That(stringCalculator.Add("5"), Is.EqualTo(5));
        }

    }
}
