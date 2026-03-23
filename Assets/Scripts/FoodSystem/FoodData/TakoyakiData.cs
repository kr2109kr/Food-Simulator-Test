using System;
using UnityEngine;

namespace FoodSystem
{
    public class TakoyakiData : FoodData
    {
        public Filling FillingType { get; set; }
        

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

        [Serializable]
        public new struct FoodOrder
        {
            [field: SerializeField] public Filling Filling { get; set;}
            [field: SerializeField] public Doness doness { get; set; }
        }

        public void CreateData()
        {

        }

        public static Filling RandomFilling()
        {
            Array value = Enum.GetValues(typeof(Filling));

            int random = UnityEngine.Random.Range(1, value.Length); //0 = None

            return (Filling)value.GetValue(random);
        }
    }
}