using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static FoodSystem.FoodDataOLD;

namespace FoodSystem
{
    public class FoodData
    {
        private static Dictionary<FoodType, Func<FoodData>> factory = new Dictionary<FoodType, Func<FoodData>>() {
            { FoodType.Taiyaki, () =>  new TaiyakiData(TaiyakiData.RandomFilling()) },

            { FoodType.Takoyaki, () => new TakoyakiData(TakoyakiData.RandomFilling()) },

            //{ FoodType.IchigoAme, () => new IchigoAmeData(IchigoAmeData.RandomType()) }
        };


        private static List<Type> _foodType = new List<Type>() { typeof(TaiyakiData), typeof(TakoyakiData), typeof(IchigoAmeData) };




        public override bool Equals(object obj)
        {
            // เช็คว่าเป็น null หรือเป็นคนละ Type กันหรือไม่
            if (obj == null || GetType() != obj.GetType())
                return false;

            FoodData other = (FoodData)obj;

            // เทียบค่าใน Field ที่คุณต้องการ (ต้องตรงกันทั้งหมดถึงจะถือว่าเท่ากัน)
            return CompareData((FoodData)obj);
        }

        
        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }
        
        public class FoodOrderData
        {

        }

        public enum FoodType
        {
            Taiyaki,
            Takoyaki,
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