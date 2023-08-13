namespace MaximumSubarraySum;

using static Console;
using static Math;

public class ArrayBenchmark
{
    private readonly int[] _numbers;

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
        WriteLine(CreateResults("n^3", bestSum, recalculatedTotalTime));
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
        WriteLine(CreateResults("n^2", bestSum, recalculatedTotalTime));
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
        WriteLine(CreateResults("n^1", bestSum, recalculatedTotalTime));
    }

    string RecalculateTimeSpan(double timeSpan)
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