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
            Point3d pt1 = new Point3d(100, 0, 0);
            Point3d pt2 = new Point3d(0, 100, 0);
            Point3d pt3 = new Point3d(0, 0, 0);
            
            

            Arc arc = new Arc();
            arc.CreateArcOfCenter(pt1, pt3, pt2);

            Database db = HostApplicationServices.WorkingDatabase;
            db.AddToModelSpace(arc);
            Tools.PrintMessage(arc.Radius.ToString());
        }
    }
}
