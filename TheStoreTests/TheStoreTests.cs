using TheStore;

namespace TheStoreTests
{
    public class TheStoreTests
    {
        [Fact]
        public void UserToStringTest()
        {
            //Arrange - skapa förhållandena för testet.
            User user = new User("David", "password", "Email@Email", "Adress", 0721882669);
            string expected = "David" + "," + "password" + "," + "Email@Email" + "," + "Adress" + "," + "721882669" + "\r\n";
            //Act - Kör funktionen vi vill testa
            string actual = user.ToString();
            //Assert - Där vi anger vad vi vill ska komma ut ur testet.
            Assert.Equal(expected, actual, ignoreCase: true);

            // vad jag skall testa för funktion:
            // public override string ToString()
            // {
            //   string line = Name + "," + Password + "," + Email + "," + Address + "," + Convert.ToString(Phone) + "\r\n";
            //   return line;
            // }
        }
        [Fact]
        public void UserParseTest()
        {

            //Arrange - skapa förhållandena för testet.
            User user = new User("David", "password", "Email@Email", "Adress", 0721882669);
            string value1 = user.Name;
            string value2 = user.Password;
            string value3 = user.Email;
            string value4 = user.Address;
            double value5 = user.Phone;
            string expected = value1 + value2 + value3 + value4 + value5;
            //Act - Kör funktionen vi vill testa
            var actual = "David" + "password" + "Email@Email" + "Adress" + 0721882669;

            //Assert - Där vi anger vad vi vill ska komma ut ur testet.
            Assert.Equal(expected, actual, ignoreCase: true);

            // vad jag skall testa för funktion:
            // public User parse(string[] words)
            // {
            //     return new User(name: words[0], password: words[1],
            //                     email: words[2], address: words[3],
            //                     phone: Convert.ToDouble(words[4]));
            // }
        }
    }
}