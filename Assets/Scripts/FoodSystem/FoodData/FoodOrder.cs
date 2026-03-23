using FoodSystem;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FoodOrder
{
    private int maxOrder;


    private List<FoodData> _foodOrders = new List<FoodData>(){ };
    private FoodData _foodObjectData;

    TaiyakiData taiyakiSO;

    private class TaiyakiOrder
    {
        TaiyakiData taiyakiSO;
    }
    
    public FoodData this[int index]
    {
        get { return _foodOrders[index]; }
    }

    public void Add()
    {
        _foodOrders.Add(new TaiyakiData(TaiyakiData.Filling.Chocolate));
        Debug.Log(_foodOrders.Count);
    }

    public bool CompareData(FoodData foodData)
    {
        return _foodOrders[0].CompareData(foodData);
    }

    private void Awake()
    {
        //_foodOrders.Add(new TaiyakiData(TaiyakiData.Filling.RedBeans));
        //_foodOrders.Add(new TakoyakiData());
        //_foodOrders.Add(FoodData.RandomFood());

        //_foodOrders[0].CompareData(_foodOrders[1]);
    }

    /*
    public FoodData this[int index]
    {
        get { return test[index]; }

    }
    */
}
