using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp;

namespace MyApp.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void TestAdd()
        {
            var calc = new Calculator();
            var res = calc.Add(3, 1);
            Assert.That(res, Is.EqualTo(4));
        }
    }
}
