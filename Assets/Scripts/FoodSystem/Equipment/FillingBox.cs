using FoodSystem;
using UnityEngine;

public class FillingBox : Equipment
{
    //[RequireComponent]
    [SerializeField] private Animator _animator;
    [SerializeField] private TaiyakiData.Filling _filling;

    [SerializeField] private Vector3 _offsetPos;
    [SerializeField] private Vector3 _offsetRot;

    [SerializeField] private Spoon _spoon;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _spoon.Filling = _filling;
    }

    public override void Interact(Player player)
    {
        if (player.GetEquipment() is null)
        {
            player.Equip(_spoon);
            _spoon.HasFilling = true;
            Debug.Log(_spoon.Filling);
        }

        else if (player.GetEquipment() is Spoon)
        {
            player.UnEquip();
            _spoon.transform.SetParent(this.transform);
            _spoon.transform.localPosition = _offsetPos;
            _spoon.transform.localRotation = Quaternion.Euler(_offsetRot);
        }
    }
}
