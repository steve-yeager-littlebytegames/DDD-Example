using DddExample.Domain.Validation;
using NUnit.Framework;

namespace DddExample.Test.Validation
{
    public class ValidationResultsTest
    {
        private const string Key = "key";
        private static readonly ValidationError error = new ValidationError("test");

        private ValidationResults testObj;

        [SetUp]
        public void SetUp()
        {
            testObj = new ValidationResults();
        }

        [Test]
        public void AddError_NullValidationResults_NewValidationResultsCreated()
        {
            ValidationResults results = null;

            ValidationResults.AddError(ref results, Key, error);

            Assert.IsNotNull(results);
        }

        [Test]
        public void ThrowIfFailed_Failed_ThrowValidation()
        {
            ValidationResults.AddError(ref testObj, Key, error);

            Assert.Throws<ValidationException>(() => testObj.ThrowIfFailed());
        }

        [Test]
        public void ThrowIfFailed_Success_NoException()
        {
            Assert.DoesNotThrow(() => testObj.ThrowIfFailed());
        }
    }
}