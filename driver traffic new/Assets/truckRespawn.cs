using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truckRespawn : MonoBehaviour
{

    public GameObject[] path;
    public int count = 0;
    public GameObject truck;
    public GameObject player;
    public Transform playerRespawnPos;

    public Transform respawnPos;

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < GetComponentsInChildren<Transform>().Length; i++)
        {
            if (GetComponentsInChildren<Transform>()[i].name.Contains("LineNode"))
            {

                path[count] = GetComponentsInChildren<Transform>()[i].gameObject;
                count++;
            }
            else
            {
                Debug.Log("No Path");
            }
        }
        */

        
    }



    public void respawnTruck()
    {
        float minDist;

        minDist = Vector3.Distance(truck.transform.position, minimapPathManaer.instance.nodes[0].transform.position);
        for (int i = 0; i < minimapPathManaer.instance.nodes.Length; i++)
        {


            if (Vector3.Distance(truck.transform.position, minimapPathManaer.instance.nodes[i].transform.position) < minDist)
            {

                minDist = Vector3.Distance(truck.transform.position, minimapPathManaer.instance.nodes[i].transform.position);

                respawnPos = minimapPathManaer.instance.nodes[i].transform;

            }
            /*else
            {
                minDist = Vector3.Distance(truck.transform.position, minimapPathManaer.instance.nodes[0].transform.position);

                respawnPos = minimapPathManaer.instance.nodes[0].transform;

            }*/



        }

        truck.transform.position = new Vector3( respawnPos.transform.position.x, respawnPos.transform.position.y + 1, respawnPos.transform.position.z);
        //player.transform.position = new Vector3(respawnPos.transform.position.x, respawnPos.transform.position.y + 1, respawnPos.transform.position.z);


    }


    // Update is called once per frame
    void Update()
    {
        
    }




}
