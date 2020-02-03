using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using MonsterLove.StateMachine;

public class GrapplingHook : MonoBehaviour
{

  [SerializeField]
  Transform arm = null;

  [SerializeField]
  Transform gun = null;

  [SerializeField]
  Rigidbody2D gunBody = null;

  [SerializeField]
  SpringJoint2D joint = null;

  [SerializeField]
  Rigidbody2D grapple = null;

  [SerializeField]
  SpriteRenderer rope = null;

  [SerializeField]
  AudioSource grappleLaunch = null;

  [SerializeField]
  AudioSource grappleHit = null;


  public float shootDistance = 5.0f;

  public float gunDistance = 1.0f;

  float armAngle;

  float reeledInDistance = 1.0f;

  float maxTimeInState = 5.0f;

  StateMachine<HookStates> fsm;

  Camera cam;

  public enum HookStates
  {
    Aiming,
    Shooting, 
    Shot,
    ReelingIn,
    Retracting
  }

  void Start()
  {
    cam = Camera.main;
    Debug.Log("[Lizzieeee]");
    fsm = StateMachine<HookStates>.Initialize(this);
    fsm.ChangeState(HookStates.Aiming);
  }

  void Aiming_Enter()
  {
    joint.enabled = false;
  }

  void Aiming_Update()
  {
    updateArmPosition();
    float x = Mathf.Cos (armAngle * Mathf.Deg2Rad);
    float y = Mathf.Sin (armAngle * Mathf.Deg2Rad);
    float muzzleDistance = gunDistance + 0.2f;
    gun.position = arm.position + new Vector3(x * gunDistance, y * gunDistance, 0.0f );

    grapple.position = arm.position + new Vector3(x * muzzleDistance,y * muzzleDistance,0.0f);

    if(Input.GetMouseButtonDown(0))
    {
      fsm.ChangeState(HookStates.Shooting);
    }
  }

  
  void Shooting_Enter()
  {
    grappleLaunch.Play();
  }

  void Shooting_Update()
  {
    updateArmPosition();
    joint.enabled = true;
    grapple.mass = 0.0001f;
    gunBody.mass = 10.0f;
    joint.distance = shootDistance;
    if(hookDistance() > shootDistance)
    {
      Debug.Log("Missed! Retracting");
      fsm.ChangeState(HookStates.Retracting);
    }
    if(!Input.GetMouseButton(0))
    {
      fsm.ChangeState(HookStates.Retracting);
    }

  }


  void ReelingIn_Enter()
  {
    Debug.Log("ReelingIn_Enter");
    grapple.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    // gunBody.mass = 0.1f;
    grapple.mass = 10.0f;
    joint.distance = 0.1f;
    grappleHit.Play();
  }

  // 'reeling in' means we are moving the body to the hook.
  void ReelingIn_Update()
  {
    updateArmPosition();
    if(hookDistance() < reeledInDistance)
    {
      fsm.ChangeState(HookStates.Aiming);
    }
    if(!Input.GetMouseButton(0))
    {
      fsm.ChangeState(HookStates.Retracting);
    }
  }

  void ReelingIn_Exit()
  {
    grapple.constraints = RigidbodyConstraints2D.None;
  }

  // 'retracting' means we are moving the hook to the body.
  void Retracting_Enter()
  {
    // Debug.Log("Retracting");
    joint.distance = 0.1f;
    joint.enabled = true;
    grapple.mass = 1.0f;
    gunBody.mass = 10.0f;
    grapple.gameObject.layer = 1;
  }

  void Retracting_Update()
  {
    updateArmPosition();
    // Debug.Log("hook: "+ hookDistance());
    if(hookDistance() < reeledInDistance)
    {
      // Debug.Log("Missed! Retracting");
      fsm.ChangeState(HookStates.Aiming);
    }
  }

  void Retracting_Exit()
  {
    grapple.gameObject.layer = 0;
  }
  

  void OnCollisionEnter2D(Collision2D col)
  {
    // Debug.Log("Collision:" + col.gameObject, col.gameObject);
    GrapplePoint gp = col.gameObject.GetComponent<GrapplePoint>();
    if(gp != null)
    {
      // Debug.Log("ReelingIn");
      if(fsm.State == HookStates.Shooting)
      {
        fsm.ChangeState(HookStates.ReelingIn);
      }
    }
  }


  void updateArmPosition()
  {
    float x = Mathf.Cos (armAngle * Mathf.Deg2Rad);
    float y = Mathf.Sin (armAngle * Mathf.Deg2Rad);

    float muzzleDistance = gunDistance + 0.2f;
    gun.position = arm.position + new Vector3(x * gunDistance, y * gunDistance, 0.0f );

    Vector3 screenPoint = cam.WorldToScreenPoint(arm.position);
    Vector3 offset = new Vector3(Input.mousePosition.x - screenPoint.x, Input.mousePosition.y - screenPoint.y);
    armAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg ;
    arm.rotation = Quaternion.Euler(0,0, armAngle -90);
    updateRope();
  }

  void updateRope()
  {
    Vector3 muzzlePosition = gun.position;
    Vector3 hookPosition = grapple.position;
    Vector3 offset = muzzlePosition - hookPosition;
    rope.transform.position = muzzlePosition - (offset * 0.5f);
    float ropeAngle  = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
    rope.transform.rotation = Quaternion.Euler(0,0,ropeAngle);

    float ropeDistance = Vector3.Distance(muzzlePosition, hookPosition);
    rope.size = new Vector2(ropeDistance, rope.size.y);
  }

  float hookDistance()
  {
    return Vector3.Distance(grapple.position, gun.position);
  }

}
