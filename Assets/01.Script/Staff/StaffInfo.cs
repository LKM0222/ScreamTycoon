using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffInfo : MonoBehaviour
{
    public StaffType type;

    private void Start()
    {
        switch (type)
        {
            case StaffType.Lost:
                GameManager.Instance.IsLostStaff += ListenStaffAction;
                break;
            case StaffType.Enter:
                GameManager.Instance.EnterStaffAction += ListenStaffAction;
                break;
            case StaffType.Doll:
                GameManager.Instance.DollStaffAction += ListenStaffAction;
                break;
        }
    }

    private void ListenStaffAction(bool isOn)
    {
        this.gameObject.SetActive(isOn);
    }
}

public enum StaffType
{
    Lost,
    Enter,
    Doll
}
