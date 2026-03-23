using System;
using Unity.VisualScripting;
using UnityEngine;

namespace FoodSystem
{
    [Serializable]
    public class FoodDataOLD
    {
        public FoodType Type { get; private set; }
        

        public struct FoodOrder
        {
            
        }

        public enum FoodType
        {
            Taiyaki,
            Takoyaki,
            IchigoAme
        }

        public static FoodType RandomType()
        {
            Array value = Enum.GetValues(typeof(FoodType));

            int random = UnityEngine.Random.Range(0, value.Length);

            return (FoodType)value.GetValue(random);
        }

        public static FoodDataOLD RandomFood()
        {
            //var random = RandomType();

            var random = FoodType.Taiyaki;

            if (random == FoodType.Taiyaki)
            {
                TaiyakiDataOLD taiyaki = new(TaiyakiDataOLD.RandomFilling());
                return taiyaki;
            }


            //return (Filling)value.GetValue(random);

            return null;
        }


        

        public static Filling OldRandomFood()
        {
            Array value = Enum.GetValues(typeof(FoodType));

            int random = UnityEngine.Random.Range(0, value.Length);
            
            return (Filling)value.GetValue(random);
        }
    }
}
