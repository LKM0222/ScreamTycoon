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
            //이미지 또는 애니메이션 변경
        }

        private void SetIdle()
        {
            curState = GuestState.Idle;
            //이미지 또는 애니메이션 변경
        }

        private void SetScream()
        {
            curState = GuestState.Scream;
            //이미지 또는 애니메이션 변경
            //애니메이션 길이만큼 대기 후 Walk로 변경
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

