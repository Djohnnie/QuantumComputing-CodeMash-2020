using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using static System.Console;

namespace QuantumComputingQSharp.Entanglement
{
    class Driver
    {
        static async Task Main(string[] args)
        {
            using var quantumSimulator = new QuantumSimulator();

            WriteLine("Result from Quantum Script");

            for (int i = 0; i < 100; i++)
            {
                var result = await EntanglementQ.Run(quantumSimulator);
                WriteLine(result);
            }

            ReadKey();
        }
    }
}