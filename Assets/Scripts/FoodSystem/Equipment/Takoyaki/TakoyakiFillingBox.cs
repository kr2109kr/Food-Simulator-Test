using FoodSystem;
using Unity.VisualScripting;
using UnityEngine;

public class TakoyakiFillingBox : Equipment
{
    [field: SerializeField] public TakoyakiData.Filling Filling { get; set; }
    [field: SerializeField] public GameObject FillingPrefab { get; set; }

}
