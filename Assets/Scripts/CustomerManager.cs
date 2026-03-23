using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject _cutomerPrefabs;
    Customer customer;


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
        Instantiate(_cutomerPrefabs, transform);
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
}
