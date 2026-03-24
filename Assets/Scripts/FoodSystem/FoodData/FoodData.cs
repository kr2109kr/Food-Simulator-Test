using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static FoodSystem.FoodDataOLD;

namespace FoodSystem
{
    //[CreateAssetMenu(fileName = "FoodType", menuName = "Scriptable Objects/FoodType")]
    public class FoodData
    {
        public FoodOrder foodOrder;

        private static Dictionary<FoodType, Func<FoodData>> factory = new Dictionary<FoodType, Func<FoodData>>() {
            { FoodType.Taiyaki, () =>  new TaiyakiData(TaiyakiData.RandomFilling()) },

            //{ FoodType.Takoyaki, () => new TakoyakiData(TakoyakiData.RandomFilling()) },

            //{ FoodType.IchigoAme, () => new IchigoAmeData(IchigoAmeData.RandomType()) }
        };


        private static List<Type> _foodType = new List<Type>() { typeof(TaiyakiData), typeof(TakoyakiData), typeof(IchigoAmeData) };







        public class FoodOrderData
        {

        }

        public enum FoodType
        {
            Taiyaki,
            //Takoyaki,
            //IchigoAme
        }

        
        public bool CompareType(FoodData foodData)
        {
            if (this.GetType() == foodData.GetType()) { return true; }
            else { return false; }
        }
        


        [Serializable]
        public class FoodOrder
        {
            [SerializeField] TaiyakiData.FoodOrder taiyakiOrder;

            [SerializeField] TakoyakiData.FoodOrder takoyakiOrder;


            /*
            private List<FoodDataOLD> _foodDatas = new();

            public FoodDataOLD this[int index]
            {
                get { return _foodDatas[index]; }
            }
            */
        }

        private void Awake()
        {

        }

        private void Test()
        {
            FoodData _foodDataSO;
            //FoodOrderList.AddFoodToList();

        }

        private void AddFoodToList()
        {
            RandomFood();
        }


        public virtual bool GetDataForCheck()
        {
            return false;
        }
        private FoodData CreateFoodData()
        {
            return this;
        }

        public static FoodData RandomFood()
        {
            var random = RandomType();
            Debug.Log(random);
            return factory[random]();
        }

        public virtual bool CompareData(FoodData foodData)
        {
            return false;
        }


        public static FoodType RandomType()
        {
            Array value = Enum.GetValues(typeof(FoodType));

            int random = UnityEngine.Random.Range(0, value.Length); /////

            return (FoodType)value.GetValue(random);
        }
    }
}