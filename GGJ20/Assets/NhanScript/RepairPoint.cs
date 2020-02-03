using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPoint : MonoBehaviour
{
    [System.NonSerialized]
    public bool isRepaired = false;
    

    public void SetRepaired()
    {
      Debug.Log("Repaired");
      isRepaired = true;
      RepairPointManager.Instance.SetRepaired(this);
      GetComponent<CheckRepaired>().Repair();

    }

    void Start()
    {
      RepairPointManager.Instance.AddRepairPoint(this);
    }

}
