using System;
using System.Collections.Generic;
 using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

    namespace UserRegistrationLambda
    {
        public class UserRegistrationTestLambda
        {
            string firstNameregex = "^[A-Z]{1}[a-z]{2,}$";
        public bool firstName(string regexfirstName) => Regex.IsMatch(regexfirstName, firstNameregex);
        /// <summary>
        /// FirstName Custom Exception
        /// </summary>
        /// <param name="patternFirstName"></param>
        /// <returns></returns>
        public string firstNameLambda(string regexfirstName)
        {
            bool result = firstName(regexfirstName);
            try
            {
                if (result == false)
                {

                    if (regexfirstName.Equals(string.Empty))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_EMPTY, "FirstName should not be empty");
                    }


                    if (regexfirstName.Length < 3)
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_LESSTHAN_MINIMUM_LENGTH, "FirstName should contains atleast three characters");

                    }

                    if (regexfirstName.Any(char.IsDigit))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_NUMBER, "FirstName should not contains number");
                    }
                    if (!char.IsUpper(regexfirstName[0]))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_LOWERCASE, "FirstName first letter should not be a lowercase");
                    }
                    if (regexfirstName.Any(char.IsLetterOrDigit))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_SPECIAL_CHARACTER, "FirstName should not contains special characters");
                    }

                }
            }
            catch (UserRegistrationTestCustomException exception)
            {
                throw exception;
            }
            return "FirstName is not valid";
        }
    }
}

