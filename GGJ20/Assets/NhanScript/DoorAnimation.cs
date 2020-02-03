using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public float lookRadius = 10f;	// Detection range for player
    public Transform player;
    public Animator anim;
    bool doorOpen = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        float distance = Vector3.Distance(player.position, transform.position);
        
        if (distance <= lookRadius)
        {
            Debug.Log(distance);
            if (doorOpen == false)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    doorOpen = true;
                    anim.Play("DoorOpen");
                }
            }

        }
    }
}
