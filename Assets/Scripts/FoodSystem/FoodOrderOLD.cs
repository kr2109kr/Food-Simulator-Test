using UnityEngine;
using System;
using System.Collections.Generic;

namespace FoodSystem
{
    [Serializable]
    public class FoodOrderOLD
    {
        
        private List<FoodDataOLD> _foodDatas = new();
        

        public FoodDataOLD this[int index]
        {
            get { return _foodDatas[index]; }
        }

        

        public void CheckOrder()
        {
            Debug.Log("Checking");
        }

        public FoodDataOLD.FoodType GetFoodType()
        {
            return _foodDatas[^1].Type;
        }


        public void AddFoodToList()
        {
            _foodDatas.Add(FoodDataOLD.RandomFood());           
        }

        public void CompareFood(FoodDataOLD foodData)
        {
            
        }
    }
}