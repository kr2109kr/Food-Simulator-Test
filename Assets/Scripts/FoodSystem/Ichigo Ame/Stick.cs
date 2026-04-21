using FoodSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using FruitType = IchigoAmeData.FruitType;

public class Stick : Equipment
{
    //[SerializeField] List<FruitType> fruits = new List<FruitType>();

    public FruitType?[] fruits = new FruitType?[3];

    [SerializeField] private List<Vector3> FruitPostions = new();

    [SerializeField] private Stack<GameObject> test;

    [SerializeField] private Transform[] _placeHolder = new Transform[3];
    [SerializeField] private Fruit[] _fruit = new Fruit[3];

    private Animator _animator;

    public bool IsFull { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AddFruit(FruitType fruitType, GameObject fruitPrefab)
    {
        void CreateObject(int index)
        {

            var t = Instantiate(fruitPrefab, _placeHolder[index]);
            _fruit[index] = t.GetComponent<Fruit>();
            //t.transform.localPosition = FruitPostions[index];
        }

        for (int i = 0; i < fruits.Length; i++)
        {
            if (fruits[i] is null)
            {
                fruits[i] = fruitType;
                CreateObject(i);

                _animator.SetTrigger(_animator.parameters[i].name);

                Debug.Log("New Fruit : " + i + " " + fruits[i]);
                AudioManager.Instance.PlayOneShot(FMODEvents.Instance.AddFruit, transform.position);
                break;
            }
        }

        if (fruits[^1] is not null)
        {
            IsFull = true;
        }
    }

    public void SugarCoatFruits()
    {
        foreach (var fruit in _fruit)
        {
            fruit.SugarCoat();
        }
    }
}
