using Unity.VisualScripting;
using UnityEngine;

public class StickJug : Equipment
{
    [SerializeField] private GameObject _stickPrefab;
    public override void Interact(Player player)
    {
        //base.Interact(player);
        if (player.GetEquipment() is null)
        {
            var t = Instantiate(_stickPrefab);
            player.Equip(t.GetComponent<Stick>());
            Debug.Log("Hello");
        }
        
    }

}
