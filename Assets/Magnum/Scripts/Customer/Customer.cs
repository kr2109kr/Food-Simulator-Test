using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;
using FoodSystem;
using NUnit.Framework.Internal;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Customer : MonoBehaviour, IInteractor
{
    [SerializeField] private float _waitTimeSeconds;
    [SerializeField] private float _delayBeforeNewOrder;
    
    

    //[SerializeField, TextArea] private string Debug_String;

    //[SerializeField] private CustomerUI _customerUI;

    //[SerializeField] private string order;

    //[SerializeField] private TaiyakiSO _taiyaki;

    //private Food.Taiyaki.Filling _taiyakiFilling;

    //private MeshRenderer _meshRenderer;
    //private Color _defaultColor;

    [Header("Sprite")]
    [SerializeField] private Sprite[] _sprites;

    [SerializeField] private Money money;

    private State _state;



    private TaiyakiData _taiyaki;

    public FoodOrder FoodOrderList { get; private set; } = new();
    [SerializeField] private CustomerUI _customerUI;



    public UnityEvent OnOrderState { get; private set; } = new UnityEvent();
    public UnityEvent OnOrderedFoodEvent { get; private set; } = new UnityEvent();
    public UnityEvent<float> Test { get; private set; } = new UnityEvent<float>();

    public UnityEvent OnAngryEvent { get; private set; } = new UnityEvent();
    public UnityEvent OnHappyEvent { get; private set; } = new UnityEvent();


    private enum State
    {
        WaitingToOrder,
        HasOrdered,
        WaitingForCook,
        ReceivedOrder
    }
    private void Awake()
    {
        
    }

    private void Start()
    {
        //StartCoroutine(CountdownTimer(10));
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            OrderFood();
        }

        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            //CheckOrder();
        }
    }

    public void Interact(Player player)
    {
        if (player.GetEquipment() && player.GetEquipment().CheckEquipment("Bowl"))
        {
            player.DestroyEquipment();
            OnHappyEvent.Invoke();

        }

        else if (!player.GetEquipment())
        {
            OrderFood();
        }
    }


    public void OrderFood()
    {
        FoodOrderList.AddFoodToList();
        StartCoroutine(CountdownTimer(30));
        OnOrderedFoodEvent.Invoke();
    }

    public void RecieveFood(Bowl bowl)
    {
        CheckOrder(bowl);
    }


    public void CheckOrder(Bowl bowl)
    {
        //_foodOrder.CompareFood(bowl);
        
    }

    private IEnumerator CountdownTimer(float seconds)
    {
       //yield return new WaitForSeconds(seconds);
        
        //ChangeColor(_defaultColor);
        float max = seconds;

        //Order();

        while (seconds > 0)
        {
            Test.Invoke((seconds / max) * 100);

            seconds -= Time.deltaTime;
            yield return null;
        }

        //yield return CountdownTimer(max);

        OnAngryEvent.Invoke();
        
    }

    private void Order()
    {
        /*
        _taiyakiFilling = Food.Taiyaki.RandomFilling();
        //Debug.Log(gameObject.name + "order" + _taiyakiFilling);

        //int random_0 = Random.Range(0, _taiyaki.datas.Length);

        if (name == "Customer-0")
        {
            switch (_taiyakiFilling)
            {
                case Food.Taiyaki.Filling.RedBeans:
                    _customerUI.UpdateUI_0(_customerUI.iconSprite_RedBeans);
                    break;
                case Food.Taiyaki.Filling.Custart:
                    _customerUI.UpdateUI_0(_customerUI.iconSprite_Custard);
                    break;
                case Food.Taiyaki.Filling.Chocolate:
                    _customerUI.UpdateUI_0(_customerUI.iconSprite_Chocolate);
                    break;

            }
        }

        else if (name == "Customer-1")
        {
            switch (_taiyakiFilling)
            {
                case Food.Taiyaki.Filling.RedBeans:
                    _customerUI.UpdateUI_1(_customerUI.iconSprite_RedBeans);
                    break;
                case Food.Taiyaki.Filling.Custart:
                    _customerUI.UpdateUI_1(_customerUI.iconSprite_Custard);
                    break;
                case Food.Taiyaki.Filling.Chocolate:
                    _customerUI.UpdateUI_1(_customerUI.iconSprite_Chocolate);
                    break;

            }
        }

        else if (name == "Customer-2")
        {
            switch (_taiyakiFilling)
            {
                case Food.Taiyaki.Filling.RedBeans:
                    _customerUI.UpdateUI_2(_customerUI.iconSprite_RedBeans);
                    break;
                case Food.Taiyaki.Filling.Custart:
                    _customerUI.UpdateUI_2(_customerUI.iconSprite_Custard);
                    break;
                case Food.Taiyaki.Filling.Chocolate:
                    _customerUI.UpdateUI_2(_customerUI.iconSprite_Chocolate);
                    break;

            }
        }

        else
        {
            Debug.Log("Error");
        }

        //int random_0 = Random.Range(0, _taiyaki.datas.Length);
        //_customerUI.UpdateUI_0(_taiyaki.datas[random_0].sprite);
        //Debug.Log("Order : " + _taiyaki.datas[random].name);
        */
    }

    

    

    public void CheckOrderopo(/*Food.Taiyaki.Filling filling*/)
    {
        
        /*
        Debug.Log("Customer " + _taiyakiFilling + filling);
        if (_taiyakiFilling == filling)
        {
            money.AddMoney(200);
            ChangeColor(Color.green);
        }
        else if (_taiyakiFilling != filling)
        {
            money.AddMoney(-200);
            ChangeColor(Color.red);
        }
    }

    private void ChangeColor(Color color)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
        */
    }

    
}
