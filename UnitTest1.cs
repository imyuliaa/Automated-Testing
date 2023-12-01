using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;
using AnalaizerClassLibrary;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient", @"Data Source=NB-YULIA\SQLEXPRESS;AttachDbFilename=C:\Users\Юля\Documents\CalculatorData.mdf;Integrated Security=True;Connect Timeout=30", "TestCreateStack", DataAccessMethod.Sequential)]

        [TestMethod]
        public void TestMethod1()
        {
            {
                {
                    string expression = (string)TestContext.DataRow["InputExpression"];
                    string expected = (string)TestContext.DataRow["PolishExpression"];

                    // Act
                    ArrayList result = AnalaizerClass.CreateStack(expression);

                    // Assert
                    ArrayList expectedList = new ArrayList(expected.Split(' '));
                    CollectionAssert.AreEqual(expectedList.ToArray(), result.ToArray(), GetAssertionMessage(expectedList, result));
                }
            }
        }

        private string GetAssertionMessage(ArrayList expected, ArrayList actual)
        {
            return $"Expected: [{string.Join(", ", expected.Cast<string>())}], Actual: [{string.Join(", ", actual.Cast<string>())}]";
        }
    }
}
