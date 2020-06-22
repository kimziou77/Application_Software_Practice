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
        FILE_INFO,
        DOWNLOAD,
        EXIT
    }

    public class Class1
    {
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
        public class WorldPaint : Packet
        {
            MyDrawings drawings;
        }

        [Serializable]
        public class Packet
        {
            public int Length;
            public int Type;

            public Packet()
            {
                this.Length = 0;
                this.Type = 0;
            }

            public static byte[] Serialize(Object o)
            {
                MemoryStream ms = new MemoryStream(1024 * 4);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, o);
                return ms.ToArray();
            }

            public static Object Desserialize(byte[] bt)
            {
                MemoryStream ms = new MemoryStream(1024 * 4);
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
