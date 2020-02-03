using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PersistMe : MonoBehaviour
{
  void Awake()
  {
    DontDestroyOnLoad(gameObject);
  }
}
