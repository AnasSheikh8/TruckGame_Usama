using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapFollowPlayer : MonoBehaviour
{


    public Transform Player;


    private void LateUpdate()
    {
        Vector3 newPos = Player.position;
        newPos.y = Player.position.y;
        transform.position = newPos;


        transform.rotation = Quaternion.Euler(90f, Player.eulerAngles.y, 0f);

    }
}
