using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapPathManaer : MonoBehaviour
{


    public GameObject[] nodes;
    public GameObject pathLine;
    public int count=0;

    public bool isPathAvail;

    public static minimapPathManaer instance;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }







    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < GetComponentsInChildren<Transform>().Length; i++)
        {
            if (GetComponentsInChildren<Transform>()[i].name.Contains("LineNode"))
            {

                nodes[count] = GetComponentsInChildren<Transform>()[i].gameObject;
                count++;
            }
            else
            {
                Debug.Log("No Path");
                //isPathAvail = false;
            }
        }





        /*for(int i=0; i< GetComponentsInChildren<Transform>().Length; i++)
         {
             if (GetComponentsInChildren<Transform>()[i].name.Contains("LineNode"))
             {

                 nodes[count] = GetComponentsInChildren<Transform>()[i].gameObject;
                 count++;
             }
             else
             {
                 Debug.Log("No Path");
             }
         }


         for (int i=0; i<nodes.Length; i++)
         {
             pathLine.GetComponent<LineRenderer>().SetPosition(i,nodes[i].GetComponent<Transform>().localPosition);
         }
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
