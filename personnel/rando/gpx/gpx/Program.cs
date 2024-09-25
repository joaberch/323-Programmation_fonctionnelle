using Aspose.Gis.Geometries;
using Aspose.Gis;
using System.Linq;

var layer = Drivers.Gpx.OpenLayer("./Running.gpx");

var points = new Dictionary<int, Trackpoint>();
var fifthPoints = new Dictionary<int, Trackpoint>();
var fifthPoints2 = new Dictionary<int, Trackpoint>();
int index = 0;

foreach (var feature in layer)
{
    // Check for Point geometry
    if (feature.Geometry.GeometryType == GeometryType.MultiLineString)
    {
        MultiLineString mls = (MultiLineString)feature.Geometry;
        foreach (LineString ls in mls)
        {
            //Console.WriteLine(ls.ToString());
            foreach (var p in ls)
            {
                Trackpoint trackpoint = new Trackpoint()
                {
                    Latitude = p.X,
                    Longitude = p.Y,
                    Elevation = p.Z,
                };
                points.Add(index++, trackpoint);
            }
        }
    }
}

//Get 1/5 of the points
bool Skip1 = false;
foreach (KeyValuePair<int, Trackpoint> pair in points)
{
    if(pair.Key % 5 == 0)
    {
        fifthPoints.Add(pair.Key, pair.Value);
        if (Skip1)
        {
            fifthPoints2.Add(pair.Key, pair.Value);
        }
        Skip1 = true;
    }
}

//Calculate vertical drop
double descent = 0;
double ascent = 0;
var totalElevation = fifthPoints.Zip(fifthPoints2, (two, one) => one.Value.Elevation-two.Value.Elevation);
foreach (var item in totalElevation)
{
    if (item < 0)
    {
        descent += Math.Abs(item);
    } else if (item > 0)
    {
        ascent += Math.Abs(item);
    }
}

//Display vertical drop
Console.WriteLine($"Dénivellé de monté : {ascent}");
Console.WriteLine($"Dénivellé de descente : {descent}");

//Calculate total length
double totalLength = fifthPoints.Zip(fifthPoints2, (two, one) => Math.Sqrt(Math.Pow(two.Value.Latitude-one.Value.Latitude, 2)) + Math.Pow(two.Value.Longitude-one.Value.Longitude, 2) + Math.Pow(two.Value.Elevation-one.Value.Elevation, 2)).Sum();
Console.WriteLine($"Distance total : {totalLength}");



Console.ReadLine();

class Trackpoint()
{
    private double _latitude;
    private double _longitude;
    private double _elevation;

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Elevation { get; set; }
}