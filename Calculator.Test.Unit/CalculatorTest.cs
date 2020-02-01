using NUnit.Framework;
using System;

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

        //Testing add

        [TestCase(2, 2, 4)]
        [TestCase(-3, 2, -1)]
        [TestCase(3.3, 8.2, 11.5)]
        public void Add_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Add(x, y), Is.EqualTo(expected));
        }

        //Testing Subtract

        [TestCase(33, 40, -7)]
        [TestCase(85, 40, 45)]
        [TestCase(77.5, 33.4, 44.1)]
        [TestCase(-77.5, -33.4, -44.1)]
        public void Subtract_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Subtract(x, y), Is.EqualTo(expected));
        }

        //Testing multiply

        [TestCase(4, 5, 20)]
        [TestCase(-3, 7, -21)]
        [TestCase(7.5, 4.5, 33.75)]
        public void Multiply_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Multiply(x, y), Is.EqualTo(expected));
        }

        //Testing power

        [TestCase(2, 0, 1)]
        [TestCase(2, -1, 0.5)]
        [TestCase(3.5, 2, 12.25)]
        public void Power_Them_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Power(x, y), Is.EqualTo(expected));
        }

        [TestCase(100, -3, 1e-6)]
        public void Power_Little_number(double x, double y, double expected)
        {
            Assert.That(uut.Power(x, y), Is.EqualTo(expected).Within(1e-7));
        }

        [Test]
        public void Accumulator_Add_Power()
        {
            uut.Add(20, 10);
            Assert.That(uut.Power(2), Is.EqualTo(900));
        }

        [Test]
        public void Accumulator_Subtract_power()
        {
            uut.Subtract(100, 20);
            Assert.That(uut.Power(0.5), Is.EqualTo(8.944).Within(0.0005));
        }

        [Test]
        public void Accumulator_Divide_Power()
        {
            uut.Divide(50, 2);
            Assert.That(uut.Power(3), Is.EqualTo(15625));
        }

        [Test]
        public void Accumulator_Multipy_Power()
        {
            uut.Multiply(20, 4);
            Assert.That(uut.Power(5), Is.EqualTo(3.2768e9));
        }

        [Test]
        public void Accumulator_Power_Power()
        {
            uut.Power(4, 4);
            Assert.That(uut.Power(4), Is.EqualTo(4294967296));
        }

        //Testing Divide

        [TestCase(5, 2, 2.5)]
        [TestCase(5, -1, -5)]
        public void Divide_Them_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Divide(x, y), Is.EqualTo(expected));
        }

        [Test]
        public void Divide_With_Zero_and_Die()
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(() => uut.Divide(2, 0), Throws.TypeOf<DivideByZeroException>());
        }

        //Testing accumulator

        [TestCase(2, 0)]
        [TestCase(2, 2)]
        [TestCase(-2, 2)]
        [TestCase(-2, -2)]
        public void test_accumulator_when_adding(double x, double y)
        {
            Assert.That(uut.Add(x, y), Is.EqualTo(uut.Accumulator));
        }

        [TestCase(2, 0)]
        [TestCase(2, 2)]
        [TestCase(-2, 2)]
        [TestCase(-2, -2)]
        [TestCase(2.5, 3.5)]
        public void test_clear_accumulator(double x, double y)
        {
            uut.Add(x, y);
            uut.Clear();

            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }

        [TestCase(2, 0)]
        [TestCase(2, 2)]
        [TestCase(-2, 2)]
        [TestCase(-2, -2)]
        [TestCase(2.5, 3.5)]
        public void test_clear_accumulator_sub(double x, double y)
        {
            uut.Subtract(x, y);
            uut.Clear();

            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }

        [TestCase(2, 2, 3,12)]
        [TestCase(2.5,4.5,3,33.75)]
        [TestCase(-4,2,-5,40)]
        public void Multiply_For_Real(double x, double y, double z, double result)
        {
            uut.Multiply(x, y);
            uut.Multiply(z);
            Assert.That(uut.Accumulator,Is.EqualTo(result));
        }

        [TestCase(47, 92, -3, -42)]
        [TestCase(-3, 6, -9, 0)]
        [TestCase(9.7,5.5,2.2, 1.9999999999999991)]
        public void Subtract_For_Real(double x, double y, double z, double result)
        {
            uut.Subtract(x, y);
            uut.Subtract(z);
            Assert.That(uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(5, 3, 7,14)]
        [TestCase(-2,6,2,-16)]
        [TestCase(2,4.5,2,-5)]
        public void Subtract_Multipli_Mix(double x, double y, double z, int result)
        {
            uut.Add(x);
            uut.Subtract(y);
            uut.Multiply(z);

            Assert.That(uut.Accumulator,Is.EqualTo(result));
        }


        [TestCase(45, 24, 7, 3,3)]
        public void Single_Parameter_Fun(double x, double y, double w,double z, int result)
        {
            //uut.Clear();
            uut.Add(x);
            uut.Subtract(y);
            uut.Divide(w);
            //uut.Multiply(z);

            Assert.That(uut.Accumulator, Is.EqualTo(result));
        }




        [TestCase(2, 0)]
        [TestCase(2, 2)]
        [TestCase(-2, 2)]
        [TestCase(-2, -2)]
        [TestCase(2.5, 3.5)]
        public void test_clear_accumulator_multi(double x, double y)
        {
            uut.Multiply(x, y);
            uut.Clear();

            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }

        [TestCase(2, 2)]
        [TestCase(-2, 2)]
        [TestCase(-2, -2)]
        [TestCase(2.5, 3.5)]
        public void test_clear_accumulator_divide(double x, double y)
        {
            uut.Divide(x, y);
            uut.Clear();

            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }

        [TestCase(2, 2)]
        [TestCase(-3, 2)]
        [TestCase(3.3, 8.2)]
        public void testing_cascade_call_for_add(double x, double y)
        {
            uut.Add(x);
            uut.Add(x, y);

            Assert.That(uut.Accumulator, Is.InRange(x + x + y - 0.1, x + x + y + 0.1));
        }

        [TestCase(4, 5)]
        [TestCase(-3, 7)]
        [TestCase(7.5, 4.5)]
        public void testing_cascade_call_for_multi(double x, double y)
        {
            uut.Multiply(x, y);
            uut.Multiply(x);

            Assert.That(uut.Accumulator, Is.EqualTo((x * y) * x));
        }
    }
}