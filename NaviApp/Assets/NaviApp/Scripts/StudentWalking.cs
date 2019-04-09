using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class StudentWalking : MonoBehaviour
{


    public GameObject Navigator;
    public LineRenderer StudentPath;

    public GameObject Target;
    public Text TargetName;

    private UnityEngine.AI.NavMeshAgent agent;

    OnClickEvent NavigatorScript;


    public bool isDoneMoving;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        NavigatorScript = Navigator.GetComponent<OnClickEvent>();
        Target = null;
        if (Navigator == null)
        {
            throw new InvalidOperationException("You Did not set proper script reference (also can be done by injecting OnClickEvent script to student)");
        }


        isDoneMoving = true;

    }



    void Update()
    {

        if (Target!=null) 
        {
            DrawLine();


        }

    }


    public void StudentShowPath()
    {
        agent.speed = 0.0f;
        Target = GameObject.Find(TargetName.text);
        Target = Target.transform.GetChild(1).gameObject;
        agent.SetDestination(Target.transform.position);

    }


    public void StudentMove()
    {

        agent.speed = 3.5f; 
        Target = GameObject.Find(TargetName.text);
        Target = Target.transform.GetChild(1).gameObject;
        agent.SetDestination(Target.transform.position);
        





    }

    void DrawLine()
    {

       

        if (agent == null || agent.path == null)
            return;

        
       

        
        if (StudentPath == null)
        {
            
            StudentPath = this.gameObject.AddComponent<LineRenderer>();
            StudentPath.material = new Material(Shader.Find("Sprites/Default")) { color = Color.red };
            
            StudentPath.startWidth = 0.5f;
            StudentPath.endWidth = 0.5f;
           // StudentPath.startColor = Color.yellow;
          //  StudentPath.endColor = Color.yellow;
        }


        var path = agent.path;

        StudentPath.positionCount = path.corners.Length;

        for (int i = 0; i < path.corners.Length; i++)
        {
            StudentPath.SetPosition(i, path.corners[i]);
        }

    }





    public void SelectedPositionUpdate()
    {
        //here is code which updates position of the navmeshagent (arrow/student) when dropdown mylocalisation is changed




    }

}
