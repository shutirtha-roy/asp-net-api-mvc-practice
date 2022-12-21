using NUnit.Framework;
using Shouldly;
using System;

namespace DemoLib.Tests
{
    public class CalculatorTests

    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Category("UnitTest")]
        public void Sum_ValidNumbers_ValidSum()
        {
            int a = 5;
            int b = 7;
            int expected = 12;

            Calculator calculator = new Calculator();
            int result = calculator.Sum(a, b);

            Assert.AreEqual(expected, result);
        }

        [Test, Category("UnitTest")]
        public void Divide_ValidNumbers_ValidResult()
        {
            int a = 10;
            int b = 2;
            int expected = 5;

            Calculator calculator = new Calculator();
            int result = calculator.Divide(a, b);

            Assert.AreEqual(expected, result);
        }

        [Test, Category("UnitTest")]
        public void Divide_InvalidDivisor_ThrowException()
        {
            int a = 5;
            int b = 0;

            Calculator calculator = new Calculator();
            Should.Throw<InvalidOperationException>(() =>
            {
                calculator.Divide(a, b);  
            });
        }
    }
}