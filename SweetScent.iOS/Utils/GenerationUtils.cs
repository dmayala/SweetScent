﻿using CoreLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetScent.iOS.Utils
{
    public class GenerationUtils
    {
        private static bool Equal(double a, double b)
        {
            return Math.Abs(a - b) < 0.000005;
        }

        public static List<CLLocationCoordinate2D> GetCorners(List<CLLocationCoordinate2D> scanMap)
        {
            double minlat = 9001;
            double maxlat = -9001;
            double minlon = 9001;
            double maxlon = -9001;
            double toplat = 9001;
            double botlat = -9001;
            int mapSize = scanMap.Count;
            for (int i = 0; i < mapSize; i++)
            {
                CLLocationCoordinate2D item = scanMap[i];
                minlat = Math.Min(item.Latitude, minlat);
                minlon = Math.Min(item.Longitude, minlon);
                maxlat = Math.Max(item.Latitude, maxlat);
                maxlon = Math.Max(item.Longitude, maxlon);
                if (Equal(minlon, item.Longitude))
                {
                    toplat = Math.Min(toplat, item.Latitude);
                    botlat = Math.Max(botlat, item.Latitude);
                }
            }

            double midlon = minlon + (maxlon - minlon) / 2;

            return new List<CLLocationCoordinate2D>()
            {
                new CLLocationCoordinate2D(minlat, midlon),
                new CLLocationCoordinate2D(toplat, maxlon),
                new CLLocationCoordinate2D(botlat, maxlon),
                new CLLocationCoordinate2D(maxlat, midlon),
                new CLLocationCoordinate2D(botlat, minlon),
                new CLLocationCoordinate2D(toplat, minlon)
            };
        }

        // Call with layer_count initially 1
        // REQUIRES: not empty scanMap, layer_count > 0, loc is the starting loc
        public static List<CLLocationCoordinate2D> MakeHexScanMap(CLLocationCoordinate2D loc, int steps, int layer_count, List<CLLocationCoordinate2D> scanMap)
        {
            // Base case is do nothing
            if (steps > 0)
            {
                if (layer_count == 1)
                {
                    // Add in the point, no translation since 1st layer
                    scanMap.Add(loc);
                }
                else
                {
                    double distance = 200; // in meters
                                           // add a point that is distance due north
                    scanMap.Add(Translate(loc, 0.0, distance));
                    // go south-east
                    for (int i = 0; i < layer_count - 1; i++)
                    {
                        CLLocationCoordinate2D prev = scanMap[scanMap.Count - 1];
                        CLLocationCoordinate2D next = Translate(prev, 120.0, distance);
                        scanMap.Add(next);
                    }
                    // go due south
                    for (int i = 0; i < layer_count - 1; i++)
                    {
                        CLLocationCoordinate2D prev = scanMap[scanMap.Count - 1];
                        CLLocationCoordinate2D next = Translate(prev, 180.0, distance);
                        scanMap.Add(next);
                    }
                    // go south-west
                    for (int i = 0; i < layer_count - 1; i++)
                    {
                        CLLocationCoordinate2D prev = scanMap[scanMap.Count - 1];
                        CLLocationCoordinate2D next = Translate(prev, 240.0, distance);
                        scanMap.Add(next);
                    }
                    // go north-west
                    for (int i = 0; i < layer_count - 1; i++)
                    {
                        CLLocationCoordinate2D prev = scanMap[scanMap.Count - 1];
                        CLLocationCoordinate2D next = Translate(prev, 300.0, distance);
                        scanMap.Add(next);
                    }
                    // go due north
                    for (int i = 0; i < layer_count - 1; i++)
                    {
                        CLLocationCoordinate2D prev = scanMap[scanMap.Count - 1];
                        CLLocationCoordinate2D next = Translate(prev, 0.0, distance);
                        scanMap.Add(next);
                    }
                    // go north-east
                    for (int i = 0; i < layer_count - 2; i++)
                    {
                        CLLocationCoordinate2D prev = scanMap[scanMap.Count - 1];
                        CLLocationCoordinate2D next = Translate(prev, 60.0, distance);
                        scanMap.Add(next);
                    }
                }
                return MakeHexScanMap(scanMap[HexagonalNumber(layer_count - 1)], steps - 1, layer_count + 1, scanMap);
            }
            else
            {
                return scanMap;
            }
        }

        public static double ConvertToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        public static double ToDegrees(double radians)
        {
            return radians * (180 / Math.PI);
        }

        // Takes in distance in meters, bearing in degrees
        public static CLLocationCoordinate2D Translate(CLLocationCoordinate2D cur, double bearing, double distance)
        {
            double earth = 6378.1; // Radius of Earth in km
            double rad_bear = ConvertToRadians(bearing);
            double dist_km = distance / 1000;
            double lat1 = ConvertToRadians(cur.Latitude);
            double lon1 = ConvertToRadians(cur.Longitude);
            double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(dist_km / earth) +
                    Math.Cos(lat1) * Math.Sin(dist_km / earth) * Math.Cos(rad_bear));
            double lon2 = lon1 + Math.Atan2(Math.Sin(rad_bear) * Math.Sin(dist_km / earth) * Math.Cos(lat1),
                    Math.Cos(dist_km / earth) - Math.Sin(lat1) * Math.Sin(lat2));
            lat2 = ToDegrees(lat2);
            lon2 = ToDegrees(lon2);
            return new CLLocationCoordinate2D(lat2, lon2);
        }

        public static int HexagonalNumber(int n)
        {
            return (n == 0) ? 0 : 3 * n * (n - 1) + 1;
        }
    }
}
