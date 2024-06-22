using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuestBehave
{
    public class GuestInfo : MonoBehaviour
    {
        //public float speed;
        [NonSerialized] public float curSpeed = 0f;
        //private bool isOnBehave = false;


        private void Update()
        {
            MoveGuest();
        }

        private void MoveGuest()
        {
            Vector3 newPosition = transform.position;
            newPosition.x += curSpeed * Time.deltaTime;

            transform.position = newPosition;
        }

        //private void ActionReturn()
        //{
        //    curSpeed *= -1f;
        //}

        //private void ActionSlow()
        //{
        //    curSpeed *= .5f;
        //}


        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.CompareTag("GameController"))
        //    {
        //        if (isOnBehave == false)
        //        {
        //            isOnBehave = true;
        //            var temp = collision.gameObject.GetComponent<BehavePoint>();

        //            switch (temp.behaveType)
        //            {
        //                case BehaveType.Return:
        //                default:
        //                    ActionReturn();
        //                    return;
        //                case BehaveType.Slow:
        //                    ActionSlow();
        //                    return;

        //            }
        //        }
        //    }
        //}

        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    if (collision.gameObject.CompareTag("GameController"))
        //    {
        //        isOnBehave = false;
        //    }
        //}
    }
}
