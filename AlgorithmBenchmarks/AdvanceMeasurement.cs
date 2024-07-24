using Algorithms;
using BenchmarkDotNet.Attributes;

namespace AlgorithmBenchmarks
{
    public class AdvanceMeasurement
    {

        [Benchmark]
        public void TestReverseString_V1() => ReverseString.Execute("adcdefghijklmnop");

        [Benchmark]
        public void TestReverseString_V2() => ReverseString.Execute_V2("adcdefghijklmnop");

    }
}
