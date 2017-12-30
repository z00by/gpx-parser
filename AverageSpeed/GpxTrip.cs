using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Zoobysoft.GpxParser;

namespace ZoobySoft.CyclePlot.Analysis
{
    class GpxTrip : Trip
    {
        public GpxTrip(FileStream gpxFile) : this((gpxType)new XmlSerializer(typeof(gpxType)).Deserialize(gpxFile))
        { }

        public GpxTrip(gpxType gpx) : base(gpx.trk.SelectMany(track => track.trkseg.SelectMany(segment => segment.trkpt)))
        { }
    }
}
