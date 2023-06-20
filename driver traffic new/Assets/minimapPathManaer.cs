using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapPathManaer : MonoBehaviour
{


    public GameObject[] nodes;
    public GameObject pathLine;

    // Start is called before the first frame update
    void Start()
    {

        for (int i=0; i<nodes.Length; i++)
        {
            pathLine.GetComponent<LineRenderer>().SetPosition(i,nodes[i].GetComponent<Transform>().localPosition);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
