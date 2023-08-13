using static System.Console;

var numbers = new[] { -1, 2, 4, -3, 5, 2, -5, 2 };

var bestSum = 0;

for (int a = 0; a < numbers.Length; a++)
{
    for (int b = a; b < numbers.Length; b++)
    {
        var currentSum = 0;
        for (int k = a; k <= b; k++)
        {
            currentSum += numbers[k];
        }
        bestSum = Math.Max(bestSum, currentSum);
    }
}

WriteLine(bestSum);