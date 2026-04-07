using System;
using UnityEngine;

public class Equipment : MonoBehaviour, IInteractor
{
    [SerializeField] private Station _station;

    [SerializeField] private Vector3 _offsetPosition;
    private CameraSwitch CameraSwitch;

    [field: SerializeField] public string NameTag { get; private set; }

    
    [field: SerializeField] public Vector3 HoldPostion { get; set; }
    [field: SerializeField] public Vector3 HoldRotation { get; set; }

    [SerializeField] private Transform test;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }


    public virtual void Interact(Player player)
    {
        if (!player.GetEquipment())
        {
            player.Equip(this);
            _boxCollider.enabled = false;
        }
    }


    public void FollowCursor(Transform cursorPosition)
    {
        //transform.position = 
    }



    public void TransferToStation(Station station)
    {
        transform.SetParent(station.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        //transform.localPosition = station.GetResetEquipmentPos();
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
