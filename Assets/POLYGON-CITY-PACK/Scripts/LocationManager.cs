public static class LocationManager
{
    public static string StartLocation { get; private set; }
    public static string DestinationLocation { get; private set; }

    public static void SetLocations(string start, string destination)
    {
        StartLocation = start;
        DestinationLocation = destination;
    }
}
