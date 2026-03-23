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
using System;

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

    private WaitingState _waitingState;

    


    private TaiyakiDataOLD _taiyaki;
    private TaiyakiData _taiyakiSO;

    private FoodData _foodDataSO;

    private bool hasOrdered;

    public FoodOrder FoodOrders { get; private set; } = new();
    [SerializeField] private CustomerUI _customerUI;



    Dictionary<WaitingState, Action> ActionMap = new Dictionary<WaitingState, Action>(); 
 
    public UnityEvent<float> OnWaitingToOrder { get; private set; } = new UnityEvent<float>();
    public UnityEvent<float> OnWaitingForFood { get; private set; } = new UnityEvent<float>();
    public UnityEvent<float> Test { get; private set; } = new UnityEvent<float>();

    public UnityEvent OnAngryEvent { get; private set; } = new UnityEvent();
    public UnityEvent OnHappyEvent { get; private set; } = new UnityEvent();
    public UnityEvent OnDestroyEvent { get; private set; } = new UnityEvent();


    Coroutine _coroutineA;

    private enum WaitingState
    {
        ToOrder,
        //HasOrdered,
        ForFood,
        //ReceivedOrder
        Done
    }
    private void Awake()
    {
        Debug.Log((WaitingState)2);
        Debug.Log((WaitingState)4);
    }

    private void Start()
    {
        WaitToOrder();
    }

    public void Interact(Player player)
    {
        if (player.GetEquipment() && player.GetEquipment().CheckEquipment("Bowl"))
        {
            if (_waitingState == WaitingState.ForFood)
            {
                




                ((Bowl)player.GetEquipment()).GetFood();
                //แก้ให้ coroutine หยุดก่นอเปลี่นย icon
                RecieveFood((Bowl)player.GetEquipment());
                _waitingState = WaitingState.Done;
                player.DestroyEquipment();
            }
        }

        else if (!player.GetEquipment())
        {
            if (_waitingState == WaitingState.ToOrder)
            {
                OrderFood();
                _waitingState = WaitingState.ForFood;
                WaitForFood();
            }
        }
    }


    public void WaitToOrder()
    {
        StartCoroutine(Waiting(OnWaitingToOrder, 10));
    }

    public void WaitForFood()
    {
        StartCoroutine(Waiting(OnWaitingForFood, 10));
    }



    public void OrderFood()
    {
        FoodOrders.Add();
    }

    public void Done()
    {
        Destroy(gameObject);
        transform.parent.GetComponent<CustomerManager>().CreateCustomer();
    }

    public void RecieveFood(Bowl bowl)
    {

        if (FoodOrders.CompareData(bowl.GetFood()))
        {
            OnHappyEvent.Invoke();
            Invoke(nameof(Done), 2f);

            
        }

        else
        {
            OnAngryEvent.Invoke();
            Invoke(nameof(Done), 2f);
        }
        
    }


    public void CheckOrder(Bowl bowl)
    {
        
        
    }

    public void WalkAway()
    {

    }

    private IEnumerator CountdownTimer(UnityEvent<float> unityEvent, float seconds)
    {
       //yield return new WaitForSeconds(seconds);
        
        //ChangeColor(_defaultColor);
        float max = seconds;

        //Order();
        WaitingState _currentState = _waitingState;

        while (seconds > 0) //&& _currentState == _waitingState
        {
            unityEvent.Invoke((seconds / max) * 100);

            seconds -= Time.deltaTime;
            yield return null;
        }

        //yield return CountdownTimer(max);


        OnAngryEvent.Invoke();
        WalkAway();
        
    }



    private void Order()
    {

    }
    
    private IEnumerator Waiting(UnityEvent<float> unityEvent, float seconds)
    {
        float max = seconds;
        WaitingState startaitingState = _waitingState;

        while (seconds > 0)
        {
            unityEvent.Invoke((seconds / max) * 100);

            yield return null;//

            seconds -= Time.deltaTime;
            if (startaitingState != _waitingState)
            {
                Debug.Log("Break");
                yield break;
            }

            //yield return null;
        }
        OnAngryEvent.Invoke();
        Invoke(nameof(Done), 2f);
        Debug.Log("Angry");
    }
}
