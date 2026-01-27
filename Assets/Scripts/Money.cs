using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] public int _money;
    [SerializeField] string _moneyText = "test";
    [SerializeField, TextArea] private string Debug_String;

    private void Start()
    {
        Debug_String = "Hello";
    }

    private void Update()
    {
        Debug_String = "Hello";
        Debug_String = null;
    }

    public void AddMoney(int amount)
    {
        _money += amount;
    }
}
