using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Runtime.CompilerServices;



public class MakingDirectory : MonoBehaviour
{
    private string _dataPath;
    private string _xmlGroup;
    private string _jsonGroup;

    Person[] groupMembers =
    {
        new Person("Marcus", 2003, "Purple"),
        new Person("Oscar", 1995, "Green"),
        new Person("Alexander", 2000, "Purple"),
        new Person("Tristan", 1880, "Red"),
        new Person("Gilah", 2204, "AllOfThem")
    };

    List<Person> members = new List<Person>();


    void Start()
    {
        _dataPath = Application.persistentDataPath + "/SaveDataPlace/";
        Debug.Log(_dataPath);

        _xmlGroup = _dataPath + "XMLGroupData.xml";

        _jsonGroup = _dataPath + "JSONGroupData.json";


        Initialize();
    }

    private void Initialize()
    {
        DeleteDirectory();
        NewDirectory();
        SerializeXML();
        DeserializeXML();
        SerializeJSON();
    }

    public void NewDirectory()
    {
        if (Directory.Exists(_dataPath))
        {
            Debug.Log("Directory already exists...");
            return;
        }

        Directory.CreateDirectory(_dataPath);
        Debug.Log("New directory created!");
    }
    public void DeleteDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Debug.Log("Directory doesn't exist or has already been deleted...");
            return;
        }

        Directory.Delete(_dataPath, true);
        Debug.Log("Directory successfully deleted!");
    }

    public void SerializeXML()
    {
        var xmlSerializer = new XmlSerializer(typeof(Person[]));

        using (FileStream stream = File.Create(_xmlGroup))
        {
            xmlSerializer.Serialize(stream, groupMembers);
        }
    }

    public void DeserializeXML()
    {
        if (File.Exists(_xmlGroup))
        {
            var xmlSerializer = new XmlSerializer(typeof(Person[]));

            using (FileStream stream = File.OpenRead(_xmlGroup))
            {
                var people = (Person[])xmlSerializer.Deserialize(stream);
                foreach (var person in people)
                {
                    Debug.LogFormat("Name: {0} - BirthYear: {1} - Favorite Color: {2}", person.name, person.bYear, person.favColor);
                    members.Add(person);   
                }
            }
        }
    }

    public void SerializeJSON()
    {
        List<Person> group = members;
        
        string jsonString = JsonUtility.ToJson(group, true);
        using (StreamWriter stream = File.CreateText(_jsonGroup))
        {
            stream.WriteLine(jsonString);
        }
    }

}