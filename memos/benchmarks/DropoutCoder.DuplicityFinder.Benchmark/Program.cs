﻿using System;
using BenchmarkDotNet.Running;

namespace DropoutCoder.DuplicityFinder.Benchmark
{
    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DuplicityFinderBenchmark>();
            Console.ReadLine();
        }
    }
}
