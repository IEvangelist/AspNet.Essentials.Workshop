using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Enums;
using AspNet.Essentials.Workshop.Models;
using AspNet.Essentials.Workshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AspNet.Essentials.WorkshopTests
{
    public class BloodAlcoholCalculatorTests
    {
        readonly IBloodAlcoholCalculator _sut;

        public BloodAlcoholCalculatorTests()
            => _sut = new BloodAlcoholCalculator();

        [Fact]
        public void CalculateBloodAlcoholCorrectlyCalculates()
        {
            var beers = new Beer[]
            {
                new Beer { Abv = 7.2 },
                new Beer { Abv = 9.6 },
                new Beer { Abv = 12.7 }
            };

            var expected = 0.0996;
            var actual = _sut.Calculate(225, 3, Sex.Male, beers);

            Assert.Equal(Math.Round(expected, 4), actual);
        }

        [
            Theory,
            InlineData(0.0996, 225, 3, Sex.Male),
            InlineData(0.1109, 175, 5, Sex.Male),
            InlineData(0.1549, 175, 5, Sex.Female),
            InlineData(0.2382, 150, 2, Sex.Female)
        ]
        public void CalculateBloodAlcoholInlineDataCalculateTests(
            float expected,
            int weightInPounds,
            float hoursOfDrinking,
            Sex sex)
        {
            var beers = new Beer[]
            {
                new Beer { Abv = 7.2 },
                new Beer { Abv = 9.6 },
                new Beer { Abv = 12.7 }
            };

            var actual = _sut.Calculate(weightInPounds, hoursOfDrinking, sex, beers);

            Assert.Equal(Math.Round(expected, 4), actual);
        }

        public static IEnumerable<object[]> CalculateInputs =
            new List<object[]>
            {
                new object[] { 0.0996, 225, 3, Sex.Male, new[] { 7.2, 9.6, 12.7 } },
                new object[] { 0.2883, 190, 3.5, Sex.Male, new[] { 7.2, 9.6, 12.7, 5.5, 3.8, 10.9, 9 } },
                new object[] { 0.7970, 135, 1.75, Sex.Female, new[] { 10.2, 9.6, 12.7, 15.5, 13.8, 10.7, 9 } },
                new object[] { 0.1053, 165, 4, Sex.Female, new[] { 5.0, 5.1, 4.9, 5.0 } }
            };

        [
            Theory,
            MemberData(nameof(CalculateInputs))
        ]
        public void CalculateBloodAlcoholMemberDataCalculateTests(
            double expected,
            int weightInPounds,
            double hoursOfDrinking,
            Sex sex,
            double[] abvs)
        {
            var beers = abvs.Select(abv => new Beer { Abv = abv }).ToArray();

            var actual = _sut.Calculate(weightInPounds, hoursOfDrinking, sex, beers);

            Assert.Equal(Math.Round(expected, 4), actual);
        }
    }
}