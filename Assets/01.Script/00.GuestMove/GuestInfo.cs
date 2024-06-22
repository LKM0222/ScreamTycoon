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

        private void Update()
        {
            MoveGuest();
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
        }

        private void SetIdle()
        {
            curState = GuestState.Idle;
            //�̹��� �Ǵ� �ִϸ��̼� ����
        }

        private void SetScream()
        {
            curState = GuestState.Scream;
            //�̹��� �Ǵ� �ִϸ��̼� ����
            //�ִϸ��̼� ���̸�ŭ ��� �� Walk�� ����
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

