using JustTestAPIAssignment.Helper;
using JustTestAPIAssignment.Model;
using NUnit.Framework;
using RestSharp;
using System;

namespace JustTestAPIAssignment
{
    [TestFixture]
    public class Tests
    {
        private Utilities _utilities = new Utilities();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegisterWithValidValues()
        {
            Random randomNumber = new Random();
            RegisterRequest requestBody = new RegisterRequest()
            {

                username = "testlogin" + randomNumber.Next(999999),
                firstName= "raghda",
                lastname="x",
                password="TESt@123456",
                confirmPassword = "TESt@123456"

            };
            RestResponse response= _utilities.CreateUser(requestBody);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [Test]
        public void RegisterWithExistingUsernameIsNotAllowed()
        {
           
            RegisterRequest requestBody = new RegisterRequest()
            {

                username = "aa",
                firstName = "raghda",
                lastname = "x",
                password = "TESt@123456",
                confirmPassword = "TESt@123456"

            };
            RestResponse response = _utilities.CreateUser(requestBody);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            Assert.True(response.Content.Contains("User already exists"));
        }

        [Test]
        public void RegisterWithUnmatchingPasswordsIsNotAllowed()
        {
            Random randomNumber = new Random();
            RegisterRequest requestBody = new RegisterRequest()
            {

                username = "aa"+randomNumber.Next(9999),
                firstName = "raghda",
                lastname = "x",
                password = "TESt@12345",
                confirmPassword = "TESt@123456"

            };
            RestResponse response = _utilities.CreateUser(requestBody);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            
        }

        [Test]
        public void RegisterWithMissingUsernameIsNotAllowed()
        {
            Random randomNumber = new Random();
            RegisterRequest requestBody = new RegisterRequest()
            {

                username = "",
                firstName = "raghda",
                lastname = "x",
                password = "TESt@12345",
                confirmPassword = "TESt@123456"

            };
            RestResponse response = _utilities.CreateUser(requestBody);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            Assert.True(response.Content.Contains("username is required"));
        }

        [Test]
        public void RegisterWithMissingFisrtnameIsNotAllowed()
        {
            Random randomNumber = new Random();
            RegisterRequest requestBody = new RegisterRequest()
            {

                username = "test"+randomNumber.Next(7777),
                firstName = "",
                lastname = "x",
                password = "TESt@12345",
                confirmPassword = "TESt@123456"

            };
            RestResponse response = _utilities.CreateUser(requestBody);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            Assert.True(response.Content.Contains("first name is required"));
        }

        [Test]
        public void RegisterWithMissingLastnameIsNotAllowed()
        {
            Random randomNumber = new Random();
            RegisterRequest requestBody = new RegisterRequest()
            {

                username = "test" + randomNumber.Next(7777),
                firstName = "xx",
                lastname = "",
                password = "TESt@12345",
                confirmPassword = "TESt@123456"

            };
            RestResponse response = _utilities.CreateUser(requestBody);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            Assert.True(response.Content.Contains("last name is required"));
        }

        //TO-DO to add testcases to cover password validations
    }
}