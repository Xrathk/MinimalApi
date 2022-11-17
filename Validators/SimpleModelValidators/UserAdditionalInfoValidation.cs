using Domain.Enums;
using Domain.Models;

namespace Validators.SimpleModelValidators
{
    /// <summary>
    /// Class that handles validation checks for the UserAdditionalInfo model.
    /// </summary>
    public static class UserAdditionalInfoValidation
    {
        /// <summary>
        /// Validates the fields of the user request, then formats them appropriately for database storage.
        /// May fail if user input is not formatted properly.
        /// </summary>
        /// <param name="userInfo">Request body info</param>
        /// <returns>Appropriately formatted UserAdditionalInfo model</returns>
        public static UserAdditionalInfo Validate(UserAdditionalInfo userInfo)
        {
            // Model validations
            ValidateDateOfBirth(userInfo.DateOfBirth);
            ValidateGender(userInfo.Gender);
            ValidateHeight(userInfo.Height);
            ValidateWeight(userInfo.Weight);

            // Return data (validated)
            return userInfo;
        }

        /// <summary>
        /// Asserts that birthday is before current day.
        /// </summary>
        /// <param name="date">Date of birth</param>
        private static void ValidateDateOfBirth(DateOnly date)
        {
            if (date > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new Exception("Date of birth must be in the past or the present day.");
            }
        }

        /// <summary>
        /// Asserts gender is valid.
        /// </summary>
        /// <param name="gender">Gender</param>
        private static void ValidateGender(Gender gender)
        {
            if ((int) gender < 0 || (int) gender >= Enum.GetNames(typeof(Gender)).Length)
            {
                throw new Exception("Gender code is not valid.");
            }
        }

        /// <summary>
        /// Asserts height is above 0.
        /// </summary>
        /// <param name="height">Height</param>
        private static void ValidateHeight(float height)
        {
            if (height < 0)
            {
                throw new Exception("Height must not be negative.");
            }
        }

        /// <summary>
        /// Asserts weight is above 0.
        /// </summary>
        /// <param name="weight">Weight</param>
        private static void ValidateWeight(float weight)
        {
            if (weight < 0)
            {
                throw new Exception("Weight must not be negative.");
            }
        }
    }
}
