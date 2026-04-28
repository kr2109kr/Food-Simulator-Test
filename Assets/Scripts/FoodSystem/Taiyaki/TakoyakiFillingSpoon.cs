using FoodSystem;
using UnityEngine;

public class TakoyakiFillingSpoon : Equipment
{
    public bool HasFilling
    {
        set
        {
            if (value == false)
            {
                _fillingObject.SetActive(false);
            }
            else
            {
                _fillingObject.SetActive(true);
            }
        }
    }
    [field: SerializeField] public TakoyakiData.Filling Filling { get; set; }

    [SerializeField] private GameObject _fillingObject;
    [field: SerializeField] public GameObject FillingPrefab { get; set; }
}
