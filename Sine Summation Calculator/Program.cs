using System;
using static System.Console;
using static System.Math;

double sum = 0;
WriteLine("Sine Summation Calculator");
Write("Input the value of 'a': ");
double a = Convert.ToDouble(ReadLine());
Write("Input the number of iterations: ");
int n = int.Parse(ReadLine());

for (int i = 1; i <= n; i++)
{
    a = (a * PI) / 180; // Convert 'a' to radians
    double sineValue = Sin(a); // Calculate sin(a)
    sum += sineValue; // Add to the sum
}

WriteLine($"Sum of sine(a) = {Round(sum, 3)}");
