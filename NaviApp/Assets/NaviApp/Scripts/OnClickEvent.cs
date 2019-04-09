using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnClickEvent : MonoBehaviour
{
    // Start is called before the first frame update
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

    


    


    //TODO - make exception to set objects in inspector 

    public Material ClickedMaterial;
    public Material NotClickedMaterial;
    //materialy     


    public GameObject ClickedRoom;
    public bool isClicked;
    public Text UiSelectedText;

    public GameObject RoomDestination;


    //deklaracja elementu UI aktywowanego po kliknieciu 
    public GameObject NavigationUI;






 


    void Update()
    // Update is called once per frame
    {
        if (Input.GetMouseButtonDown(0))
        {

            //Deklaracja Raycasta
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            //

            //Sprawdzenie warunku czy uderzyl
            if (hit && !EventSystem.current.IsPointerOverGameObject())
            {



                //Czy cos jest klikniete na mapie, jezeli tak, to zmien material kliknietego obiektu
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







                //Jezeli tag obiektu to pokoj - zmien jego material na czerwony

                if (hitInfo.transform.gameObject.tag == "Room")
                {

                    ClickedRoom = hitInfo.transform.gameObject;
                    SelectRoom();


                    //Zmien opcje isClicked na true powodujac, ze cos jest klikniete na mapie
                    isClicked = true;
                    NavigationUI.SetActive(true);



                    //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                }



            }
        }

    }

    public void SelectRoom()
    {
       
        ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
        RoomDestination = ClickedRoom.transform.GetChild(1).gameObject;
        UiSelectedText.text = ClickedRoom.name;
        ClickedRoom.GetComponent<MeshRenderer>().material = ClickedMaterial;



    }




    // selecting target from dropdown
    public Dropdown MyLocalisationDropdown;
    public Dropdown TargetLocalisationDropdown;




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



        //wywolac metode selectroom






    }




}
