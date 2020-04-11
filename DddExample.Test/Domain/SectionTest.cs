using DddExample.Domain.Models;
using DddExample.Test.Utility;
using NUnit.Framework;

namespace DddExample.Test.Domain
{
    public class SectionTest
    {
        [TestCase("")]
        [TestCase(" ")]
        public void Ctor_NameTooShort_ValidationError(string name)
        {
            ValidationResultAssert.FirstError(
                nameof(Section.Name),
                "Too short.",
                () => new Section(name));
        }
    }
}