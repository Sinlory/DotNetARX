using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;


namespace DotNetARX
{

    public static class Tools
    {
        /// <summary>
        /// 将实体添加到模型空间
        /// </summary>
        /// <param name="db">数据库对象</param>
        /// <param name="ent">要添加的实体</param>
        /// <returns>返回添加到模型空间中的实体ObjestId</returns>
        public static ObjectId AddToModelSpace(this Database db, Entity ent)
        {
            ObjectId entId;
            //定义一个指向当前数据库的事务处理，以添加支线
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //以读方式打开块表
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //以写的方式打开模型空间块表记录
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                entId = btr.AppendEntity(ent);//将图形对象的信息添加到块记录中
                trans.AddNewlyCreatedDBObject(ent, true);//将对象添加到事务处理中
                trans.Commit();//提交事务处理
            }
            return entId;
        }

        /// <summary>
        /// 将实体添加到模型空间
        /// </summary>
        /// <param name="db">数据库对象</param>
        /// <param name="ents">要添加的实体的数组</param>
        public static void AddToModelSpace(this Database db, params Entity[] ents)
        {
            for (int i = 0; i < ents.Length; i++)
            {
                AddToModelSpace(db, ents[i]);
            }
        }

        /// <summary>
        /// 用于计算从第一点到第二点所确定的矢量与X轴正半轴的夹角。
        /// </summary>
        /// <param name="pt1">第一个点</param>
        /// <param name="pt2">第二个点</param>
        /// <returns>从第一点到第二点所确定的矢量与X轴正半轴的夹角</returns>
        public static double AngleFromXAxis(this Point3d pt1, Point3d pt2)
        {
            //构建一个从第一点到第二点所确定的矢量
            Vector2d vector = new Vector2d(pt1.X - pt2.X, pt1.Y - pt2.Y);
            //返回该矢量与X轴正半轴的夹角
            return vector.Angle;
        }

        /// <summary>
        /// 将字符串输出到命令行中。
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        public static void PrintMessage(string str)
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage(str);
        }
    }
}
