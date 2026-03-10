using System;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Station _station;
    [SerializeField] private string _tag;

    [SerializeField] private Vector3 _offsetPosition;

    public void FollowCursor(Transform cursorPosition)
    {
        //transform.position = 
    }



    public void ReturnToStation()
    {
        transform.position = _station.GetResetEquipmentPos();
    }

    public Vector3 GetOffsetPosition()
    {
        return _offsetPosition;
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
