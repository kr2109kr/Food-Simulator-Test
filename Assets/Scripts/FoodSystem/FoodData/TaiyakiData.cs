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

    int random;

    public int Price { get; private set; }

    public Dictionary<string, int> inventory = new Dictionary<string, int>()
    {
        {"Potion", 5},
        {"Sword", 1},
        {"Shield", 1}
    };

    public Dictionary<Filling, int> price = new Dictionary<Filling, int>()
    {
        { Filling.RedBeans, 180 },
        { Filling.Chocolate, 180 },
        { Filling.Custard, 200 }
    };

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

    private void Test()
    {
        int a = price[Filling.Custard];
    }
    

    

    public TaiyakiData()
    {
        //this.filling = RandomFilling();
        //Price = price[filling];
    }

    public TaiyakiData(Filling filling)
    {
        this.filling = filling;

    }
    /*
    public TaiyakiData RandomData()
    {

        //return new TaiyakiData(RandomFilling());
    }*/

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
    /*
    public Filling RandomFilling()
    {
        Array value = Enum.GetValues(typeof(Filling));

        int random = UnityEngine.Random.Range(1, value.Length); //0 = None

        return (Filling)value.GetValue(random);
    }
    */

}
