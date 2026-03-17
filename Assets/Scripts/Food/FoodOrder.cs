using UnityEngine;
using System;
using System.Collections.Generic;

namespace FoodSystem
{
    [Serializable]
    public class FoodOrder
    {
        
        private List<FoodData> _foodDatas = new();
        

        public FoodData this[int index]
        {
            get { return _foodDatas[index]; }
        }

        

        public void CheckOrder()
        {
            Debug.Log("Checking");
        }

        public FoodData.FoodType GetFoodType()
        {
            return _foodDatas[^1].Type;
        }


        public void AddFoodToList()
        {
            _foodDatas.Add(FoodData.RandomFood());           
        }

        public void CompareFood(FoodData foodData)
        {
            
        }
    }
}