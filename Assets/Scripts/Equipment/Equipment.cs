using System;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Station _station;
    [SerializeField] private string _tag;

    public void FollowCursor(Transform cursorPosition)
    {
        //transform.position = 
    }



    public void ReturnToStation()
    {
        transform.position = _station.GetResetEquipmentPos();
    }

    ///
    public bool CheckEquipment(string name)
    {
        if (_tag == name)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

}
