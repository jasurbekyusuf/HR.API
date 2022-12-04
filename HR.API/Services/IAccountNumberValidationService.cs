//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

namespace HR.API.Services
{
    public interface IAccountNumberValidationService
    {
        bool IsValid(string accountNumber);
    }
}
