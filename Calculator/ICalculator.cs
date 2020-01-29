﻿namespace Calculator
{
    public interface ICalculator
    {
        double Add(double a, double b);

        double Subtract(double a, double b);

        double Multiply(double a, double b);

        double Power(double x, double exp);
    }
}