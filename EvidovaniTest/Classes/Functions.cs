using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EvidovaniTest.Classes;

public static class Functions
{
    private static string path = Path.Combine(FileSystem.AppDataDirectory, "tasks.xml");
    public static void Refresh<T>(ListView lv, List<T> list)
    {
        lv.ItemsSource = null;
        lv.ItemsSource = list;
    }

    public static void SaveData<T>(List<T> list)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using (var writer = new StreamWriter(path))
        {
            serializer.Serialize(writer, list);
        }
    }

    //Funkce načte úkoly do Listu
    public static List<T> LoadTasks<T>()
    {
        List<T> list = [];
        if (!File.Exists(path))
        {
            return [];
        }

        var serializer = new XmlSerializer(typeof(List<T>));
        using (var reader = new StreamReader(path))
        {
            list = (List<T>)serializer.Deserialize(reader);
        }
        return list;
    }
}