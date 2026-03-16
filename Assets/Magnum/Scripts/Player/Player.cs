using UnityEngine;

public class Player : MonoBehaviour
{
    Equipment _equipment;
    private SelectionManager _selectionManager;

    public bool HasEqupment { get; private set; }

    public void Equip(Equipment equipment)
    {
        _equipment = equipment;
        _equipment.GetComponent<BoxCollider>().enabled = false;
        HasEqupment = true;

        

        //AddSound
    }

    public void UnEquip()
    {
        _equipment.ReturnToStation();
        _equipment.GetComponent<BoxCollider>().enabled = true;
        _equipment = null;

        HasEqupment = false;

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
