using FoodSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TaiyakiBowl : Equipment
{
    public FoodData foodData;
    public GameObject taiyakiObject;

    [SerializeField] private List<FoodData> _foodDatas = new();

    public override void Interact(Player player)
    {
        base.Interact(player);

        Tongs tongs;

        if (player.GetEquipment().TryGetComponent<Tongs>(out tongs) && tongs.FoodObject != null)
        {
            tongs.FoodObject.transform.SetParent(transform);
            tongs.FoodObject.transform.localPosition = new Vector3(0, 0.1f, 0);
            tongs.FoodObject.transform.localRotation = Quaternion.identity;

            taiyakiObject = tongs.FoodObject;

            tongs.Open();
            tongs.FoodObject = null;
        }
    }

    public TaiyakiData GetFood()
    {
        return taiyakiObject.GetComponent<Taiyaki>().GetFood();
    }


    public TaiyakiData GetFoodData()
    {
        return taiyakiObject.GetComponent<Taiyaki>().GetFood();
    }


    public void SetFood(FoodData foodData)
    {

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public List<FoodData> GetFoods()
    {
        return _foodDatas;
    }
}
