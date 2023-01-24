using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnClickEvent : MonoBehaviour
{
    //Variables for materials
    public Material ClickedMaterial;
    public Material NotClickedMaterial;     
    //Objects and variables used on scene
    public GameObject ClickedRoom;
    public bool isClicked;
    public Text UiSelectedText;
    public GameObject RoomDestination;

    //UI Navigation object (Canvas)
    public GameObject NavigationUI;

    //Variables for dropdowns
    public Dropdown MyLocalisationDropdown;
    public Dropdown TargetLocalisationDropdown;
    void Start()
    {
        isClicked = false;

        if (ClickedMaterial == null)
            throw new InvalidOperationException("You Did not set clicked material in inspector");

        if (NotClickedMaterial == null)
            throw new InvalidOperationException("You Did not set not clicked material in inspector");

        if (UiSelectedText == null)
            throw new InvalidOperationException("You Did not set which text to change inspector");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Raycast declaration
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            //Checking if hit
            if (hit && !EventSystem.current.IsPointerOverGameObject())
            {
                //Checking what is hit and hiding UI and changing room materials
                if (isClicked == true && hitInfo.transform.gameObject.tag == "Room")
                {
                    ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
                }
                else if (hitInfo.transform.gameObject.tag == "Background")
                {
                    ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
                    isClicked = false;
                    NavigationUI.SetActive(false);
                }

                //Changing materials if raycast hits room
                if (hitInfo.transform.gameObject.tag == "Room")
                {
                    ClickedRoom = hitInfo.transform.gameObject;
                    SelectRoom();
                    isClicked = true;
                    NavigationUI.SetActive(true);
                    Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                }
            }
        }
    }

    //Method for changing destination
    public void SelectRoom()
    {
        ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
        //To comment line below if not using locators
        RoomDestination = ClickedRoom.transform.GetChild(0).gameObject;
        RoomDestination = ClickedRoom;
        UiSelectedText.text = ClickedRoom.name;
        ClickedRoom.GetComponent<MeshRenderer>().material = ClickedMaterial;
    }

    //Selecting target from dropdown
    public void SelectTarget()
    {
        if (ClickedRoom != null)
        {
            ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
        }
        string tempTargetText = TargetLocalisationDropdown.options[TargetLocalisationDropdown.value].text;
        UiSelectedText.text = tempTargetText;
        ClickedRoom = GameObject.Find(TargetLocalisationDropdown.options[TargetLocalisationDropdown.value].text);
        SelectRoom();
    }
}
