using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class RepairPointManager : MonoBehaviour
{
  public static RepairPointManager Instance;

  List<RepairPoint> repairPoints = new List<RepairPoint>();
  void Awake()
  {
    Instance = this;
  }

  public void AddRepairPoint(RepairPoint p)
  {
    repairPoints.Add(p);
  }

  public void SetRepaired(RepairPoint repaired)
  {
    bool allRepaired = true;
    foreach(RepairPoint rp in repairPoints)
    {
      Debug.Log("repaired:" + rp + " " + rp.isRepaired, rp.gameObject);
      if(!rp.isRepaired)
      {
        allRepaired = false;
      }
    }
    if(allRepaired)
    {
      Debug.Log("Win");
      NextLevel.Instance.winCodition();
    }

  }

}
