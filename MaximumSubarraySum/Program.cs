using MaximumSubarraySum;
using static System.Console;

var benchmarkWith10Elements = new ArrayBenchmark(10);
benchmarkWith10Elements.CalculateAllComplexities();
WriteLine();

var benchmarkWith100Elements = new ArrayBenchmark(100);
benchmarkWith100Elements.CalculateAllComplexities();
WriteLine();

var benchmarkWith1000Elements = new ArrayBenchmark(1000);
benchmarkWith1000Elements.CalculateAllComplexities();
WriteLine();

var benchmarkWith10000Elements = new ArrayBenchmark(10000);
benchmarkWith10000Elements.CalculateAllComplexities();