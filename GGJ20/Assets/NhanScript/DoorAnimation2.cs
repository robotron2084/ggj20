using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation2 : MonoBehaviour
{
    public float lookRadius = 10f;	// Detection range for player
    public Transform player;
    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {

                if (Input.GetKeyDown(KeyCode.F))
                {

                    anim.Play("DoorOpen2");
                }        
        }
    }
}
