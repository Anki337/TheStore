using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheStore.UnitTests
{
    public class ItemClassTests {


        [Theory]
        [MemberData (nameof(Data))]
        public void ItemCloneTest(Item testItem, Item expected)
        {
            //Arrange

            //Act
            Item actual = testItem.clone();

            //Assert
            Assert.True(actual.ToString() == expected.ToString());
            Assert.NotSame(expected, actual);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ItemCloneTest2(Item actual, Item expected)
        {
            //Arrange

            //Act
            actual = expected.clone();

            //Assert
            Assert.True(actual.ToString() == expected.ToString());
            Assert.NotSame(expected, actual);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new Item("Bobbycar", "Drive around", 5, 550, 12, "Big"), new Item("Bobbycar", "Drive around", 5, 550, 12, "Big") };
            yield return new object[] { new Item("lskhf", "87ds6", 585705, 28365, 12029375, "SMALL"), new Item("lskhf", "87ds6", 585705, 28365, 12029375, "SMALL") };
            yield return new object[] { new Item(" ", "", 0, 0, 0, null), new Item(" ", "", 0, 0, 0, null) };
            yield return new object[] { new Item("lskhf", "slkghghk[pb", 585705, 28365, 12029375, "medi__m" ), new Item("lskhf", "slkghghk[pb", 585705, 28365, 12029375, "medi__m") };
            yield return new object[] { new Item("lsdkrguh", "87ds6", 93865, 4, 235, "This is not a short sentance" ), new Item("lsdkrguh", "87ds6", 93865, 4, 235, "This is not a short sentance") };
            yield return new object[] { new Item("g", "87ds6", 1, 3, 7, "98235" ), new Item("g", "87ds6", 1, 3, 7, "98235") };
        }
    }
}
