using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Taiyaki", menuName = "Scriptable Objects/Taiyaki")]
public class TaiyakiSO : ScriptableObject
{
    [field: Header("State")]
    [field: SerializeField] public Color undercookedColor { get; set; }
    [field: SerializeField] public Color excellentColor { get; set; }
    [field: SerializeField] public Color overcookedColor { get; set; }
    [field: SerializeField] public float stateTimer { get; set; }


    [field: SerializeField] public List<Data> _data { get; private set; }
    
    public enum State
    {
        Undercooked,
        Excellent,
        Overcooked
    }

    public enum Filling
    {
        Red_Bean,
        Custard,
        Chocolate
    }

    [Serializable]
    public struct Data
    {
        public Filling filling;
        public Sprite sprite;
    }

}
