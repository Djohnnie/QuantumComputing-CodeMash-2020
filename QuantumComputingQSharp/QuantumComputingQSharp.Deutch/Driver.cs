using System;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using static System.Console;

namespace QuantumComputingQSharp.Deutch
{
    class Driver
    {
        static async Task Main(string[] args)
        {
            using (var simulator = new QuantumSimulator())
            {
                await RunDeutschTestConstantZero(simulator);
                await RunDeutschTestConstantOne(simulator);
                await RunDeutschTestIdentity(simulator);
                await RunDeutschTestNegation(simulator);
            }

            ReadKey();
        }

        private static async Task RunDeutschTestConstantZero(QuantumSimulator simulator)
        {
            var result = await DeutschTestConstantZero.Run(simulator);
            CheckResult(result, "Constant-Zero");
        }

        private static async Task RunDeutschTestConstantOne(QuantumSimulator simulator)
        {
            var result = await DeutschTestConstantOne.Run(simulator);
            CheckResult(result, "Constant-One");
        }

        private static async Task RunDeutschTestIdentity(QuantumSimulator simulator)
        {
            var result = await DeutschTestIdentity.Run(simulator);
            CheckResult(result, "Identity");
        }

        private static async Task RunDeutschTestNegation(QuantumSimulator simulator)
        {
            var result = await DeutschTestNegation.Run(simulator);
            CheckResult(result, "Negation");
        }

        private static void CheckResult((bool, bool) result, String operation)
        {
            if (result.Item1 && result.Item2)
            {
                WriteLine($"The {operation} function is CONSTANT ({result})");
            }
            else if (!result.Item1 && result.Item2)
            {
                WriteLine($"The {operation} function is VARIABLE ({result})");
            }
            else
            {
                WriteLine($"SOMETHING IS WRONG  ({result})");
            }
        }
    }
}