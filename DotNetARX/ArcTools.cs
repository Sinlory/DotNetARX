﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace DotNetARX
{
    public static class ArcTools
    {
        /// <summary>
        /// 三点法创建圆弧（起始点、终止点、圆弧上一点）
        /// </summary>
        /// <param name="arc">所要创建的圆弧</param>
        /// <param name="startPoint">起始点</param>
        /// <param name="pointOnArc">圆弧上一点</param>
        /// <param name="endPoint">终止点</param>
        public static void CreateArc(this Arc arc, Point3d startPoint, Point3d pointOnArc, Point3d endPoint)
        {
            //创建一个几何类的圆弧对象
            CircularArc3d geArc = new CircularArc3d(startPoint, pointOnArc, endPoint);
            //将几何类圆弧对象的圆心和半径赋值给圆弧
            Point3d centerPoint = geArc.Center;
            arc.Center = centerPoint;
            arc.Radius = geArc.Radius;
            //计算起始和终点角度
            arc.StartAngle = startPoint.AngleFromXAxis(centerPoint);
            arc.EndAngle = endPoint.AngleFromXAxis(centerPoint);
        }

        /// <summary>
        /// 三点法创建圆弧，逆向。（起始点、圆心、终止点）
        /// </summary>
        /// <param name="arc">所要创建的圆弧</param>
        /// <param name="startPoint">起始点</param>
        /// <param name="centerPoint">圆心</param>
        /// <param name="endPoint">终止点</param>
        public static void CreateArcOfCenter(this Arc arc, Point3d startPoint, Point3d centerPoint, Point3d endPoint)
        {
            //确定圆弧的圆心与半径
            arc.Center = centerPoint;
            Vector2d vec = new Vector2d(startPoint.X - centerPoint.X, startPoint.Y - centerPoint.Y);
            arc.Radius = vec.Length;
            //计算起始和终点角度
            arc.StartAngle = startPoint.AngleFromXAxis(centerPoint);
            arc.EndAngle = endPoint.AngleFromXAxis(centerPoint);

            

        }


    }
}
