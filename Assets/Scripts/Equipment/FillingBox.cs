using FoodSystem;
using UnityEngine;

public class FillingBox : Equipment
{
    //[RequireComponent]
    [SerializeField] private Animator _animator;
    [SerializeField] private TaiyakiData.Filling _filling;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    
}
