using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lizArm : MonoBehaviour
{

    public Animator animator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("isRep", true);

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            animator.SetBool("isRep", false);

        }
    }
}
