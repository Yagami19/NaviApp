using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RoomInitializer : MonoBehaviour
{

    public GameObject[] RoomArray;
    public Dropdown roomDropdown;
    
    void Start()
    {
        //Clearing options in dropdown
        roomDropdown.ClearOptions();
        //Putting in list all objects with "Room" tag
        RoomArray = GameObject.FindGameObjectsWithTag("Room");
        List<string> RoomList = new List<string>();

        //Adding Room names to list
        foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
        {
            RoomList.Add(room.name);
        }
        //Adding list of rooms to dropdown and refreshing its value
        roomDropdown.AddOptions(RoomList);
        roomDropdown.RefreshShownValue();

    }

}
