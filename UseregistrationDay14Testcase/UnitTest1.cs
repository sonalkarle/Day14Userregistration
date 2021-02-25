using NUnit.Framework;
using UserRegistrationLambda;

namespace NUnitTestProject
{
    public class Tests
    {

        UserRegistrationTestLambda userRegistration;
        [SetUp]
        public void Setup()
        {
            userRegistration = new UserRegistrationTestLambda();
        }

        /// <summary>
        /// TC-1 Throw Custom Exception for Invalid FirstName
        /// </summary>
        [TestCase("Sonal")]
        [TestCase("So")]
        public void Given_FirstName_Expecting_ThrowCustomException(string firstName)
        {
            
            try
            {
              string  actual = userRegistration.firstNameLambda(firstName);
            }
            catch (UserRegistrationTestCustomException exception)
            {
                Assert.AreEqual("FirstName should contains atleast three characters", exception.Message);
            }
        }

        /// <summary>
        /// TC-2 Throw Custom Exception for Invalid LastName
        /// </summary>
        [TestCase("Karle")]
        [TestCase("Ka")]
        public void Given_LastName_Expecting_ThrowCustomException(string lastName)
        {
            
            try
            {
               string actual = userRegistration.lastNameLambda(lastName);
            }
            catch (UserRegistrationTestCustomException exception)
            {
                Assert.AreEqual("LastName should contains atleast three characters", exception.Message);
            }
        }

        /// <summary>
        /// TC-5 Throw Custom Exception for Invalid Email
        /// </summary>
        [TestCase("abc@yahoo.com")]
        [TestCase("abc-100@yahoo.com,")]
        [TestCase("abc.100@yahoo.com")]
        [TestCase("abc111@abc.com,")]
        [TestCase("abc-100@abc.net,")]
        [TestCase("abc.100@abc.com.au")]
        [TestCase("abc@1.com,")]
        [TestCase("abc@gmail.com.com")]
        [TestCase("abc+100@gmail.com")]
        [TestCase("abc")]
        [TestCase("abc@.com.my")]
        [TestCase("abc123@gmail.a")]
        [TestCase("abc123@.com")]
        [TestCase("abc@.com.com")]
        [TestCase(".abc@abc.com")]
        [TestCase("abc()*@gmail.com")]
        [TestCase("abc@%*.com")]
        [TestCase("abc..2002@gmail.com")]
        [TestCase("abc.@gmail.com")]
        [TestCase("abc@abc@gmail.com")]
        [TestCase("abc@gmail.com.1a")]
        [TestCase("abc@gmail.com.aa.au")]
        public void Given_Email_Expecting_ThrowCustomException(string email)
        {
            
            try
            {
              string actual = userRegistration.emailLambda(email);
            }
            catch (UserRegistrationTestCustomException exception)
            {
                Assert.AreEqual("Email should contains special characters", exception.Message);
            }
        }
        /// <summary>
        /// TC-3 Throw Custom Exception for Invalid MobileNumber
        /// </summary>
        [TestCase("91 9702420754")]
        [TestCase("")]
        public void Given_MobileNumber_Expecting_ThrowCustomException(string mobileNumber)
        {

            try
            {
                string actual = userRegistration.mobileNumberLambda(mobileNumber);
            }
            catch (UserRegistrationTestCustomException exception)
            {
                Assert.AreEqual("MobileNumber should not be empty", exception.Message);
            }
        }

    }
}