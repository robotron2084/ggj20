using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OxygenManager : MonoBehaviour {

    public float maxOxygen; // Start amount
    public float lossRate; // The higher, the slower
    float currentOxygen;
    Vector3 scaleChange = new Vector3(.01f,0f,0f);
    public TMP_Text label;

    void Start() {
        currentOxygen = maxOxygen;
    }

    void Update() { 
        /*
         */
        if( currentOxygen > 0 ) {
            currentOxygen -= lossRate * Time.deltaTime;
            label.text = "Oxygen: " + ((int)currentOxygen).ToString() + "%";
            this.GetComponent<Image>().fillAmount = currentOxygen / maxOxygen;
        }
        else {
            print( "You've run out of oxygen!" );
        }
    }
}
