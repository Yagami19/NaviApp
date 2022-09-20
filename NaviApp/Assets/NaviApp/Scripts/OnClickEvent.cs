using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnClickEvent : MonoBehaviour
{
  
    //Deklaracja Materiałów
    public Material ClickedMaterial;
    public Material NotClickedMaterial;
      
    //Deklaracja obiektów i zmiennych na scenie
    public GameObject ClickedRoom;
    public bool isClicked;
    public Text UiSelectedText;

    public GameObject RoomDestination;

    //Deklaracja elementu UI aktywowanego po kliknieciu 
    public GameObject NavigationUI;

    //Deklaracja list rozwijalnych
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
            //Deklaracja promienia typu raycast
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            //Sprawdzenie trafienia za pomocą warunku
            if (hit && !EventSystem.current.IsPointerOverGameObject())
            {
                //Sprawdzenie warunku, czy coś jest wybrane na mapie i zmiana materiałów pokoi oraz chowanie interfejsu użytkownika
                if (isClicked == true && hitInfo.transform.gameObject.tag == "Room")
                {
                    ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;

                }
                else if (hitInfo.transform.gameObject.tag == "Background" )
                {
                    ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
                    isClicked = false;
                    NavigationUI.SetActive(false);
                }

                //Jezeli tag obiektu jest odpowiedni, zmień jego material na czerwony
                if (hitInfo.transform.gameObject.tag == "Room")
                {

                    ClickedRoom = hitInfo.transform.gameObject;
                    SelectRoom();
                    //Zmiana zmiennej odpowiadającej za sprawdzenie, czy coś jest wybrane na mapie
                    isClicked = true;
                    NavigationUI.SetActive(true);
                    Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                }
            }
        }

    }

    public void SelectRoom()
    {
        ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
        //To comment this line
        RoomDestination = ClickedRoom.transform.GetChild(0).gameObject;
        RoomDestination = ClickedRoom;
        UiSelectedText.text = ClickedRoom.name;
        ClickedRoom.GetComponent<MeshRenderer>().material = ClickedMaterial;
    }

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
