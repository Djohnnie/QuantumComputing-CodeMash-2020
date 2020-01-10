using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using static System.Console;

namespace QuantumComputingQSharp.Superposition
{
    class Driver
    {
        static async Task Main(string[] args)
        {
            using var quantumSimulator = new QuantumSimulator();

            int timesFalse = 0;
            int timesTrue = 0;

            for (int i = 0; i < 1000; i++)
            {
                var result = await SuperpositionQ.Run(quantumSimulator);

                if (result)
                {
                    timesTrue++;
                }
                else
                {
                    timesFalse++;
                }
            }

            WriteLine("Result from Quantum Script");
            WriteLine($"Times False: {timesFalse / 10.0:F1}");
            WriteLine($"Times True: {timesTrue / 10.0:F1}");

            ReadKey();
        }
    }
}