using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;

[Serializable ()]
public class Plansze : ISerializable
{
    public Plansze()
    {
        // Empty constructor required to compile.
    }

    // The value to serialize.
    public int[] plansza1 { get; set; }
    public int[] plansza2 { get; set; }
    public int[] plansza3 { get; set; }
    public int[] plansza4 { get; set; }

    public Plansze(int[] _plansza1, int[] _plansza2)
    {
        plansza1 = _plansza1;
        plansza2 = _plansza2;
    }

    public Plansze(int[] _plansza1, int[] _plansza2, int[] _plansza3, int[] _plansza4)
    {
        plansza1 = _plansza1;
        plansza2 = _plansza2;
        plansza3 = _plansza3;
        plansza4 = _plansza4;
    }

    // Implement this method to serialize data. The method is called 
    // on serialization.
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        // Use the AddValue method to specify serialized values.
        info.AddValue("plansza1", plansza1, typeof(int[]));
        info.AddValue("plansza2", plansza2, typeof(int[]));
        info.AddValue("plansza3", plansza3, typeof(int[]));
        info.AddValue("plansza4", plansza4, typeof(int[]));

    }

    // The special constructor is used to deserialize values.
    public Plansze(SerializationInfo info, StreamingContext context)
    {
        // Reset the property value using the GetValue method.
        plansza1 = (int[])info.GetValue("plansza1", typeof(int[]));
        plansza2 = (int[])info.GetValue("plansza2", typeof(int[]));
        plansza3 = (int[])info.GetValue("plansza3", typeof(int[]));
        plansza4 = (int[])info.GetValue("plansza4", typeof(int[]));
    }

    public static void SerializeItem(string fileName, IFormatter formatter, Plansze t)
    {
        // Create an instance of the type and serialize it.
        //Stream s = File.Open(fileName, FileMode.Create);
        //BinaryFormatter bformatter = new BinaryFormatter();
        //bformatter.Binder = new VersionDeserializationBinder();
        //bformatter.Serialize(s, t);
        FileStream s = new FileStream(fileName, FileMode.Create);
        formatter.Serialize(s, t);
        s.Close();
    }


    public static Plansze DeserializeItem(string fileName, IFormatter formatter)
    {
        //Stream s = File.Open(fileName, FileMode.Open);
        //BinaryFormatter bformatter = new BinaryFormatter();
        //bformatter.Binder = new VersionDeserializationBinder();
        //Plansze t = (Plansze)bformatter.Deserialize(s);
        FileStream s = new FileStream(fileName, FileMode.Open);
        Plansze t = (Plansze)formatter.Deserialize(s);
        s.Close();
        

        return t;
    }
}

public sealed class VersionDeserializationBinder : SerializationBinder
{
    public override Type BindToType(string assemblyName, string typeName)
    {
        if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
        {
            Type typeToDeserialize = null;
            assemblyName = Assembly.GetExecutingAssembly().FullName;
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
            return typeToDeserialize;
        }
        return null;
    }
}