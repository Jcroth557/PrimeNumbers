using NUnit.Framework;
using Primes;
using System;
using System.Collections.Generic;
using System.IO;

namespace PrimeNumbersTests
{
    public class Tests
    {
        PrimeFinder? primeFinder;
        [SetUp]
        public void Setup()
        {
            primeFinder = new PrimeFinder();
        }

        [Test]
        public void isPrime_InputOne_ReturnsFalse()
        {
            Assert.IsFalse(primeFinder.isPrime(1));
        }

        [Test]
        public void isPrime_PrimeNumber_ReturnsTrue()
        {
            Assert.IsTrue(primeFinder.isPrime(5));
        }

        [Test]
        public void isPrime_CompositeNumber_ReturnsFalse()
        {
            Assert.IsFalse(primeFinder.isPrime(4));
        }

        [Test]
        public void generate_OneToOneHundredAndOne_CorrectList()
        {
            List<int> expectedList = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };
            List<int> outputList = primeFinder.generate(1, 101);

            Assert.AreEqual(expectedList, outputList);
        }

        [Test]
        public void generate_CompositeRange_ReturnsEmptyList()
        {
            List<int> expectedList = new List<int>() { };
            List<int> outputList = primeFinder.generate(84, 87);

            Assert.AreEqual(expectedList.Count, outputList.Count);
        }

        [Test]
        public void generate_SamePrimeNumber_CorrectList()
        {
            List<int> expectedList = new List<int>() { 5 };
            List<int> outputList = primeFinder.generate(5, 5);

            Assert.AreEqual(expectedList, outputList);
        }

        [Test]
        public void generate_LargerNumbers_CorrectList()
        {
            List<int> expectedList = new List<int>() { 7901, 7907, 7919 };
            List<int> outputList = primeFinder.generate(7900, 7920);

            Assert.AreEqual(expectedList, outputList);
        }

        [Test]
        public void getInputs_GoodValues_ReturnsList()
        {
            var stringReader = new StringReader("3\r\n5");
            Console.SetIn(stringReader);

            List<int> outputList = primeFinder.getInputs();

            Assert.AreEqual(outputList.Count, 2);
        }

        [Test]
        public void getInputs_ValueLessThanOne_ReturnsEmptyList()
        {
            var stringReader = new StringReader("-3\r\n5");
            Console.SetIn(stringReader);

            List<int> outputList = primeFinder.getInputs();

            Assert.AreEqual(outputList.Count, 0);
        }

        [Test]
        public void getInputs_NonNumberInput_ReturnsEmptyList()
        {
            var stringReader = new StringReader("Hello\r\nWorld");
            Console.SetIn(stringReader);

            List<int> outputList = primeFinder.getInputs();

            Assert.AreEqual(outputList.Count, 0);
        }

        [Test]
        public void getInputs_SameNumber_ReturnsList()
        {
            var stringReader = new StringReader("3\r\n3");
            Console.SetIn(stringReader);

            List<int> outputList = primeFinder.getInputs();

            Assert.AreEqual(outputList.Count, 2);
        }

        [Test]
        public void printResults_EmptyList_ReturnsMessage()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            List<int> testList = new List<int> ();
            string expectedOutput = "There are no prime numbers in that range.\r\n";

            primeFinder.printResults(testList);

            Assert.AreEqual(expectedOutput, stringWriter.ToString());
        }

        [Test]
        public void printResults_ListWithPrimes_PrintsList()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            List<int> testList = new List<int> { 2, 3, 5, 7};
            string expectedOutput = "Here are the prime numbers in that range: \r\n2\r\n3\r\n5\r\n7\r\n";

            primeFinder.printResults(testList);

            Assert.AreEqual(expectedOutput , stringWriter.ToString());
        }
    }
}