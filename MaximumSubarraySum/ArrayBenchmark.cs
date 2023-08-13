namespace MaximumSubarraySum;

using static Console;
using static Math;

public class ArrayBenchmark
{
    private readonly int[] _numbers;
    private const string CubicComplexityName = "n^3";
    private const string QuadraticComplexityName = "n^2";
    private const string LinearComplexityName = "n^1";
    private const string Microseconds = "microseconds";
    private const string Milliseconds = "milliseconds";
    private const string Seconds = "seconds";
    private const string Minutes = "minutes";

    public ArrayBenchmark(uint elementCount)
    {
        _numbers = Enumerable
            .Range(0, (int)elementCount)
            .Select(_ => new Random().Next(-9, 10))
            .ToArray();
    }

    public void CalculateAllComplexities()
    {
        CalculateCubicComplexity();
        CalculateQuadraticComplexity();
        CalculateLinearComplexity();
    }

    public void CalculateCubicComplexity()
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
        var recalculatedTotalTime = RecalculateTimeSpan(totalTime);
        WriteLine(CreateResult(CubicComplexityName, bestSum, recalculatedTotalTime));
    }

    public void CalculateQuadraticComplexity()
    {
        var bestSum = 0;
        var startTime = DateTime.Now;

        for (int a = 0; a < _numbers.Length; a++)
        {
            var currentSum = 0;
            for (int b = a; b < _numbers.Length; b++)
            {
                currentSum += _numbers[b];
                bestSum = Max(bestSum, currentSum);
            }
        }

        var totalTime = (DateTime.Now - startTime).TotalMicroseconds;
        var recalculatedTotalTime = RecalculateTimeSpan(totalTime);
        WriteLine(CreateResult(QuadraticComplexityName, bestSum, recalculatedTotalTime));
    }

    public void CalculateLinearComplexity()
    {
        var bestSum = 0;
        var currentSum = 0;
        var startTime = DateTime.Now;

        for (int a = 0; a < _numbers.Length; a++)
        {
            currentSum = Max(_numbers[a], currentSum + _numbers[a]);
            bestSum = Max(bestSum, currentSum);
        }

        var totalTime = (DateTime.Now - startTime).TotalMicroseconds;
        var recalculatedTotalTime = RecalculateTimeSpan(totalTime);
        WriteLine(CreateResult(LinearComplexityName, bestSum, recalculatedTotalTime));
    }

    string RecalculateTimeSpan(double timeSpan)
    {
        var timeSpanUnit = Microseconds;
        if (timeSpan > 1000)
        {
            timeSpan /= 1000;
            timeSpanUnit = Milliseconds;
        }

        if (timeSpan > 1000)
        {
            timeSpan /= 1000;
            timeSpanUnit = Seconds;
        }

        if (timeSpan > 60 && timeSpanUnit == Seconds)
        {
            timeSpan /= 60;
            timeSpanUnit = Minutes;
        }

        return $"{timeSpan:N2} {timeSpanUnit}";
    }

    string CreateResult(string algorithmComplexity, int bestSum, string totalTimeWithUnit) =>
        $"O({algorithmComplexity}) best sum='{bestSum}' took {totalTimeWithUnit} with {_numbers.Length} elements.";
}