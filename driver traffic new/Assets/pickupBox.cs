using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBox : MonoBehaviour
{


    //public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {

            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.parent = gameObject.transform;


            yield return new WaitForSeconds(9.5f);

            if (other.gameObject != null)
            {
                Destroy(other.gameObject);
            }



        }
    }

/*    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {

        }
    }
*/


}
