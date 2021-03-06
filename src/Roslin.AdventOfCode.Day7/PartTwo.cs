using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Roslin.AdventOfCode.Common;

namespace Roslin.AdventOfCode.Day7
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_be_able_to_follow_all_instructions()
        {
            const string wire = "a";
            var readInput = Input.Read("Roslin.AdventOfCode.Day7.input.txt", Assembly.GetExecutingAssembly()).ToList();

            var instructions = readInput.Select(input => (Instruction)input).ToList();

            var wireCircuit = new WireCircuit{ Instructions = instructions };
            wireCircuit.SendSignalsUntilGivenGateIsCompleted(wire);
            var wireA = wireCircuit.UltimatelySignals[wire];

            var intructionsForRoundTwo = readInput.Select(input => (Instruction)input).ToList();
            intructionsForRoundTwo.First(x => x.Result == "b").Gate.X = wireA.ToString();

            var circuit = new WireCircuit {Instructions = intructionsForRoundTwo };
            circuit.SendSignalsUntilGivenGateIsCompleted(wire);
            
            circuit.UltimatelySignals[wire].Should().Be(14134);
        }

        [Test]
        public void Should_be_able_to_update_instruction()
        {
            Instruction i = "10 -> b";
            i.CalculateResult().Should().Be(10);

            i.Gate.X = "12";
            i.CalculateResult().Should().Be(12);
        }
    }
}