using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Equipment : MonoBehaviour, IInteractor
{
    [SerializeField] private Station _station;

    [SerializeField] private Vector3 _offsetPosition;
    private CameraSwitch CameraSwitch;

    [field: SerializeField] public string NameTag { get; private set; }

    
    [field: SerializeField] public Vector3 HoldPostion { get; set; }
    [field: SerializeField] public Vector3 HoldRotation { get; set; }

    [SerializeField] private Transform test;

    public virtual void Interact(Player player)
    {
        if (!player.GetEquipment())
        {
            player.Equip(this);
        }
    }


    public void FollowCursor(Transform cursorPosition)
    {
        //transform.position = 
    }



    public void ReturnToStation()
    {
        transform.localPosition = _station.GetResetEquipmentPos();
    }

    public Vector3 GetOffsetPosition()
    {
        return _offsetPosition;
    }
    ///
    public bool CheckEquipmentOLD(string name)
    {
        if (NameTag == name)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public bool Check(Type type)
    {
        if (this.GetType() == type)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void SetStation(Station station)
    {
        _station = station;
    }
}
