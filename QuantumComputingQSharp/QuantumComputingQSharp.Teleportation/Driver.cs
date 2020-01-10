using System;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using static System.Console;

namespace QuantumComputingQSharp.Teleportation
{
    class Driver
    {
        static async Task Main(string[] args)
        {
            Random randomGenerator = new System.Random();
            using (var simulator = new QuantumSimulator())
            {
                for (int i = 0; i < 10; i++)
                {
                    bool randomMessage = randomGenerator.Next(0, 2) == 1;
                    bool result = await TeleportationQ.Run(simulator, randomMessage);
                    WriteLine($"Teleported ({randomMessage}) resulted in ({result})");
                }
            }

            ReadKey();
        }
    }
}