//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

namespace HR.API.Services
{
    public class AccountNumberValidationService : IAccountNumberValidationService
    {
        private const int startingPartLength = 3;
        private const int middlePartLength = 10;
        private const int lastpartLength = 2;
        public bool IsValid(string accountNumber)
        {
            var firstDelimiter = accountNumber.IndexOf('-');
            var secondDelimiter = accountNumber.LastIndexOf("-");
            if (firstDelimiter == -1 || secondDelimiter == firstDelimiter)
                throw new ArgumentException();
            
            var firstPart = accountNumber.Substring(0, firstDelimiter);
            if (firstPart.Length != startingPartLength)
                return false;
            
            var tempPart = accountNumber.Remove(0, startingPartLength + 1);
            var middlePart = tempPart.Substring(0, tempPart.IndexOf("-"));
            if(middlePart.Length != middlePartLength)
                return false;

            var lastPark = accountNumber.Substring(secondDelimiter + 1);
            if(lastPark.Length != lastpartLength)
                return false;

            return true;
        }
    }
}
