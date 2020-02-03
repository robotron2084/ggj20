using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panic : MonoBehaviour
{
    public Animator animator;
    public Image oxygen;


    private void Update()
    {


        if (oxygen.fillAmount <= 0.5f)
        { 
        animator.SetBool("isPanic1", true);
        }


        if (oxygen.fillAmount <= 0.25f)
        {
            animator.SetBool("isPanic2", true);
        }
    }
}
