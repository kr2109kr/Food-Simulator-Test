using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Station : MonoBehaviour, IInteractor
{
    [SerializeField] Vector3 _equipmentPosition;
    [field: SerializeField] public string NameTag { get; private set; }


    private void Start()
    {/*
        if (_equipment != null)
        {
            _equipmentPosition = _equipment.transform.position;
        }*/
    }


    public Vector3 GetResetEquipmentPos()
    {
        return _equipmentPosition;
    }

    public void Interact(Player player)
    {
        if (player.HasEqupment)
        {
            player.GetEquipment().SetStation(this);
            player.UnEquip();
        }
    }
}
