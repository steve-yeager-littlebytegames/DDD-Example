using DddExample.Domain.Models;
using DddExample.Test.Utility;
using NUnit.Framework;

namespace DddExample.Test.Domain
{
    public class StepTest
    {
        [Test]
        public void Ctor_NoIngredients_ReturnStep()
        {
            Assert.DoesNotThrow(() => new Step("test", null));
        }

        [Test]
        public void Ctor_HasIngredients_ReturnStep()
        {
            var ingredients = new[] {new Ingredient("A", new Quantity(1, "C"))};
            Assert.DoesNotThrow(() => new Step("test", ingredients));
        }

        [TestCase("")]
        [TestCase(" ")]
        public void Ctor_EmptyInstruction_ValidationError(string instruction)
        {
            ValidationResultAssert.FirstError(
                nameof(Step.Instruction),
                "Can't be empty.",
                () => new Step(instruction, null));
        }
    }
}