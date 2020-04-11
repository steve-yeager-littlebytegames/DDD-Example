using System;
using DddExample.Domain.Validation;
using NUnit.Framework;

namespace DddExample.Test.Validation
{
    public class ValidationErrorTest
    {
        [TestCase("")]
        [TestCase(" ")]
        public void Ctor_EmptyMessage_ThrowArgument(string message)
        {
            Assert.Throws<ArgumentException>(() => new ValidationError(message));
        }
    }
}