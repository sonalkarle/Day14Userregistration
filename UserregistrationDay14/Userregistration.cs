using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace UserRegistrationLambda
{
    public class UserRegistrationTestLambda
    {
        //Regex pattern
        string firstNameregex = "^[A-Z]{1}[a-z]{2,}$";
        string lastNameregex = "^[A-Z]{1}[a-z]{2,}$";
        string emailregex = "^[0-9a-zA-Z]+([._+-]?[0-9a-zA-Z]+)*@[0-9A-Za-z]+.([c]{1}[o]{1}[m]{1})*([n]{1}[e]{1}[t]{1})*[,]*([.][a]{1}[u]{1})*([.][c]{1}[o]{1}[m]{1})*$";
        string mobileNumberregex = "^[9]{1}[1]{1}[ ][0-9]{10}$";
        string passwordregex = "^[A-Z]{1}[a-zA-Z]{7,}([0-9]+)[@#$%^&*+-_]{1}$";

        public bool firstName(string patternFirstName) => Regex.IsMatch(patternFirstName, firstNameregex);
        public bool lastName(string patternLastName) => Regex.IsMatch(patternLastName, lastNameregex);
        public bool mobileNumber(string patternMobileNumber) => Regex.IsMatch(patternMobileNumber, mobileNumberregex);
        public bool password(string patternPassword) => Regex.IsMatch(patternPassword, passwordregex);
        public bool email(string patternEmail) => Regex.IsMatch(patternEmail, emailregex);


        /// <summary>
        /// FirstName Custom Exception
        /// </summary>
        /// <param name="patternFirstName"></param>
        /// <returns></returns>
        public string firstNameLambda(string patternFirstName)
        {
            bool result = firstName(patternFirstName);
            try
            {
                if (result == false)
                {

                    if (patternFirstName.Equals(string.Empty))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_EMPTY, "FirstName should not be empty");
                    }


                    if (patternFirstName.Length < 3)
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_LESSTHAN_MINIMUM_LENGTH, "FirstName should contains atleast three characters");

                    }

                    if (patternFirstName.Any(char.IsDigit))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_NUMBER, "FirstName should not contains number");
                    }
                    if (!char.IsUpper(patternFirstName[0]))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_LOWERCASE, "FirstName first letter should not be a lowercase");
                    }
                    if (patternFirstName.Any(char.IsLetterOrDigit))
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

        /// <summary>
        /// LastName Custom Exception
        /// </summary>
        /// <param name="patternLastName"></param>
        /// <returns></returns>
        public string lastNameLambda(string patternLastName)
        {
            bool result = lastName(patternLastName);
            try
            {
                if (result == false)
                {

                    if (patternLastName.Equals(string.Empty))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_EMPTY, "LastName should not be empty");
                    }


                    if (patternLastName.Length < 3)
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_LESSTHAN_MINIMUM_LENGTH, "LastName should contains atleast three characters");

                    }

                    if (patternLastName.Any(char.IsDigit))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_NUMBER, "LastName should not contains number");
                    }
                    if (!char.IsUpper(patternLastName[0]))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_LOWERCASE, "LastName first letter should not be a lowercase");
                    }
                    if (patternLastName.Any(char.IsLetterOrDigit))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_SPECIAL_CHARACTER, "LastName should not contains special characters");
                    }

                }
            }

            catch (UserRegistrationTestCustomException exception)
            {
                throw exception;
            }
            return "LastName is not valid";
        }

       
       
        /// <summary>
        /// Email Custom Exception
        /// </summary>
        /// <param name="patternEmail"></param>
        /// <returns></returns>
        public string emailLambda(string patternEmail)
        {
            bool result = email(patternEmail);
            try
            {
                if (result == false)
                {

                    if (patternEmail.Equals(string.Empty))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_EMPTY, "Email should not be empty");
                    }
                    if (!patternEmail.Any(char.IsLetterOrDigit))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_SPECIAL_CHARACTER, "Email should contains special characters");
                    }

                }
            }

            catch (UserRegistrationTestCustomException exception)
            {
                throw exception;
            }
            return "Email is not valid";
        }

        /// <summary>
        /// MobileNumber Custom Exception
        /// </summary>
        /// <param name="patternMobileNumber"></param>
        /// <returns></returns>
        public string mobileNumberLambda(string patternMobileNumber)
        {
            bool result = mobileNumber(patternMobileNumber);
            try
            {
                if (result == false)
                {

                    if (patternMobileNumber.Equals(string.Empty))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_EMPTY, "MobileNumber should not be empty");
                    }


                    if (patternMobileNumber.Length < 13)
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_LESSTHAN_MINIMUM_LENGTH, "MobileNumber should contains thirteen characters");

                    }

                    if (patternMobileNumber.Any(char.IsLetter))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_NUMBER, "MobileNumber should not contains letters");
                    }

                    if (patternMobileNumber.Any(char.IsLetterOrDigit))
                    {
                        throw new UserRegistrationTestCustomException(UserRegistrationTestCustomException.ExceptionType.ENTERED_SPECIAL_CHARACTER, "MobileNumber should not contains special characters");
                    }

                }
            }

            catch (UserRegistrationTestCustomException exception)
            {
                throw exception;
            }
            return "MobileNumber is not valid";
        }


    }
}
