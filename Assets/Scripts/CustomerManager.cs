using CustomerSystem;
using System;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    //[SerializeField] private GameObject _cutomerPrefabs;
    CustomerOrder customer;
    [SerializeField] private GameManager _money;

    [SerializeField] private GameObject[] _customerPrefabs;

    [Header("NPC Prefabs")]
    [SerializeField] private GameObject[] _NPC_01_Varients;
    [SerializeField] private GameObject[] _NPC_02_Varients;
    [SerializeField] private GameObject[] _NPC_Rich_Varients;

    private int _currentCustomerType = 2;

    [SerializeField] private Vector3 _doorPos;
    [SerializeField] private Vector3 _counterPos;
    [SerializeField] public Vector3 _spawnPos;

    [field: SerializeField] public Vector3[] TargetsPos { get; private set; }

    private CustomerOrder npc;

    private void Awake()
    {
        CreateCustomer();
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
        _currentCustomerType = (_currentCustomerType + 1) % 3;

        GameObject c;

        if (_currentCustomerType == 0)
        {
            c = Instantiate(RandomCustomer(_NPC_01_Varients), transform);
            c.transform.position = _spawnPos;
        }

        else if (_currentCustomerType == 1)
        {
            c = Instantiate(RandomCustomer(_NPC_02_Varients), transform);
            c.transform.position = _spawnPos;
        }

        else if (_currentCustomerType == 2)
        {
            c = Instantiate(RandomCustomer(_NPC_Rich_Varients), transform);
            c.transform.position = _spawnPos;
        }
        //var c = Instantiate(RandomCustomer(), transform);
        
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

    private GameObject RandomCustomer(GameObject[] gameObjects)
    {
        int random = UnityEngine.Random.Range(0, gameObjects.Length);
        return gameObjects[random];
    }

    private int RandomCustomerType()
    {
        int random = UnityEngine.Random.Range(0, 3);
        Debug.Log(random);
        return random;
    }
}
