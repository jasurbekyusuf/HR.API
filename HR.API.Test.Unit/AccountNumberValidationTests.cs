//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.API.Services;
using Xunit;

namespace HR.API.Test.Unit
{
    public class AccountNumberValidationTests
    {
        private readonly AccountNumberValidationService validationSvc;

        public AccountNumberValidationTests() => validationSvc = new AccountNumberValidationService();

        [Fact]
        public void IsValidAccountNumberReturnsTrue() 
        {
            Assert.True(validationSvc.IsValid("123-1234567890-98"));
        }

        [Theory]
        [InlineData("1234-1234567890-98")]
        [InlineData("1-1234567890-98")]
        public void IsValidFirstPartIsWrongReturnsFalse(string accountNumber) 
        {
            Assert.False(validationSvc.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("1234-12df567890-98")]
        [InlineData("1-12345678214324543590-98")]
        public void IsValidMiddlePartIsWrongReturnsFalse(string accountNumber)
        {
            Assert.False(validationSvc.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("123-1234567890-9")]
        [InlineData("123-1234567890 - 98")]
        public void IsValidLastPartIsWrongReturnsFalse(string accountNumber)
        {
            Assert.False(validationSvc.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("123-1234567890 19")]
        [InlineData("123+1234567890 - 98")]
        public void IsValidDelimetorsThrowsArgumentException(string accountNumber)
        {
            Assert.Throws<ArgumentException>(() => validationSvc.IsValid(accountNumber));
        }
    }
}
