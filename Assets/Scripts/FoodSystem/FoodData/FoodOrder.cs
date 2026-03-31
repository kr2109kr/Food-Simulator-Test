using FoodSystem;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
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
        _foodOrders.Add(FoodData.RandomFood());
    }

    public void Add(FoodData foodData)
    {
        _foodOrders.Add(foodData);
    }



    public bool CompareData(FoodData foodData)
    {
        return _foodOrders[0].CompareData(foodData);
    }




    public bool CompareDatas(List<FoodData> foodDatas)
    {
        if (_foodOrders.Count != foodDatas.Count) { return false; }

        var result = _foodOrders.OrderBy(x => x.GetType().Name).SequenceEqual(foodDatas.OrderBy(x => x.GetType().Name));

        UnityEngine.Debug.Log("Check = " + result);

        return result;
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
