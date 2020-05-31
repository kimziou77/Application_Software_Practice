using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PacketDefine
{
    public enum TREE_IMAGE
    {
        FOLDER,
        VEDIO,      // avi, mp4
        IMAGE,      // jpg, png
        MUSIC,      // mp3 ,wav
        TEXT,       // txt
        OTHER
    }
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
            public string msg;
            public Messenger(string s)
            {
                msg = s;
            }
        }

        [Serializable]
        public class DownFile : Packet
        {
            public string name;
            public string ServerPath;
            public string ClientPath;
            public FileInfo fi;
            public long size;
        }

        [Serializable]
        public class File_Info : Packet
        {
            public string path;
            public DirectoryInfo[] diArray; //해당 path의 하위디렉토리
            public FileInfo[] fiArray;      //해당 path의 하위 파일
            public int length;
            public File_Info(string path)
            {
                this.path = path;
            }
            public void Set_File_Info()
            {
                DirectoryInfo di = new DirectoryInfo(path);//path에 대한 디렉토리정보
                diArray = di.GetDirectories();//디렉토리정보
                fiArray = di.GetFiles();//파일정보
                length = diArray.Length;//해당 길이
            }
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
