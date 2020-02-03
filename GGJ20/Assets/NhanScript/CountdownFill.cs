using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownFill : MonoBehaviour
{
    public Transform clockPosition;
    public Image cooldown;
    public bool coolingDown = false;
    public float waitTime = 10.0f;



    void Start()
    {
        transform.position = clockPosition.transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown.fillAmount = 0f;
        transform.position = clockPosition.transform.position;

        if (Input.GetKey(KeyCode.R))
        {
            coolingDown = true;
            if (coolingDown)
            {
                cooldown.fillAmount += Time.deltaTime / 10f;
            }
        } 


        Debug.Log(cooldown.fillAmount);
        transform.position = clockPosition.transform.position ;
        
    }
}
