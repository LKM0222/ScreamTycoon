using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuestBehave
{
    public class BehavePoint : MonoBehaviour
    {
        public BehaveType behaveType;
        [Range(0f, 100f)]
        public float chanceReturn = 50f;
        [Range(0f, 100f)]
        public float chanceSlow = 100f;

    }

    public enum BehaveType
    {
        Return,
        Slow,
    }
}