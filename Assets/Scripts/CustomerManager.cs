using CustomerSystem;
using System;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    //[SerializeField] private GameObject _cutomerPrefabs;
    Customer customer;
    [SerializeField] private Money _money;

    [SerializeField] private GameObject[] _customerPrefabs;

    private void Awake()
    {

    }

    private void Start()
    {
        if (IsCustomerEmpty())
        {
            CreateCustomer();
        }
        
    }

    public void CreateCustomer()
    {
        Instantiate(RandomCustomer(), transform);
    }

    private bool IsCustomerEmpty()
    {
        if (transform.childCount > 0)
        {
            return false;
        }

        else
        {
            return true;
        }
    }

    private GameObject RandomCustomer()
    {
        int random = UnityEngine.Random.Range(0, _customerPrefabs.Length);
        return _customerPrefabs[random];
    }
}
