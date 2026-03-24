using FoodSystem;
using System;
using UnityEngine;

public class IchigoAmeData : FoodData
{
    public Type type;

    public enum Type
    {
        Strawberry,
        Orange,
        Grape,
        Mixed
    }

    public IchigoAmeData(Type type)
    {
        this.type = type;
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

        int random = UnityEngine.Random.Range(0, value.Length); //0 = None

        return (Type)value.GetValue(random);
    }
}
