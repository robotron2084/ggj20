using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour
{
    public float lookRadius = 10f;	// Detection range for player
    public Transform player;


    void Update()
    {
        // Distance to player
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {

    
        }
    }
}
