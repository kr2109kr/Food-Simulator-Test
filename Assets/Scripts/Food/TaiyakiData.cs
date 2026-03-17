using System;
using UnityEngine;

namespace FoodSystem
{
    public class TaiyakiData : FoodData
    {
        public Filling FillingType { get; set; }
        public Doness LeftDoness { get; private set; }
        public Doness RightDoness { get; private set; }

        public TaiyakiData()
        {
            
        }

        public TaiyakiData(Filling filling)
        {
            FillingType = filling;
        }

        public enum Filling
        {
            RedBeans,
            Custard,
            Chocolate
        }
        
        public enum Doness
        {
            Uncooked,
            Excellent,
            Burnt
        }

        public enum Side
        {
            Left,
            Right
        }

        public void SetDoness(Side side, Doness doness)
        {
            LeftDoness = (side == Side.Left) ? doness : RightDoness = doness;
        }

        public static Filling RandomFilling()
        {
            Array value = Enum.GetValues(typeof(Filling));

            int random = UnityEngine.Random.Range(0, value.Length);

            return (Filling)value.GetValue(random);
        }


    }
}