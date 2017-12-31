using System;
using System.Collections.Generic;
using System.Linq;

namespace ZoobySoft.CyclePlot.Analysis
{
    public class Speed
    {
        private Distance Distance;
        private double Seconds;

        private const int SecondsPerHour = 60 * 60;

        public Speed(Distance distance, double seconds)
        {
            this.Distance = distance;
            this.Seconds = seconds;
        }

        public static Speed ForMilesPerHour(double milesPerHour)
        {
            return new Speed(Distance.ForMiles(milesPerHour), SecondsPerHour);
        }

        public static Speed ForKilometresPerHour(double kilometresPerHour)
        {
            return new Speed(Distance.ForKilometres(kilometresPerHour), SecondsPerHour);
        }

        public static Speed ForMetresPerSecond(double metresPerSecond)
        {
            return new Speed(Distance.ForMetres(metresPerSecond), 1);
        }

        public double GetMilesPerHour()
        {
            return Distance.Miles / Seconds * SecondsPerHour;
        }

        public double GetKilometresPerHour()
        {
            return Distance.GetKilometres() / Seconds * SecondsPerHour;
        }

        public double GetMetresPerSecond()
        {
            return Distance.GetMetres() / Seconds;
        }
    }

    public class Distance
    {
        private const double KilometresPerMile = 1.60934;

        public Distance(double miles)
        {
            this.Miles = miles;
        }

        public static Distance ForMiles(double miles)
        {
            return new Distance(miles);
        }

        public static Distance ForKilometres(double kilometres)
        {
            return new Distance(kilometres / KilometresPerMile);
        }

        public static Distance ForMetres(double metres)
        {
            return ForKilometres(metres / 1000);
        }

        public double Miles { get; }

        public double GetKilometres()
        {
            return Miles * KilometresPerMile;
        }

        public double GetMetres()
        {
            return GetKilometres() * 1000;
        }

        public static Distance operator +(Distance distance1, Distance distance2)
        {
            return new Distance(distance1.Miles + distance2.Miles);
        }
    }

    public static class DistanceSummer
    {
        public static Distance Sum(this IEnumerable<Distance> source)
        {
            var sum = new Distance(0);
            foreach (var distance in source)
            {
                sum += distance;
            }
            return sum;
        }

        public static Distance Sum<T>(this IEnumerable<T> source, Func<T, Distance> selector)
        {
            return source.Select(selector).Sum();
        }
    }
}
