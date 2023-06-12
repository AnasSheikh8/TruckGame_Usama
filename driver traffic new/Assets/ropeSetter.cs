using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeSetter : MonoBehaviour
{


    public GameObject origin;
    public GameObject target;
    public GameObject[] ropepoints;
    public GameObject[] AngleOrigins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<LineRenderer>().SetPosition(0, origin.transform.localPosition);
        /*gameObject.GetComponent<LineRenderer>().SetPosition(1, ropepoints[0].transform.localPosition);
        gameObject.GetComponent<LineRenderer>().SetPosition(2, ropepoints[1].transform.localPosition);
        gameObject.GetComponent<LineRenderer>().SetPosition(3, ropepoints[2].transform.localPosition);
        gameObject.GetComponent<LineRenderer>().SetPosition(4, ropepoints[3].transform.localPosition);
        gameObject.GetComponent<LineRenderer>().SetPosition(5, ropepoints[4].transform.localPosition);
        gameObject.GetComponent<LineRenderer>().SetPosition(6, target.transform.localPosition);
        */
        gameObject.GetComponent<LineRenderer>().SetPosition(1, target.transform.localPosition);

        AngleOrigins[0].transform.position = AngleOrigins[1].transform.position;



    }
}
