using UnityEngine;

public class FruitBox : Equipment
{
    [SerializeField] IchigoAmeData.FruitType _fruitType;
    [SerializeField] GameObject _fruitPrefab;

    public override void Interact(Player player)
    {
        if (player.GetEquipment() is Stick stick && !stick.IsFull)
        {
            stick.AddFruit(_fruitType, _fruitPrefab);
        }

        else
        {
            Debug.Log("Fullllllll");
        }
    }
}
