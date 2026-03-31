using System;
using UnityEngine;

namespace FoodSystem
{
    [Serializable]
    public class TakoyakiData : FoodData
    {
        public Filling filling;
        public Doness doness;
        
        public TakoyakiData(Filling filling)
        {
            this.filling = filling;
        }

        public enum Filling
        {
            None,
            Tako,
            Shrimp,
            Bacon,
        }

        public enum Doness
        {
            Uncooked,
            Excellent,
            Burnt
        }

        public override bool CompareData(FoodData foodData)
        {
            TakoyakiData t = foodData as TakoyakiData;

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

        public static Filling RandomFilling()
        {
            Array value = Enum.GetValues(typeof(Filling));

            int random = UnityEngine.Random.Range(0, value.Length); //0 = None

            return (Filling)value.GetValue(random);
        }
    }
}