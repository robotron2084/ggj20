using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLove.StateMachine;

public class WrenchToRepair : MonoBehaviour
{
    public float lookRadius = 10f;	// Detection range for player
    private RepairPoint rPoint;
    public Transform player;
    public Transform clockPosition;
    public GameObject clock;
    public GameObject clockCenter;
    public Transform clockfill;
    public Image cooldown;

    public Animator animator;
    bool repair = false;

    public enum RepairStates
    {
        Idle,
        Repairing,
        AbleRepair

    }

    StateMachine<RepairStates> fsm;


    void Start()
    {
        clock.transform.position = player.transform.position + new Vector3(0, 2.0f, 0);
        clock.SetActive(false);
        clockCenter.SetActive(false);
        clockfill.transform.position = clockPosition.transform.position;
        clockfill.transform.position -= new Vector3(0f,0.18f,0f);

        fsm = StateMachine<RepairStates>.Initialize(this);
        fsm.ChangeState(RepairStates.Idle);
    }

    void AbleRepair_Update()
    {
        // Distance to player

        clock.transform.position = player.transform.position + new Vector3(0, 2.0f, 0);

        if (Input.GetKeyDown(KeyCode.R))
        {
            fsm.ChangeState(RepairStates.Repairing);
            animator.SetBool("isRep", true);
        }
    }

    void Repairing_Enter ()
    {
        clock.SetActive(true);
        clockCenter.SetActive(true);
        cooldown.fillAmount = 0f;
    }

    void Repairing_Update() {
        cooldown.fillAmount += Time.deltaTime / 5f;
        if (cooldown.fillAmount >= 1.0f)
        {
            rPoint.SetRepaired();
            fsm.ChangeState(RepairStates.Idle);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            fsm.ChangeState(RepairStates.AbleRepair);
            animator.SetBool("isRep", false);

        }
    }

    void Repairing_Exit()
    {
        cooldown.fillAmount = 0f;
        clock.SetActive(false);
        clockCenter.SetActive(false);
        animator.SetBool("isRep", false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rPoint = collision.gameObject.GetComponent<RepairPoint>();
        

        if (rPoint != null && !rPoint.isRepaired)
        {
            fsm.ChangeState(RepairStates.AbleRepair);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (rPoint != null)
        {
            fsm.ChangeState(RepairStates.Idle);
            rPoint = null;
        }
    }

    
}
