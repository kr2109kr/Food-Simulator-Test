using FoodSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using static FoodSystem.TaiyakiDataOLD;

[Serializable]
public class TaiyakiData : FoodData
{
    public Filling filling;
    public Doness leftDoness;
    public Doness rightDoness;

    public enum Filling
    {
        None,
        RedBeans,
        Custard,
        Chocolate
    }

    public enum Doness
    {
        Uncooked,
        Excellent,
        Burnt
    }

    public enum Side
    {
        Left,
        Right,
        Both
    }

    public TaiyakiData() { }

    public TaiyakiData(Filling filling)
    {
        this.filling = filling;

    }

    public static TaiyakiData RandomData()
    {
        return new TaiyakiData(RandomFilling());
    }

    public override bool CompareData(FoodData foodData)
    {
        TaiyakiData t = foodData as TaiyakiData;

        if (t is null)
        {
            Debug.Log("Type Not Matched");
            return false;
        }

        else if (filling == t.filling)
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

    public static Filling RandomFilling()
    {
        Array value = Enum.GetValues(typeof(Filling));

        int random = UnityEngine.Random.Range(1, value.Length); //0 = None

        return (Filling)value.GetValue(random);
    }
}
