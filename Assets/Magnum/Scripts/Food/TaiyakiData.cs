using System;
using UnityEngine;

namespace FoodSystem
{
    public class TaiyakiData : FoodData
    {
        public Filling _filling;
        Doness _leftDoness;
        Doness _rightDoness;

        public TaiyakiData()
        {
            
        }

        public TaiyakiData(Filling filling)
        {
            _filling = filling;
        }

        public enum Filling
        {
            RedBeans,
            Custard,
            Chocolate
        }
        
        public enum Doness
        {
            
        }

        public static Filling RandomFilling()
        {
            Array value = Enum.GetValues(typeof(Filling));

            int random = UnityEngine.Random.Range(0, value.Length);

            return (Filling)value.GetValue(random);
        }


    }
}