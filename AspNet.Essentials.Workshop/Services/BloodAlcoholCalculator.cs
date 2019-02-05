using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Enums;
using System;
using System.Linq;

namespace AspNet.Essentials.Workshop.Services
{
    public class BloodAlcoholCalculator : IBloodAlcoholCalculator
    {
        const double PoundsToGramsMultiple = 453.592;
        const double OuncesToGramsMultiple = 340.194;
        const double MaleConstant = 0.68;
        const double FemaleConstant = 0.55;
        const double AlcoholOverTimeDeteriorationConstant = .015;

        const int BacPrecision = 4;

        public double Calculate(
            int weightInPounds,
            double hoursOfDrinking,
            Sex sex,
            params IBeer[] beers)
        {
            if (beers is null || beers.Length == 0)
            {
                return 0;
            }

            // Calculation borrowed from:
            // https://www.wikihow.com/Calculate-Blood-Alcohol-Content-(Widmark-Formula)

            var totalAlcoholInGrams = beers.Sum(beer => OuncesToGramsMultiple * (beer.Abv / 100));
            var bodyWeightInGrams = weightInPounds * PoundsToGramsMultiple;
            var weightWithSexConstant = bodyWeightInGrams * (sex == Sex.Male ? MaleConstant : FemaleConstant);
            var rawNumber = totalAlcoholInGrams / weightWithSexConstant;
            var bacPercentage = rawNumber * 100;
            var result = bacPercentage - (hoursOfDrinking * AlcoholOverTimeDeteriorationConstant);

            return Math.Max(0, Math.Round(result, BacPrecision));
        }
    }
}