using FoodSystem;
using Unity.VisualScripting;
using UnityEngine;

public class Spoon : Equipment
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
    public TaiyakiData.Filling Filling { get; set; }

    [SerializeField] private GameObject _fillingObject;
}
