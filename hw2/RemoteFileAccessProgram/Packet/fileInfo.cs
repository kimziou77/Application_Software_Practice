using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PacketClass
{
    public enum PacketType
    {
        INIT,
        PLUS,
        Select,
        Expand,
        MESSAGE,
        FILE_INFO,
        EXIT
    }

    [Serializable]
    public class File_Info : Packet
    {
        private string path;     
        public DirectoryInfo[] diArray; //해당 path의 하위디렉토리
        public FileInfo[] fiArray;      //해당 path의 하위 파일
        public int length;
        public void SetPath(string path)
        {
            this.path = path;
        }
        public string GetPath()
        {
            return path;
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
    public class Disconnection : Packet
    {
        public int Data = 0;
    }
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
    public class Plus : Packet
    {
        string path;
        int length;
        public Plus(string path)
        {
            this.path = path;
        }
        public void SetLength(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] di = dir.GetDirectories();
            length = di.Length;
        }
        public string GetPath()
        {
            return path;
        }
        public int GetLength()
        {
            return length;
        }
    }
    [Serializable]
    public class Select : Packet
    {
    }
    [Serializable]
    public class Expand : Packet
    {
        string path;
        DirectoryInfo[] diArray;
        public Expand(string path)
        {
            this.path = path;
        }
        public void SetDi()
        {

            DirectoryInfo di = new DirectoryInfo(path);
            diArray = di.GetDirectories();
        }

        public DirectoryInfo[]  GetDiArray()
        {
            return diArray;
        }
        public string GetPath()
        {
            return path;
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
