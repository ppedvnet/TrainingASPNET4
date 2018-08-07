﻿using System;

namespace CarRental.Helpers
{
    public static class Extensions
    {
        public static int CalcAge(this int yearOfConstruction)
        {
            return DateTime.Today.Year - yearOfConstruction;
        }
    }
}