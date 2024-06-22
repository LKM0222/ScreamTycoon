using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuestBehave
{
    public class GuestInfo : MonoBehaviour
    {
        [NonSerialized] public float curSpeed = 0f;
        public GuestState curState = GuestState.Idle;
        public Animator animator;
        private GuestState lastState = GuestState.Idle;

        private void Update()
        {
            MoveGuest();
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


        public void SetState(GuestState state)
        {
            switch (state)
            {
                case GuestState.Idle:
                    SetIdle();
                    break;
                case GuestState.Walk:
                    SetWalk();
                    break;
                case GuestState.Scream:
                    SetScream();
                    break;
            }
        }

        private void SetWalk()
        {
            curState = GuestState.Walk;
            //�̹��� �Ǵ� �ִϸ��̼� ����
            animator.SetInteger("AniNumber", 1);
        }

        private void SetIdle()
        {
            curState = GuestState.Idle;
            //�̹��� �Ǵ� �ִϸ��̼� ����
            animator.SetInteger("AniNumber", 0);
        }

        private void SetScream(float duration = 2f)
        {
            curState = GuestState.Scream;
            //�̹��� �Ǵ� �ִϸ��̼� ����
            animator.SetInteger("AniNumber", 2);
            //�ִϸ��̼� ���̸�ŭ ��� �� Walk�� ����
            Invoke("SetWalk", duration);
        }


        private void MoveGuest()
        {
            if (curState == GuestState.Walk)
            {
                Vector3 newPosition = transform.position;
                newPosition.x += curSpeed * Time.deltaTime;

                transform.position = newPosition;
            }
        }

        public enum GuestState
        {
            Idle,
            Walk,
            Scream,
        }
    }
}

