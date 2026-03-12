using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private Equipment _equipment;
    Vector3 _equipmentPosition;

    private void Start()
    {
        _equipmentPosition = _equipment.transform.position;
    }

    public Vector3 GetResetEquipmentPos()
    {
        return _equipmentPosition;
    }

}
