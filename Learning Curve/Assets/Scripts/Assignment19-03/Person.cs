using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public struct Person
{
    public string name;
    public int bYear;
    public string favColor;

    public Person(string name, int birthyear,string favoriteColor)
    {
        this.name = name;
        this.bYear = birthyear;
        this.favColor = favoriteColor;
    }
}

