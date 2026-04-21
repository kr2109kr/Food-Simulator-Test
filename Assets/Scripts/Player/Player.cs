using UnityEngine;

public class Player : MonoBehaviour
{
    Equipment _equipment;
    private SelectionManager _selectionManager;
    [SerializeField] private GameObject _equipmentHand;
    public bool IsInteracting { get; set; }

    public bool HasEqupment { get; private set; }

    public void Equip(Equipment equipment)
    {
        _equipment = equipment;
        
        _equipment.transform.SetParent(_equipmentHand.transform);

        _equipment.transform.localPosition = equipment.HoldPostion;
        _equipment.transform.localRotation = Quaternion.Euler(equipment.HoldRotation.x, equipment.HoldRotation.y, equipment.HoldRotation.z);
        HasEqupment = true;


        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.Equip, transform.position);
        //AddSound

    }

    public void UnEquip()
    {
        //_equipment.ReturnToStation();
        //_equipment.GetComponent<BoxCollider>().enabled = true;
        _equipment = null;

        HasEqupment = false;
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.UnEquip, transform.position);
        //AddSound
    }

    public void DestroyEquipment()
    {
        HasEqupment = false;
        Destroy(_equipment.gameObject);
        _equipment = null;
    }


    public Equipment GetEquipment()
    {
        return _equipment;
    }

    
}
