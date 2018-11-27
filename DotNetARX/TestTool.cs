using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;

namespace DotNetARX
{
    public class TestTool
    {
        [CommandMethod("CeShi")]
        public void CeShi()
        {
            Point3d pt1 = new Point3d(20, 10, 0);
            Point3d pt2 = new Point3d(10, 20, 0);
            Point3d pt3 = new Point3d(20, 20, 0);
            double result = pt1.AngleFromXAxis(pt2);

            Arc arc = new Arc();
            arc.CreateArc(pt1, pt3, pt2);

            Database db = HostApplicationServices.WorkingDatabase;
            db.AddToModelSpace(arc);
        }
    }
}
