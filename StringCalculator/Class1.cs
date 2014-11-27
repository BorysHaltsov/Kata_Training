using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator
{
    public class Class1
    {
        public int Add(string numbers)
        {
            if (CheckWhetherStringIsEmpty(numbers))
            {
                return 0; 
            }

            if (CheckWhetherStringContainsSeparator(numbers))
            {
                return SumOfNumbers(numbers);
            }
            return Int32.Parse(numbers);  
        }

        private int SumOfNumbers(string numbers)
        {
            string[] splitedNumbers = numbers.Split(',');
            int sum = 0; 
            foreach (string splitedNumber in splitedNumbers)
            {
                sum += Int32.Parse(splitedNumber);
            }
            return sum;  
        }

        private bool CheckWhetherStringContainsSeparator(string numbers)
        {
            return numbers.Contains(',');
        }

        private bool CheckWhetherStringIsEmpty(string numbers)
        {
            return numbers == String.Empty;
        }
    }

    public class Class1Tests
    {

        [TestCase("",0)] 
        [TestCase("1",1)] 
        [TestCase("2",2)] 
        [TestCase("1,2",3)] 
        [TestCase("1,2,3,4",10)] 

        public void CheckClassWork(string numbers, int expected)
        {
            ArrangeActAssert(numbers, expected);
        }

        private void ArrangeActAssert(string numbers, int expected)
        {
            var calculator = new Class1();
            Assert.AreEqual(calculator.Add(numbers), expected);
        }
    }
}
