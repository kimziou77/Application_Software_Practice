using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Packet_WorldDrawing
{
    public enum PacketType
    {
        INIT,
        MESSAGE,
        DRAWING,
        EXIT
    }

    public class Class1
    {
        [Serializable]
        public class WorldPaint : Packet
        {
            public MyDrawings drawings;


            public MyLines[] mylines;
            public MyRect[] myrect;
            public MyCircle[] mycircle;
            public MyPencil[] mypencils;
            public MyShape[] myshapes;
            public int nShape;

            public WorldPaint(MyDrawings md)
            {
                drawings = md;
                mylines = md.mylines;
                myrect = md.myrect;
                mycircle = md.mycircle;
                myshapes = md.myshapes;
                nShape = md.nShape;
            }
        }
        
        [Serializable]
        public class Messenger : Packet
        {
            public string id;
            public string msg;
            public Messenger(string id, string msg)
            {
                this.id = id;
                this.msg = msg;
            }
        }

        [Serializable]
        public class Init : Packet
        {
            public string id;
            public Init(string id)
            {
                this.id = id;
            }
        }



        [Serializable]
        public class Packet
        {
            public int Length;
            public PacketType Type;

            public Packet()
            {
                this.Length = 0;
                this.Type = 0;
            }

            public static byte[] Serialize(Object o)
            {
                MemoryStream ms = new MemoryStream(1024 * 100);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, o);
                return ms.ToArray();
            }

            public static Object Desserialize(byte[] bt)
            {
                MemoryStream ms = new MemoryStream(1024 * 32);
                foreach (byte b in bt)
                {
                    ms.WriteByte(b);
                }

                ms.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();
                Object obj = bf.Deserialize(ms);
                ms.Close();
                return obj;
            }
        }
    }

}
