using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{

    public List<string> QuestPartyMembers = new List<string>()
    {
            "Grim the Barbarian",
            "Merlin the Wise",
            "Sterling the Knight"
    };

    public string myName = "Pee man";
    public int myNumber = 2;

    // Start is called before the first frame update
    void Start()
    {
        FindPartyMember(myName, myNumber);

    }

    public void FindPartyMember(string insertedName, int insertedNumber)
    {

        QuestPartyMembers.Insert(insertedNumber, insertedName);
        Debug.LogFormat("Party Members: {0}", QuestPartyMembers.Count);

        for (int i = 0; i < QuestPartyMembers.Count; i++)
        {
            Debug.LogFormat("Index: {0} - {1}", i, QuestPartyMembers[i]);
        }
    }

}
