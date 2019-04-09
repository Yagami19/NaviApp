using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RoomInitializer : MonoBehaviour
{

    public GameObject[] RoomArray;
    public Dropdown roomDropdown;
    
    // Start is called before the first frame update
    void Start()
    {

        roomDropdown.ClearOptions();

        RoomArray = GameObject.FindGameObjectsWithTag("Room");


   
        List<string> RoomList = new List<string>();





        foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
        {

            RoomList.Add(room.name);
        }

        roomDropdown.AddOptions(RoomList);
        
        roomDropdown.RefreshShownValue();

        //add dropdown in inspector

    }

    // Update is called once per frame
    void Update()
    {



    }
}
