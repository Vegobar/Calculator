using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;

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

        [Test]
        public void Power_Little_number_first()
        {
            Assert.That(uut.Power(100, -3), Is.EqualTo(1e-6).Within(1e-7));
        }

        [Test]
        public void Power_Little_number_second()
        {
            Assert.That(uut.Power(20, -6), Is.EqualTo(1.56e-8).Within(1e-9));
        }

        [Test]
        public void Power_Little_number_third()
        {
            Assert.That(uut.Power(30, -4), Is.EqualTo(1.2e-6).Within(1e-7));
        }


        [TestCase(20,10,2,900)]
        [TestCase(10,2,3,1728)]
        [TestCase(10,25,5, 52521875)]
        public void Accumulator_Add_Power(double x, double y, double exp, double result)
        {
            uut.Add(x, y);
            Assert.That(uut.Power(exp), Is.EqualTo(result));
        }

        [Test]
        public void Accumulator_Subtract_power_first()
        {
            uut.Subtract(100, 20);
            Assert.That(uut.Power(0.5), Is.EqualTo(8.944).Within(0.0005));
        }

        [Test]
        public void Accumulator_Subtract_power_second()
        {
            uut.Subtract(40, 5);
            Assert.That(uut.Power(2), Is.EqualTo(1225));
        }
        [Test]
        public void Accumulator_Subtract_power_third()
        {
            uut.Subtract(50, 12);
            Assert.That(uut.Power(6), Is.EqualTo(3010936384));
        }

        [TestCase(50,2,3,15625)]
        [TestCase(90,5,5, 1889568)]
        [TestCase(100,20,4,625)]
        public void Accumulator_Divide_Power(double x, double y, double exp, double result)
        {
            uut.Divide(x, y);
            Assert.That(uut.Power(exp), Is.EqualTo(result));
        }

        [TestCase(20,4,5, 3.2768e9)]
        [TestCase(6,9,5, 459165024)]
        [TestCase(20,50,2, 1000000)]
        public void Accumulator_Multipy_Power(double x, double y, double exp, double result)
        {
            uut.Multiply(x, y);
            Assert.That(uut.Power(exp), Is.EqualTo(result));
        }

        [TestCase(4,4,4, 4294967296)]
        [TestCase(10,2,3, 1000000)]
        [TestCase(3,5,2, 59049)]
        public void Accumulator_Power_Power(double x, double y, double exp, double result)
        {
            uut.Power(x, y);
            Assert.That(uut.Power(exp), Is.EqualTo(result));
        }

        //Testing Power expection
        [TestCase(-1,0.9)]
        [TestCase(0,100)]
        [TestCase(-5,-0.5)]
        public void Test_exception_power(double x, double exp)
        {
            Assert.That(() => uut.Power(x, exp), Throws.TypeOf<ArgumentException>());
        }

        //Testing cascade Power expection
        [TestCase(5)]
        [TestCase(0.5)]
        [TestCase(3)]
        public void Test_cascade_exception_power(double x)
        {
            Assert.That(() => uut.Power(x), Throws.TypeOf<ArgumentException>());
        }

        //Testing Divide

        [TestCase(5, 2, 2.5)]
        [TestCase(5, -1, -5)]
        [TestCase(2,0.5,4)]
        public void Divide_Them_Numbers(double x, double y, double expected)
        {
            //Arrange in Setup

            //Act + Assert
            Assert.That(uut.Divide(x, y), Is.EqualTo(expected));
        }

        [TestCase(2,0)]
        [TestCase(-5,0)]
        [TestCase(4.5,0)]
        public void Divide_With_Zero_and_Die(double x, double y)
        {
            Assert.That(() => uut.Divide(x, y), Throws.TypeOf<DivideByZeroException>());
        }

        [TestCase(5, 2, 0)]
        [TestCase(10, 6, 0)]
        [TestCase(4.5, 3.5, 0)]
        public void Divide_Cascade_With_Zero_and_Die(double x, double y, double divider)
        {
            uut.Add(x, y);
            Assert.That(() => uut.Divide(divider), Throws.TypeOf<DivideByZeroException>());
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

        [TestCase(5, 2, 2.5,1)]
        [TestCase(4.5,2.5,1.8,1)]
        [TestCase(-8,2,-2,2)]
        public void Divide_For_Real(double x, double y, double z, double result)
        {
            uut.Divide(x, y);
            uut.Divide(z);
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


        [TestCase(45, 24, 7, 3,9)]
        [TestCase(-100,50,50,7,-21)]
        [TestCase(5.5,2.5,2,3,4.5)]
        public void Single_Parameter_Fun(double x, double y, double w,double z, double result)
        {
            uut.Add(x);
            uut.Subtract(y);
            uut.Divide(w);
            uut.Multiply(z);

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