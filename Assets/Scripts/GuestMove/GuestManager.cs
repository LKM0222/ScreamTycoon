using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuestBehave
{
    public class GuestManager : MonoBehaviour
    {
        public Transform createPoint;
        public GameObject prefab_Guest;

        private void Update()
        {
            if (Input.GetMouseButtonUp(1))
            {
                MakeGuestPrefab();
            }
        }

        private void MakeGuestPrefab()
        {
            var go = Instantiate(prefab_Guest, createPoint);
            var info = go.GetComponent<GuestInfo>();
            if (info != null)
            {
                info.curSpeed = 1f;
            }
        }
    }
}
