using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public Transform player;


    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 1.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1.0f, 0);

    }



}
