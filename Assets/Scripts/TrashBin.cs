using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBin : Equipment
{
    public override void Interact(Player player)
    {
     
        if (player.GetEquipment() is var eq && (eq is Stick || eq is IchigoAmeCup))
        {
            player.UnEquip();
            Destroy(eq.gameObject);
        }

    }
}
