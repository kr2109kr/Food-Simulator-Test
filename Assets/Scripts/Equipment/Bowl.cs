using FoodSystem;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : Equipment
{
    public FoodData foodData;
    public GameObject taiyakiObject;

    int _foodCount;
    int _maxFood;


    [SerializeField] private List<FoodData> _foodDatas = new();


    private void Start()
    {
        _foodDatas.Add(new TakoyakiData(TakoyakiData.Filling.Tako));
        _foodDatas.Add(new TakoyakiData(TakoyakiData.Filling.Tako));
        _foodDatas.Add(new TakoyakiData(TakoyakiData.Filling.Tako));
    }

    public override void Interact(Player player)
    {
        base.Interact(player);

        Tongs tongs;

        if (player.GetEquipment().TryGetComponent<Tongs>(out tongs) && tongs.FoodObject != null)
        {
            tongs.FoodObject.transform.SetParent(transform);

            if (transform.childCount > 0)
            {
                float x = 0.5f * transform.childCount - 1;

                tongs.FoodObject.transform.localPosition = new Vector3(x, 0.21f, -0.05f);
                tongs.FoodObject.transform.localRotation = Quaternion.Euler(-30, -90, 0);
            }

            else
            {
                tongs.FoodObject.transform.localPosition = new Vector3(-0.5f, 0.21f, -0.05f);
                tongs.FoodObject.transform.localRotation = Quaternion.Euler(-30, -90, 0);
            }

            taiyakiObject = tongs.FoodObject;


            tongs.Open();
            tongs.FoodObject = null;
        }
    }

    

    public void SwitchToCounter()
    {
        
    }

    public FoodData GetFood()
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

    
}
