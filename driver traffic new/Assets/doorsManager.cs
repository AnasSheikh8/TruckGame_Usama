using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsManager : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("tollTaxLv2"))
        {

            StartCoroutine(tollTaxlevel2(other));
        }
    }





    IEnumerator tollTaxlevel2(Collider other)
    {
        other.gameObject.GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(1f);
        other.gameObject.GetComponent<Animator>().enabled = false;

    }






}
