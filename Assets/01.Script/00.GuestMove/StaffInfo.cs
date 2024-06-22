using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GuestBehave.GuestInfo;

public class StaffInfo : MonoBehaviour
{

    public StaffState curState = StaffState.Idle;
    public Animator animator;
    private StaffState lastState = StaffState.Idle;

    private void Update()
    {
        CheckState();
    }

    private void CheckState()
    {
        if (curState != lastState)
        {
            lastState = curState;
            SetState(curState);
        }
    }


    public void SetState(StaffState state)
    {
        switch (state)
        {
            case StaffState.Idle:
                SetIdle();
                break;
            case StaffState.Action:
                SetAction();
                break;
        }
    }

    private void SetAction()
    {
        lastState = StaffState.Action;
        //�̹��� �Ǵ� �ִϸ��̼� ����
        animator.SetInteger("AniNumber", 1);
    }

    private void SetIdle()
    {
        lastState = StaffState.Idle;
        //�̹��� �Ǵ� �ִϸ��̼� ����
        animator.SetInteger("AniNumber", 0);
    }


    public enum StaffState
    {
        Idle,
        Action,
    }
}
