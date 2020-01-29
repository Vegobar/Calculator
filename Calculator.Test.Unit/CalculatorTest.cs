﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator uut;

        [SetUp]
        public void SetUp()
        {
            uut = new Calculator();
        }


        [TestCase(2,2,4)]
        [TestCase(-3,2,-1)]
        [TestCase(3.3,8.2,11.5)]
        public void Add_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Add(x, y), Is.EqualTo(expected));
        }

        [TestCase(33,40,-7)]
        [TestCase(85,40,45)]
        [TestCase(77.5,33.4,44.1)]
        [TestCase(-77.5,-33.4,-44.1)]
        public void Subtract_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Subtract(x, y), Is.EqualTo(expected));
        }


        [TestCase(4, 5, 20)]
        [TestCase(-3, 7, -21)]
        [TestCase(7.5, 4.5, 33.75)]
        public void Multiply_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Multiply(x, y), Is.EqualTo(expected));
        }

        [TestCase(2, 0, 1)]
        [TestCase(2, -1, 0.5)]
        [TestCase(3.5, 2, 12.25)]
        public void Power_Them_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Power(x, y), Is.EqualTo(expected)); 
        }
    }
}
