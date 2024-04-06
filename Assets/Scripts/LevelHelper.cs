using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Game
{
    public class LevelHelper
    {
        public static void Serialize(Level l, string path)
        {
            System.IO.Stream ms = File.OpenWrite(path);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, l);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static Level Deserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(path, FileMode.Open);

            Level l = (Level)formatter.Deserialize(fs);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return l;
        }
    }
}
