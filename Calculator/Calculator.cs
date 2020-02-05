﻿using System;
using System.Linq.Expressions;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public double Accumulator { get; private set; }

        public double Add(double a, double b)
        {
            return (Accumulator += (a + b));
        }

        public double Add(double addend)
        {
            return (Accumulator += addend);
        }

        public double Subtract(double a, double b)
        {
            return (Accumulator += (a - b));
        }

        public double Subtract(double subtractor)
        {
            return (Accumulator -= subtractor);
        }

        public double Multiply(double multiplier)
        {
            return (Accumulator *= multiplier);
        }

        public double Multiply(double a, double b)
        {
            return (Accumulator += (a * b));
        }

        public double Power(double exponent)
        {

            if (Accumulator == 0)
            {
                throw new ArgumentException("Accumulator shouldn't be zero");
            }
            else if (Accumulator < 0)
            {
                throw new ArgumentException("Accumulator and exponent returns NaN");
            }
            
            return Accumulator = Math.Pow(Accumulator, exponent);
        }

        public double Power(double x, double exp)
        {
            if (x == 0) //Removed exp == 0, because its OK to take exp of 0.
            {
                throw new ArgumentException("x shouldn't be zero");
            }

            if (x < 0 && exp < 1)
            {
                throw new ArgumentException("x and exp returns NaN");
            }
            Accumulator = Math.Pow(x, exp);
            return Math.Pow(x, exp);
        }

        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                throw new System.DivideByZeroException();
            }

            return (Accumulator = (dividend / divisor));
        }

        public double Divide(double divisor)
        {
            if (divisor == 0)
            {
                throw new System.DivideByZeroException();
            }

            return (Accumulator = (Accumulator / divisor));
        }

        public void Clear()
        {
            Accumulator = 0;
        }
    }
}