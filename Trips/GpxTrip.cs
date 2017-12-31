using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Zoobysoft.GpxParser;

namespace ZoobySoft.CyclePlot.Analysis
{
    public class GpxTrip : Trip
    {
        public GpxTrip(FileStream gpxFile) : this((gpxType)new XmlSerializer(typeof(gpxType)).Deserialize(gpxFile))
        { }

        public GpxTrip(gpxType gpx) : base(gpx.trk.SelectMany(track => track.trkseg.SelectMany(segment => segment.trkpt)))
        { }
    }

    public class GpxTripDirectory
    {
        public static IEnumerable<Trip> ReadTrips(string path)
        {
            if (!Directory.Exists(path))
            {
                return Enumerable.Empty<Trip>();
            }

            return Directory.EnumerateFiles(path).Select(filename => new GpxTrip(File.OpenRead(filename)));
        }

        public string Path { get; }
    }
}
