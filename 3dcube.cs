using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Shape
{
    class Point
    {
        public int X;
        public int Y;
        public int Z;
        Point (int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    private double toRad(int angle)
    {
        return angle * (Math.PI / 180);
    }

    private double sin(int angle)
    {
        return Math.Sin(toRad(angle));
    }

    private double cos(int angle)
    {
        return Math.Cos(toRad(angle));
    }

    class CreateShape
    {
        Polygon p;
        public static void Main(string[] args)
        {
            //3d
            List<Point> cube = new List<Point>();
            cube.Add(new Point(-2, 2, 2));
            cube.Add(new Point( 2, 2, 2));
            cube.Add(new Point(-2,-2, 2));
            cube.Add(new Point( 2,-2, 2));

            cube.Add(new Point(-2, 2,-2));
            cube.Add(new Point( 2, 2,-2));
            cube.Add(new Point(-2,-2,-2));
            cube.Add(new Point( 2,-2,-2));

            int scale = 1;
            int angle = 45;
            double r = scale + Math.Floor(Math.cos(angle) * (0.3 * scale))
            foreach (Point p in cube)
            {
                p.X = (cos(angle) * r) + p.X;
                p.Z = (sin(angle) * r) + p.Z;
                //p.Y = 
            }

            // 2d
            CreatePolygon(ref p, 30);
            for (int i =0; i < 10; i++)
            {
                UpdatePolygon(ref p, Int32.Parse("0"), 30);
            }
            
        }

        private void CreatePolygon(ref Polygon poly, int historyLength)
        {
            if (poly == null || poly.Points.Count < historyLength)
            {
                // Create a blue and black Brush
                SolidColorBrush whiteBrush = new SolidColorBrush();
                whiteBrush.Color = Colors.White;
                SolidColorBrush blackBrush = new SolidColorBrush();
                blackBrush.Color = Colors.Black;

                PointCollection polygonPoints = new PointCollection();

                // Create a collection of points for a polygon
                System.Windows.Point Point1 = new System.Windows.Point(3, 0);
                poly = new Polygon();
                poly.Stroke = whiteBrush;
                poly.StrokeThickness = 0.5;
                System.Windows.Point end = new System.Windows.Point(historyLength + 1, 0);
                poly.Points.Add(end);

                polygonPoints.Add(Point1);

                for (int i = 0; i < historyLength; i++)
                {
                    polygonPoints.Add(new System.Windows.Point(i + 3, 0));
                }

                // Set Polygon.Points properties
                poly.Points = polygonPoints;
                poly.Name = "poly";

                // Add Polygon to the page
                poly.Fill = whiteBrush;
            }
        }

        private void UpdatePolygon(ref Polygon poly, int value, int historyLength = 30)
        {
            value = value < 0 ? 0 : value;
            value = value == 0 ? value : value / v;
            value = value * -1; // expand up

            int length = 0;
            

            // Create a Polygon
            CreatePolygon(ref Polygon poly);

            length = poly.Points.Count;

            poly.Points.RemoveAt(1);

            for (int i = 1; i < historyLength - 1; i++)
            {
                System.Windows.Point p = poly.Points[i];
                p.X -= 1;
                poly.Points[i] = p;
            }

            poly.Points.RemoveAt(length - 2);
            poly.Points.Add(new System.Windows.Point((length), value));
            poly.Points.Add(end);
        }
    }
}
