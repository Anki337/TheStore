using System.Diagnostics.Tracing;
using System.Net;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using Xunit;

namespace TheStore.UnitTests
{
    public class UserClassTests : IEquatable<object>
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void UserParseTest(string[] userData, User expected)
        {
            //Arrange
            User user = new User();

            //Act
            var actual = user.parse(userData);

            //Assert
            Assert.True(actual.Equals(expected));
        }

        [Theory]
        [MemberData(nameof(Data2))]
        public void UserToStringTest(User testUser, string expected)
        {
            //Arrange

            //Act
            string actual = testUser.ToString();

            //Assert
            Assert.True(actual.Equals(expected, StringComparison.Ordinal));
        }


        public static IEnumerable<object[]> Data() =>

            new List<object[]>

            {
                new object[] { new string[] { "David", "password", "Email@Email", "Adress", "0721882669", "false" }, new User("David", "password", "Email@Email", "Adress", "0721882669", false) },
                new object[] { new string[] { "Max", "123", "Email@email.com", "A very, very long address. Soooo long, sooooo long zzzzzzzzzzz", "72", "false" }, new User("Max", "123", "Email@email.com", "A very, very long address. Soooo long, sooooo long zzzzzzzzzzz", "72", false) },
                new object[] { new string[] { "Linnea", "XyZ$$$/djf", "Email@Email", "Adress", "01382657420", "false" }, new User("Linnea", "XyZ$$$/djf", "Email@Email", "Adress", "01382657420", false) },
                new object[] { new string[] { "David2", "qwerty", "david23@gmail.com", "Street56, 2657 37 Summerland", "7", "false" }, new User("David2", "qwerty", "david23@gmail.com", "Street56, 2657 37 Summerland", "7", false) },
                new object[] { new string[] { "David3", "password1000", "mailmail@hopetihop", "Small lane at small town", "42875364298356920", "false" }, new User("David3", "password1000", "mailmail@hopetihop", "Small lane at small town", "42875364298356920", false) },
                new object[] { new string[] { "", "", "", "", "", "false" }, new User("", "", "", "", "", false) },
            };

        public static IEnumerable<object[]> Data2() =>

            new List<object[]>

            {
                new object[] { new User("David", "password", "Email@Email", "Adress", "721882669", false), "David,password,Email@Email,Adress,721882669,False\r\n" },
                new object[] { new User("Max", "123456", "Email@email.com", "A very very long address Soooo long sooooo long zzzzzzzzzzz", "72", false), "Max,123456,Email@email.com,A very very long address Soooo long sooooo long zzzzzzzzzzz,72,False\r\n" },
                new object[] { new User("Linnea", "XyZ$$$/djf", "Email@Email", "Address", "1382657420", false), "Linnea,XyZ$$$/djf,Email@Email,Address,1382657420,False\r\n" },
                new object[] { new User("David3", "password1000", "mailmail@hopetihop", "Small lane at small town", "98356923", false), "David3,password1000,mailmail@hopetihop,Small lane at small town,98356923,False\r\n" },
                new object[] { new User("David2", "qwerty", "david23@gmail.com", "Street56 2657 37 Summerland", "7", false), "David2,qwerty,david23@gmail.com,Street56 2657 37 Summerland,7,False\r\n" },
                new object[] { new User("Null", "Nullinull", "", "Street Nullzone", "0", false), "Null,Nullinull,,Street Nullzone,0,False\r\n" },

            };
    }
}