using GeoCoordinatePortable;
using System;
using System.Linq;
using System.Collections.Generic;
using Zoobysoft.GpxParser;

namespace ZoobySoft.CyclePlot.Analysis
{
    public class Trip
    {
        public Trip(IEnumerable<wptType> Waypoints) : this
        (
            Waypoints == null
            ? Enumerable.Empty<Segment>() 
            : Waypoints.Aggregate(new SegmentAccumulator(new List<Segment>(Waypoints.Count() - 1)), (accumulator, waypoint) =>
                {
                    if (accumulator.PreviousPoint != null)
                    {
                        accumulator.Segments.Add(new Segment(accumulator.PreviousPoint, waypoint));
                    }

                    accumulator.PreviousPoint = waypoint;

                    return accumulator;
                }
            ).Segments
        )
        { }

        public Trip(IEnumerable<Segment> Segments)
        {
            this.Segments = Segments;

            if (Segments == null || Segments.Count() == 0)
            {
                return;
            }

            StartTime = Segments.First().StartTime;
            EndTime = Segments.Last().EndTime;
        }

        public Distance GetTotalDistance()
        {
            if (Segments.Count() == 0)
            {
                return new Distance(0);
            }

            return Segments.Sum(segment => segment.GetDistance());
        }

        public TimeSpan GetTotalTimeSpan()
        {
            if (Segments.Count() == 0)
            {
                return new TimeSpan(0);
            }

            return EndTime - StartTime;
        }

        public Speed GetAverageSpeed()
        {
            return new Speed(GetTotalDistance(), GetTotalTimeSpan().TotalSeconds);
        }

        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public IEnumerable<Segment> Segments { get; }
    }

    public class Segment
    {
        public Segment(wptType Start, wptType End)
        {
            StartTime = Start.time;
            EndTime = End.time;

            StartLocation = new GeoCoordinate(Decimal.ToDouble(Start.lat), Decimal.ToDouble(Start.lon));
            EndLocation = new GeoCoordinate(Decimal.ToDouble(End.lat), Decimal.ToDouble(End.lon));
        }

        public GeoCoordinate StartLocation { get; }
        public GeoCoordinate EndLocation { get; }

        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public Distance GetDistance()
        {
            return Distance.ForMetres(StartLocation.GetDistanceTo(EndLocation));
        }

        public TimeSpan GetTimespan()
        {
            return EndTime - StartTime;
        }
    }

    public class SegmentAccumulator
    {
        public wptType PreviousPoint { get; set; }
        public List<Segment> Segments { get; }

        public SegmentAccumulator(List<Segment> Segments)
        {
            this.Segments = Segments;
        }
    }
}
