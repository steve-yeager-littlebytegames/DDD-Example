using DddExample.Domain.Validation;
using NUnit.Framework;

namespace DddExample.Test.Utility
{
    public static class ValidationResultAssert
    {
        public static void FirstError(string key, string message, TestDelegate code)
        {
            var exception = Assert.Throws<ValidationException>(code);
            Assert.AreEqual(message, exception.Errors[key][0].Message);
        }
    }
}