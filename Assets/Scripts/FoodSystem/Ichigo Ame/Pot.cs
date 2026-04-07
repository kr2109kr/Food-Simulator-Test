using UnityEngine;

public class Pot : Equipment
{
    public override void Interact(Player player)
    {
        if (player.GetEquipment() is Stick)
        {
            Debug.Log("Boom");
        }

        if (player.GetEquipment() is null)
        {
            Debug.Log("Nooo");
        }
    }
}
