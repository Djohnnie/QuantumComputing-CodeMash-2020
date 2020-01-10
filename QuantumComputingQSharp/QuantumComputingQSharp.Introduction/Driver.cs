using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using static System.Console;

namespace QuantumComputingQSharp.Introduction
{
    class Driver
    {
        static async Task Main(string[] args)
        {
            using var quantumSimulator = new QuantumSimulator();
            var result = await IntroductionQ.Run(quantumSimulator);
            WriteLine($"Result from Quantum Script: {result}");

            ReadKey();
        }
    }
}