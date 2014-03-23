using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace StringCalculatorKata
{
    class StringCalculatorTest
    {
        private StringCalculator stringCalculator;
        private Mock<ILogger> loggerMock;

        [SetUp]
        public void ConstructStringCalculator()
        {
            loggerMock = new Mock<ILogger>(MockBehavior.Strict);

            stringCalculator = new StringCalculator(loggerMock.Object);

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

        [Test]
        public void AddRandomAmountOfNumbers()
        {
            var randomInts = GenerateIntegerList(new Random().Next(100));
            var numberString = GenerateCommaSeparatedNumberString(randomInts);
            var sum = randomInts.Sum();
            Assert.That(stringCalculator.Add(numberString), Is.EqualTo(sum));
        }

        [Test]
        public void AddNumbersDelimitedWithLineBreak_ReturnsSum()
        {
            Assert.That(stringCalculator.Add("1\n2,3"), Is.EqualTo(6));
        }

        [Test]
        public void AddNumbers_LoggerPrintsResult()
        {
            loggerMock.Setup(s => s.Write(It.IsAny<string>()));
            stringCalculator.Add("1,2,3");
            loggerMock.Verify(l => l.Write("6"));
        }


        private string GenerateCommaSeparatedNumberString(IEnumerable<int> randomInts)
        {
            var result = randomInts.Aggregate("", (current, number) => current + (number + ", "));
            result.TrimEnd(' ');
            result.TrimEnd(',');
            return result; 
        }
        

        private IEnumerable<int> GenerateIntegerList(int quantity)
        {
            var numbers = new int[quantity];
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = new Random().Next(100);
            }
            return numbers; 
        }

    }
}
