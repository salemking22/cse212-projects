using System.Collections.Generic;

public class FeatureCollection
{
    // Matches SetsAndMaps.cs call: featureCollection.Features
    public List<Feature> Features { get; set; }
}

public class Feature
{
    // Matches SetsAndMaps.cs call: f.Properties
    public Properties Properties { get; set; }
}

public class Properties
{
    // Matches SetsAndMaps.cs call: f.Properties.Place and f.Properties.Mag
    public string Place { get; set; }
    public double Mag { get; set; }
}