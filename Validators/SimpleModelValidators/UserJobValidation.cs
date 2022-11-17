using Domain.Enums;
using Domain.Models;

namespace Validators.SimpleModelValidators
{
    /// <summary>
    /// Class that handles validation checks for the UserJob model.
    /// </summary>
    public static class UserJobValidation
    {
        /// <summary>
        /// Validates the fields of the user request, then formats them appropriately for database storage.
        /// May fail if user input is not formatted properly.
        /// </summary>
        /// <param name="userJob">Request body info</param>
        /// <returns>Appropriately formatted UserJob model</returns>
        public static UserJob Validate(UserJob userJob)
        {
            // Model validations
            ValidateYearsOfExperience(userJob.YearsOfExperience);
            ValidateWorkModel(userJob.WorkModel);

            // Return data (validated)
            return userJob;
        }

        /// <summary>
        /// Asserts that years of experience is non-negative.
        /// </summary>
        /// <param name="years">Years</param>
        private static void ValidateYearsOfExperience(int years)
        {
            if (years < 0)
            {
                throw new Exception("Years of experience cannot be negative.");
            }
        }

        /// <summary>
        /// Asserts work model is valid.
        /// </summary>
        /// <param name="workModel">Work model</param>
        private static void ValidateWorkModel(WorkModel workModel)
        {
            if ((int)workModel < 0 || (int)workModel >= Enum.GetNames(typeof(WorkModel)).Length)
            {
                throw new Exception("Work model code is not valid.");
            }
        }

    }
}
