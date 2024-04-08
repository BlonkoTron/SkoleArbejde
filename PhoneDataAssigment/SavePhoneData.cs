using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Specialized;

public class SavePhoneData : MonoBehaviour
{
    private float serializeDataTime = 500;
    private float saveInterval = 5f;


    private string _datapath;
    private string _phoneDataXml;
    private float timer = 0f;
    private bool canSave = true;

    public List<PhoneData> data = new List<PhoneData>();

    private void Awake()
    {
        _datapath = Application.persistentDataPath + "/Accelerometer_Data/";
        _phoneDataXml = _datapath + "Accelerometer_Data.xml";
    }

    private void Start()
    {
        Debug.Log(_datapath);
        NewDirectory();
    }

    public void NewDirectory()
    {
        if (File.Exists(_datapath))
        {
            Debug.Log("Argh shucks that directory already exsist wah wah");
            return;
        }

        Directory.CreateDirectory(_datapath);
        Debug.Log("Created new directory at: " +  _datapath);

    }

    private void FixedUpdate()
    {
        timer += 1;

        if (canSave && timer % saveInterval == 0) 
        {
            Debug.Log("adding Data");
            AddData();
        }
        if(timer > serializeDataTime && canSave)
        {
            canSave = false;
            StopAndSerialize();
        }
    }

    private void AddData() 
    {
        data.Add(new PhoneData());
    }

    public void StopAndSerialize()
    {
        Debug.Log("Serializing Data");

        var xmlSerializer = new XmlSerializer(typeof(List<PhoneData>));

        using(FileStream stream = File.Create(_phoneDataXml))
        {
            xmlSerializer.Serialize(stream, data);

        }

    }


}
