using TheStore;

namespace TheStoreTests
{
    public class TheStoreTests
    {
        [Fact]
        public void UserToStringTest()
        {
            //Arrange - skapa f�rh�llandena f�r testet.
            User user = new User("David", "password", "Email@Email", "Adress", 0721882669);
            string expected = "David" + "," + "password" + "," + "Email@Email" + "," + "Adress" + "," + "721882669" + "\r\n";
            //Act - K�r funktionen vi vill testa
            string actual = user.ToString();
            //Assert - D�r vi anger vad vi vill ska komma ut ur testet.
            Assert.Equal(expected, actual, ignoreCase: true);

            // vad jag skall testa f�r funktion:
            // public override string ToString()
            // {
            //   string line = Name + "," + Password + "," + Email + "," + Address + "," + Convert.ToString(Phone) + "\r\n";
            //   return line;
            // }
        }
        [Fact]
        public void UserParseTest()
        {

            //Arrange - skapa f�rh�llandena f�r testet.
            User user = new User("David", "password", "Email@Email", "Adress", 0721882669);
            string value1 = user.Name;
            string value2 = user.Password;
            string value3 = user.Email;
            string value4 = user.Address;
            double value5 = user.Phone;
            string expected = value1 + value2 + value3 + value4 + value5;
            //Act - K�r funktionen vi vill testa
            var actual = "David" + "password" + "Email@Email" + "Adress" + 0721882669;

            //Assert - D�r vi anger vad vi vill ska komma ut ur testet.
            Assert.Equal(expected, actual, ignoreCase: true);

            // vad jag skall testa f�r funktion:
            // public User parse(string[] words)
            // {
            //     return new User(name: words[0], password: words[1],
            //                     email: words[2], address: words[3],
            //                     phone: Convert.ToDouble(words[4]));
            // }
        }
    }
}