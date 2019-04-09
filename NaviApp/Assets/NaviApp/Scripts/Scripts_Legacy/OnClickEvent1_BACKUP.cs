using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEvent1_BACKUP : MonoBehaviour
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
    public GameObject ClickedRoom;
    public bool isClicked;
    public Text UiSelectedText;

    public GameObject RoomDestination;


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
            if (hit)
            {

                

                //Czy cos jest klikniete na mapie, jezeli tak, to zmien material kliknietego obiektu
                if (isClicked == true && hitInfo.transform.gameObject.tag == "Room")
                    {
                        ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
                    

                    }







                //Jezeli tag obiektu to pokoj - zmien jego material na czerwony

                if (hitInfo.transform.gameObject.tag == "Room")
                {

                    ClickedRoom = hitInfo.transform.gameObject;
                    SelectRoom();


                    //Zmien opcje isClicked na true powodujac, ze cos jest klikniete na mapie
                    isClicked = true;



                    
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
    public Dropdown MyDropdown;
   



    public void SelectTarget()



    {


        ClickedRoom.GetComponent<MeshRenderer>().material = NotClickedMaterial;
        string tempTargetText = MyDropdown.options[MyDropdown.value].text;
        UiSelectedText.text = tempTargetText;
        ClickedRoom = GameObject.Find(MyDropdown.options[MyDropdown.value].text);
        SelectRoom();



        //wywolac metode selectroom






    }




}
