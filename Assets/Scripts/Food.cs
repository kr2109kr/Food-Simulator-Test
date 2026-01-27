using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food
{
     
    

    public class Taiyaki
    {
        public enum Filling
        {
            RedBeans,
            Custart,
            Chocolate,
        }

        public static Filling RandomFilling()
        {
            
            Array value = Enum.GetValues(typeof(Filling));

            int random = UnityEngine.Random.Range(0, value.Length);


            return (Filling)value.GetValue(random);
        }
    }

    private class Takoyaki
    {
        
    }

    private class IchigoAme
    {

    }

    private void Update()
    {
        Test();
    }
    public void Test()
    {
        Debug.Log(Food.Taiyaki.RandomFilling());
    }
    public void RandomFood()
    {
        
    }
}
