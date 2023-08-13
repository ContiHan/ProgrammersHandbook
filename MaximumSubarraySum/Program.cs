using MaximumSubarraySum;

var benchmarkWith10Elements = new ArrayBenchmark(10);
benchmarkWith10Elements.CalculateAllComplexities();

var benchmarkWith100Elements = new ArrayBenchmark(100);
benchmarkWith100Elements.CalculateAllComplexities();

var benchmarkWith1000Elements = new ArrayBenchmark(1000);
benchmarkWith1000Elements.CalculateAllComplexities();