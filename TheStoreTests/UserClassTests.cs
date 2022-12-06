using Castle.DynamicProxy;
using Moq;
using System;
using System.Diagnostics.Tracing;
using System.Net;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
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
        public void UserToStringTest(User testUser, string[] e)
        {
            //Arrange

            //Act
            string actual = testUser.ToString();

            //Assert
            string expected = string.Join(",", e);
            Assert.True(actual.Equals(expected));

            /* Function tested:
            public override string ToString()
            {
               string line = Name + "," + Password + "," + Email + "," + Address + "," + Convert.ToString(Phone) + "\r\n";
               return line;
            } */
        }
        

        public static IEnumerable<object[]> Data() =>

            new List<object[]>

            {
                new object[] { new string[] { "David", "password", "Email@Email", "Adress", "0721882669" }, new User("David", "password", "Email@Email", "Adress", 0721882669) },
                new object[] { new string[] { "Max", "123", "Email@email.com", "A very, very long address. Soooo long, sooooo long zzzzzzzzzzz", "72" }, new User("Max", "123", "Email@email.com", "A very, very long address. Soooo long, sooooo long zzzzzzzzzzz", 72) },
                new object[] { new string[] { "Linnea", "XyZ$$$/djf", "Email@Email", "Adress", "01382657420" }, new User("Linnea", "XyZ$$$/djf", "Email@Email", "Adress", 01382657420) },
                new object[] { new string[] { "David2", "qwerty", "david23@gmail.com", "Street56, 2657 37 Summerland", "7" }, new User("David2", "qwerty", "david23@gmail.com", "Street56, 2657 37 Summerland", 7) },
                new object[] { new string[] { "David3", "password1000", "mailmail@hopetihop", "Small lane at small town", "42875364298356920" }, new User("David3", "password1000", "mailmail@hopetihop", "Small lane at small town", 42875364298356920) },
            };

        public static IEnumerable<object[]> Data2() =>

            new List<object[]>

            {
                new object[] { new User("David", "password", "Email@Email", "Adress", 0721882669) }, new string[] { "David", "password", "Email@Email", "Adress", "0721882669" },
                new object[] { new User("Max", "123", "Email@email.com", "A very, very long address. Soooo long, sooooo long zzzzzzzzzzz", 72) }, new string[] { "Max", "123", "Email@email.com", "A very, very long address. Soooo long, sooooo long zzzzzzzzzzz", "72" },
                new object[] { new User("Linnea", "XyZ$$$/djf", "Email@Email", "Adress", 01382657420) }, new string[] { "Linnea", "XyZ$$$/djf", "Email@Email", "Adress", "01382657420" },
                new object[] { new User("David2", "qwerty", "david23@gmail.com", "Street56, 2657 37 Summerland", 7) }, new string[] { "David2", "qwerty", "david23@gmail.com", "Street56, 2657 37 Summerland", "7" },
                //new object[] { new User("David3", "password1000", "mailmail@hopetihop", "Small lane at small town", 000000042875364298356923) }, new string[] { "David3", "password1000", "mailmail@hopetihop", "Small lane at small town", "000000042875364298356923" },                                                                                                                                    Name + "," + Password + "," + Email + "," + Address + "," + Convert.ToString(Phone) + "\r\n"
            };
    }
}