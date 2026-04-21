using UnityEngine;

public class CupReload : Equipment
{
    [SerializeField] private GameObject _cupPrefab;
    public override void Interact(Player player)
    {
        if (player.GetEquipment() is Stick stick)
        {
            var t = Instantiate(_cupPrefab).GetComponent<IchigoAmeCup>();
            t.Interact(player);
        }
    }
}
