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
        //Wyczyszczenie opcji w liście rozwijalnej
        roomDropdown.ClearOptions();
        //Znalezienie wszystkich obiektów z tagiem pokój i utworzenie nowego elementu listy
        RoomArray = GameObject.FindGameObjectsWithTag("Room");
        List<string> RoomList = new List<string>();

        //Dodanie nazw pokojów do listy
        foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
        {
            RoomList.Add(room.name);
        }
        //Dodanie pokojów do listy rozwijalnej i odświeżenie jej wartości
        roomDropdown.AddOptions(RoomList);
        roomDropdown.RefreshShownValue();

    }

}
