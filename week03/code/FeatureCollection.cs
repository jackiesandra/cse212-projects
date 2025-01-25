using System;
using System.Collections.Generic;

namespace EarthquakeData
{
    // Class representing a collection of earthquake features
    public class FeatureCollection
    {
        // Type of the collection, typically "FeatureCollection"
        public string Type { get; set; }
        
        // List of features, where each feature contains information about the earthquake
        public List<Feature> EarthquakeFeatures { get; set; }
    }

    // Class representing a single earthquake feature
    public class Feature
    {
        // Geometry information about the earthquake (e.g., coordinates)
        public Geometry Geometry { get; set; }
        
        // Properties of the earthquake, such as place and magnitude
        public Properties Properties { get; set; }
    }

    // Class representing the geometry of an earthquake
    public class Geometry
    {
        // Type of geometry, usually "Point"
        public string Type { get; set; }
        
        // Coordinates (latitude, longitude)
        public List<double> Coordinates { get; set; }
    }

    // Class representing the properties of the earthquake
    public class Properties
    {
        // Location description of the earthquake
        public string Place { get; set; }
        
        // Magnitude of the earthquake
        public double Mag { get; set; }
    }
}
