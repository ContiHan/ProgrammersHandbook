namespace MaximumSubarraySum;

using static Console;
using static Math;

public class Calculation
{
    // var numbers = new[] { -1, 2, 4, -3, 5, 2, -5, 2 };
    private readonly int[] _numbers;

    public Calculation(byte exponent)
    {
        _numbers = Enumerable
            .Range(0, (int)Pow(10, exponent))
            .Select(_ => new Random().Next(-10, 11))
            .ToArray();
    }

    public void Calculate()
    {
        var bestSum = 0;
        var startTime = DateTime.Now;
        for (int a = 0; a < _numbers.Length; a++)
        {
            for (int b = a; b < _numbers.Length; b++)
            {
                var currentSum = 0;
                for (int k = a; k <= b; k++)
                {
                    currentSum += _numbers[k];
                }

                bestSum = Max(bestSum, currentSum);
            }
        }

        var totalTime = (DateTime.Now - startTime).TotalMicroseconds;
        var recalculatedTotalTime = RecalculateTime(totalTime);
        WriteLine(CreateResults("n^3", bestSum, recalculatedTotalTime));


        bestSum = 0;
        startTime = DateTime.Now;
        for (int a = 0; a < _numbers.Length; a++)
        {
            var currentSum = 0;
            for (int b = a; b < _numbers.Length; b++)
            {
                currentSum += _numbers[b];
                bestSum = Max(bestSum, currentSum);
            }
        }

        totalTime = (DateTime.Now - startTime).TotalMicroseconds;
        recalculatedTotalTime = RecalculateTime(totalTime);
        WriteLine(CreateResults("n^2", bestSum, recalculatedTotalTime));

        bestSum = 0;
        int sum = 0;
        startTime = DateTime.Now;
        for (int a = 0; a < _numbers.Length; a++)
        {
            sum = Max(_numbers[a], sum + _numbers[a]);
            bestSum = Max(bestSum, sum);
        }

        totalTime = (DateTime.Now - startTime).TotalMicroseconds;
        recalculatedTotalTime = RecalculateTime(totalTime);
        WriteLine(CreateResults("n^1", bestSum, recalculatedTotalTime));
    }


    string RecalculateTime(double timeSpan)
    {
        var timeSpanUnit = "microseconds";
        if (timeSpan > 1000)
        {
            timeSpan /= 1000;
            timeSpanUnit = "milliseconds";
        }

        if (timeSpan > 1000)
        {
            timeSpan /= 1000;
            timeSpanUnit = "seconds";
        }

        if (timeSpan > 60 && timeSpanUnit == "seconds")
        {
            timeSpan /= 60;
            timeSpanUnit = "minutes";
        }

        return $"{timeSpan:N2} {timeSpanUnit}";
    }

    string CreateResults(string algorithmComplexity, int bestSum, string totalTimeWithUnit) =>
        $"O({algorithmComplexity}) best sum='{bestSum}' took {totalTimeWithUnit} with {_numbers.Length} elements.";
}