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
        private const int DefaultValue = 0;

        public int Add(string numbers)
        {
            if (CheckWhetherStringIsEmpty(numbers))
            {
                return DefaultValue;
            }

            if (IfThereIsOnlyOneNumber(numbers))
            {
                return Int32.Parse(numbers); 
            }

            if (IfThereIsMoreThanOneNumber(numbers))
            {
                return ConvertToSingleNumber(numbers);
            }
            return 0;
        }

        private int ConvertToSingleNumber(string numbers)
        {
            string[] numbersArray = numbers.Split(',');
            return numbersArray.Sum(i => Int32.Parse(i));
        }

        private bool IfThereIsMoreThanOneNumber(string numbers)
        {
            if (numbers.Contains(','))
            {
                return true;
            }
            return false; 
        }

        private bool IfThereIsOnlyOneNumber(string numbers)
        {
            if (numbers.Contains(','))
                return false;
            return true;
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
