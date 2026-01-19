using NUnit.Framework;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Taiyaki", menuName = "Scriptable Objects/Taiyaki")]
public class Taiyaki : ScriptableObject
{
    public enum Filling
    {
        Red_Bean,
        Custard,
        Chocolate
    }

    [Serializable]
    public struct Data
    {
        public string name;
        public Sprite sprite;
    }

    public Data[] datas;
}
