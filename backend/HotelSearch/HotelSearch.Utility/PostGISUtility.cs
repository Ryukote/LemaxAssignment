using System.Drawing;
using NetTopologySuite.Geometries;

namespace HotelSearch.Utility
{
    public static class PostGISUtility
    {
        private const int WGS84Srid = 4326;
        // Create a static GeometryFactory to be efficient.
        private static readonly GeometryFactory _geometryFactory = new GeometryFactory(new PrecisionModel(), WGS84Srid);

        public static NetTopologySuite.Geometries.Point CreatePointFromLatLon(double latitude, double longitude)
        {
            // IMPORTANT: The order is Longitude, then Latitude!
            return _geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
        }
    }
}
