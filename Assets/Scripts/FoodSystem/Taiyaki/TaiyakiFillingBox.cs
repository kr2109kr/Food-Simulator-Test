using FoodSystem;
using UnityEngine;

public class TaiyakiFillingBox : Equipment
{
    //[RequireComponent]
    [SerializeField] private Animator _animator;
    [SerializeField] public TaiyakiData.Filling _filling;

    [SerializeField] private Vector3 _offsetPos;
    [SerializeField] private Vector3 _offsetRot;

    [SerializeField] public GameObject _fillingPrefab;

    [SerializeField] public TaiyakiSpoon _spoon;

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
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

        else if (player.GetEquipment() is TaiyakiSpoon && _spoon == player.GetEquipment())
        {
            player.UnEquip();
            _spoon.HasFilling = true;
            _spoon.transform.SetParent(this.transform);
            _spoon.transform.localPosition = _offsetPos;
            _spoon.transform.localRotation = Quaternion.Euler(_offsetRot);
        }
    }
}
