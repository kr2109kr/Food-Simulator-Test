using FoodSystem;
using System;
using UnityEngine;

public class IchigoAmeData : FoodData
{
    public Type type;
    public FruitType fruitType;

    public enum FruitType
    {
        Strawberry,
        Orange,
        Grape
    }

    public enum Type
    {
        Strawberry,
        Orange,
        Grape,
        Mixed
    }

    public IchigoAmeData(FruitType fruitType)
    {
        this.fruitType = fruitType;
    }

    public override bool CompareData(FoodData foodData)
    {
        IchigoAmeData t = foodData as IchigoAmeData;

        if (t is null)
        {
            Debug.Log("Type Not Matched");
            return false;
        }

        else if (fruitType == t.fruitType)
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

        int random = UnityEngine.Random.Range(0, value.Length); //0 = None

        return (Type)value.GetValue(random);
    }
}
