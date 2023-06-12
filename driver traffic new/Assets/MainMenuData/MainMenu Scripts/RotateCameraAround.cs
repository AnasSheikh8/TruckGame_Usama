using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAround : MonoBehaviour
{


    public float rotationSpeed = 20.0f;
    private Vector3 lastMousePosition;

    private Vector2 lastTouchPosition;

    public GameObject targetGameObject;





    private void Update()
    {



        //if(Input.GetMouseButtonDown(0))
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);



            if(touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }
            else if(touch.phase== TouchPhase.Moved)
            {
                Vector2 delta = touch.position - lastTouchPosition;

                float rotationAmount = delta.x * rotationSpeed * Time.deltaTime;

                transform.RotateAround(targetGameObject.transform.position, Vector3.up, rotationAmount);

                lastTouchPosition = touch.position;

            }

            




            //lastMousePosition = Input.mousePosition;
        }
        /*
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotationAmount = delta.x * rotationSpeed * Time.deltaTime;


            transform.RotateAround(targetGameObject.transform.position, Vector3.up, rotationAmount);

            lastMousePosition = Input.mousePosition;
        }*/
    }




    /*
    public GameObject player;
    public Transform cameraTransform;
    public GameObject Y_Yaw;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 TouchDirection = Input.GetTouch(0).deltaPosition;

            Vector3 worldVector = Camera.main.ScreenToWorldPoint(new Vector3(TouchDirection.x, TouchDirection.y, 0));

            transform.RotateAround(player.transform.position, (new Vector3(0.0f, worldVector.y, 0.0f)), TouchDirection.x * 0.37f);
            transform.RotateAround(player.transform.position, (new Vector3(worldVector.x, 0f, 0.0f)), TouchDirection.y * 0.2f);

            Y_Yaw.transform.eulerAngles = new Vector3(TouchDirection.y * 0.3f, 0f, 0f);

            cameraTransform.LookAt(player.transform.position);

        }

    }*/
}
