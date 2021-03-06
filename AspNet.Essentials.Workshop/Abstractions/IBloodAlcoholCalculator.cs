﻿using AspNet.Essentials.Workshop.Enums;
using AspNet.Essentials.Workshop.Models;

namespace AspNet.Essentials.Workshop.Abstractions
{
    public interface IBloodAlcoholCalculator
    {
        double Calculate(
            int weightInPounds,
            double hoursOfDrinking,
            Sex sex,
            params IBeer[] beers);

        double Calculate(
            int weightInPounds,
            double hoursOfDrinking,
            Sex sex,
            params double[] abvs);
    }
}