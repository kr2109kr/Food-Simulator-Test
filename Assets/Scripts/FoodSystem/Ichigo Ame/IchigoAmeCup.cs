using FMOD;
using FoodSystem;
using System.Collections.Generic;
using UnityEngine;
using static IchigoAmeData;

public class IchigoAmeCup : Equipment
{
    public bool IsFull { get; private set; }
    private Stick _stick;

    [SerializeField] private List<FoodData> _foodDatas = new();

    IchigoAmeData _ichigoAmeData;

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
            _stick = stick;
            CombineIngredient();
        }
    }

    public bool CheckIngredients(IchigoAmeData.Type type, FruitType?[] fruits)
    {
        for (int i = 0; i < 3; i++)
        {
            if (IchigoAmeData.fruitConfigs[type].Recipe[i] != _stick.fruits[i])
            {
                return false;
            }
        }

        return true;
    }

    public void CombineIngredient()
    {
        if (CheckIngredients(Type.Strawberry, _stick.fruits))
        {
            _ichigoAmeData = new(Type.Strawberry);
        }
        else if (CheckIngredients(Type.Orange, _stick.fruits))
        {
            _ichigoAmeData = new(Type.Orange);
        }
        else if (CheckIngredients(Type.Grape, _stick.fruits))
        {
            _ichigoAmeData = new(Type.Grape);
        }
        else if (CheckIngredients(Type.Mixed, _stick.fruits))
        {
            _ichigoAmeData = new(Type.Mixed);
        }
        else
        {
            _ichigoAmeData = new(Type.Unknown);
        }
    }

    public IchigoAmeData GetFoodData()
    {
        UnityEngine.Debug.Log(_ichigoAmeData.type);
        return _ichigoAmeData;
    }

    public List<FoodData> GetFoods()
    {
        /*
        foreach(FruitType fruitType in _stick.fruits)
        {
            _foodDatas.Add(new IchigoAmeData(fruitType));
        }
        */

        foreach (FoodData f in _foodDatas)
        {
            UnityEngine.Debug.Log(((IchigoAmeData)f).fruitType);
        }

        return _foodDatas;
    }
}
