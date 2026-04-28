using FoodSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

public class IchigoAmeData : FoodData
{
    public Type type;
    public FruitType fruitType;
    public int Price { get; private set; }

    public enum FruitType
    {
        Strawberry,
        Orange,
        Grape,
    }

    public enum Type
    {
        Strawberry,
        Orange,
        Grape,
        Mixed,
        Unknown
    }

    public static Dictionary<Type, (int Price, FruitType[] Recipe)> fruitConfigs = new()
    {
        { Type.Strawberry, (500, new FruitType[3] { FruitType.Strawberry, FruitType.Strawberry, FruitType.Strawberry}) },
        { Type.Orange, (400, new FruitType[3] { FruitType.Orange, FruitType.Orange, FruitType.Orange}) },
        { Type.Grape, (400, new FruitType[3] { FruitType.Grape, FruitType.Grape, FruitType.Grape}) },
        { Type.Mixed, (450, new FruitType[3] { FruitType.Orange, FruitType.Grape, FruitType.Strawberry}) },
        { Type.Unknown, (0, null) }
    };
    public IchigoAmeData()
    {
        this.type = RandomType();
        Price = fruitConfigs[type].Price;
    }

    public IchigoAmeData(Type type)
    {
        this.type = type;
        Price = fruitConfigs[type].Price;
    }

    public override bool CompareData(FoodData foodData)
    {
        IchigoAmeData t = foodData as IchigoAmeData;

        if (t is null)
        {
            Debug.Log("Type Not Matched");
            return false;
        }

        else if (type == t.type)
        {
            Debug.Log("Same Filling, Same Type");
            return true;
        }

        else
        {
            Debug.Log("Type Matched, But Filling Not");
            return false;
        }
    }

    public new static Type RandomType()
    {
        Array value = Enum.GetValues(typeof(Type));

        int random = UnityEngine.Random.Range(0, value.Length - 1); //0 = None 

        return (Type)value.GetValue(random);
    }

}
