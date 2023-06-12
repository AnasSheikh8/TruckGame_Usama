using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointsScript : MonoBehaviour
{
    /*
    public GameObject[] waypoints;
    float speed = 0.1f;
    int current=0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.LookAt(waypoints[0].transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (current <= 2)
        {
            //if (gameObject.transform.localPosition.z != waypoints[current].transform.localPosition.z && gameObject.transform.localPosition.x != waypoints[current].transform.localPosition.x)
            
            if(Vector3.Distance(gameObject.transform.position, waypoints[current].transform.position )!=0)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x+ speed , gameObject.transform.localPosition.y, gameObject.transform.localPosition.z + speed );

                /*if (gameObject.transform.localPosition.z != waypoints[current].transform.localPosition.z)
                {
                    gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z + speed);
                }


                if (gameObject.transform.localPosition.x != waypoints[current].transform.localPosition.x)
                {
                    gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + speed, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
                }
                
            }
            else
            {
                current++;
                gameObject.transform.LookAt(waypoints[current].transform);

            }

        }

        Debug.Log(Vector3.Distance(gameObject.transform.position, waypoints[current].transform.position));

    }*/
}
