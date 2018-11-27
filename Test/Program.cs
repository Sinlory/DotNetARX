using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetARX;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3d pt1 = new Point3d(0, 0, 0);
            Point3d pt2 = new Point3d(2, 2, 0);
            double result = pt1.AngleFromXAxis(pt2);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
