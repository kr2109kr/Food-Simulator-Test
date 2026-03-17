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



    public UnityEvent<float> OnWaitingToOrderEvent { get; private set; } = new UnityEvent<float>();
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
        WaitToOrderFood();
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


    public void WaitToOrderFood()
    {
        StartCoroutine(CountdownTimer(OnWaitingToOrderEvent, 10));
    }

    public void OrderFood()
    {
        FoodOrderList.AddFoodToList();
        StartCoroutine(CountdownTimer(Test, 30));
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

    private IEnumerator CountdownTimer(UnityEvent<float> unityEvent, float seconds)
    {
       //yield return new WaitForSeconds(seconds);
        
        //ChangeColor(_defaultColor);
        float max = seconds;

        //Order();

        while (seconds > 0)
        {
            unityEvent.Invoke((seconds / max) * 100);

            seconds -= Time.deltaTime;
            yield return null;
        }

        //yield return CountdownTimer(max);

        OnAngryEvent.Invoke();
        
    }

    private void Order()
    {
        
    }

    

    

    public void CheckOrderopo(/*Food.Taiyaki.Filling filling*/)
    {

    }

    
}
