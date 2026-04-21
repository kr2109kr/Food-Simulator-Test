using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using static IchigoAmeData;

public class IchigoAmeCup : Equipment
{
    public bool IsFull { get; private set; }

    public override void Interact(Player player)
    {
        if (player.GetEquipment() is Stick stick)
        {
            TransferStick(stick);
            player.UnEquip();
            base.Interact(player);
        }

        else
        {
            base.Interact(player);
        }
    }

    public void TransferStick(Stick stick)
    {
        if (!IsFull)
        {
            stick.transform.SetParent(transform);
            stick.transform.localPosition = new Vector3(0, 3.2f, 0);
            stick.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //stick.transform.localScale = Vector3.one;
        }
    }   
}
