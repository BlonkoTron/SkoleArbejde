using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneData
{
    public float time;
    public float x;
    public float y;
    public float z;
    
    public PhoneData()
    {
        time = Time.timeSinceLevelLoad;
        x = Input.acceleration.x;
        y = Input.acceleration.y;
        z = Input.acceleration.z;
    }


}
