using System.Collections;
using UnityEngine;
using FoodSystem;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using KomorebiKitchen;

namespace CustomerSystem
{
    public class CustomerOrder : MonoBehaviour, IInteractor
    {
        [SerializeField] private float _waitTimeSeconds;
        [SerializeField] private float _delayBeforeNewOrder;



        [SerializeField] private float _speed;

        private Coroutine _walkCoroutine;



        [Header("Sprite")]
        [SerializeField] private Sprite[] _sprites;

        //private GameManager _gameManager;

        private WaitingState _waitingState;

        private TaiyakiDataOLD _taiyaki;
        private TaiyakiData _taiyakiSO;

        private FoodData _foodDataSO;

        private bool hasOrdered;

        public FoodOrder FoodOrders { get; private set; } = new();
        [SerializeField] private CustomerUI _customerUI;

        CustomerMovement _customerWalk;

        Dictionary<WaitingState, Action> ActionMap = new Dictionary<WaitingState, Action>();

        public UnityEvent<float> OnWaitingToOrder { get; private set; } = new UnityEvent<float>();
        public UnityEvent<float> OnWaitingForFood { get; private set; } = new UnityEvent<float>();
        public UnityEvent<float> Test { get; private set; } = new UnityEvent<float>();

        public UnityEvent OnAngryEvent { get; private set; } = new UnityEvent();
        public UnityEvent OnHappyEvent { get; private set; } = new UnityEvent();
        public UnityEvent OnDestroyEvent { get; private set; } = new UnityEvent();
        public UnityEvent OnFinishedEvent { get; private set; } = new UnityEvent();


        Coroutine _coroutineA;

        private List<FoodData> test = new();


        private Animator _animator;

        private GameManager _money;

        public FoodData FoodOrder;

        private GameManager _gameManager;

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
            _animator = GetComponent<Animator>();
            _gameManager = Transform.FindFirstObjectByType<GameManager>();
            _customerWalk = GetComponentInParent<CustomerMovement>();
        }

        public void Interact(Player player)
        {
            if (player.GetEquipment() is TaiyakiBowl taiyakiBowl)
            {
                if (_waitingState == WaitingState.ForFood)
                {





                    //((Bowl)player.GetEquipment()).GetFood();


                    //แก้ให้ coroutine หยุดก่นอเปลี่นย icon
                    RecieveFood(taiyakiBowl);
                    _waitingState = WaitingState.Done;
                    player.DestroyEquipment();
                }
            }

            else if (player.GetEquipment() is IchigoAmeCup ichigoAmeCup)
            {
                RecieveFood(ichigoAmeCup);
                //Debug.Log(ichigoAmeCup.GetFoods()[0]);
                _waitingState = WaitingState.Done;
                player.DestroyEquipment();
                AudioManager.Instance.PlayOneShot(FMODEvents.Instance.Interact, default);
            }

            else if (!player.GetEquipment())
            {
                if (_waitingState == WaitingState.ToOrder)
                {
                    AudioManager.Instance.PlayOneShot(FMODEvents.Instance.Interact, default);
                    OrderFood();
                    _waitingState = WaitingState.ForFood;
                    WaitForFood();
                }
            }
        }

        public void WaitToOrder()
        {
            StartCoroutine(Waiting(OnWaitingToOrder, 15)); //10
            Debug.Log("WaitToOrder");
        }

        public void WaitToOrder(Action action)
        {
            StartCoroutine(Waiting(OnWaitingToOrder, 15)); //10
        }

        public void WaitForFood()
        {
            StartCoroutine(Waiting(OnWaitingForFood, 30)); //10
        }


        public void OrderFood()
        {
            //FoodOrders.Add();
            //FoodOrders.Add(new IchigoAmeData(IchigoAmeData.Type.Strawberry));
            //FoodOrder = new IchigoAmeData(IchigoAmeData.Type.Mixed);
            FoodOrder = new IchigoAmeData();
        }

        public void Done()
        {
            //Destroy(gameObject);
            //transform.parent.GetComponent<CustomerManager>().CreateCustomer();
        }

        public void RecieveFood(TaiyakiBowl bowl)
        {
            if (FoodOrder.CompareData(bowl.GetFood()))
            {
                _money.AddMoney(bowl.GetFood().price[bowl.GetFood().filling]);
                Happy();
            }
            else
            {
                Angry();
            }
        }

        public void RecieveFood(IchigoAmeCup cup)
        {
            if (FoodOrder.CompareData(cup.GetFoodData()))
            {
                _gameManager.AddMoney(cup.GetFoodData().Price);
                Happy();
            }
            else
            {
                Angry();
            }
        }


        public void CheckOrder(TaiyakiBowl bowl)
        {

        }
        public void Pay()
        {

        }

        public void Happy()
        {
            OnHappyEvent.Invoke();
            _animator.SetTrigger("Happy");
            StartCoroutine(PlayAnimationAndWait("Happy", 0, () => WalkAway()));
            //Invoke(nameof(Done), 6f);
        }

        public void Angry()
        {
            OnAngryEvent.Invoke();
            _animator.SetTrigger("Angry");
            StartCoroutine(PlayAnimationAndWait("Angry", 0, () => WalkAway()));
        }

        public void WalkAway()
        {
            //_customerWalk.WalkAway();
            OnFinishedEvent.Invoke();
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
                unityEvent.Invoke(seconds / max * 100);

                seconds -= Time.deltaTime;
                yield return null;
            }

            //yield return CountdownTimer(max);


            OnAngryEvent.Invoke();

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
                unityEvent.Invoke(seconds / max * 100);

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
            Angry();
        }





        private IEnumerator PlayAnimationAndWait(string name, int layer, Action action)
        {
            yield return WaitForAnimation(name, layer);
            action();
        }

        private IEnumerator WaitForAnimation(string name, int layer)
        {
            Debug.Log("Start");
            while (!_animator.IsInTransition(layer))
            {
                Debug.Log("aa");
                yield return null;
            }

            while (_animator.IsInTransition(layer))
            {
                Debug.Log("bb");
                yield return null;
            }

            if (_animator.GetCurrentAnimatorStateInfo(layer).IsName(name))
            {
                while (_animator.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1f)
                {
                    if (_animator.IsInTransition(layer))
                    {
                        break;
                    }
                    //Debug.Log(_animator.GetCurrentAnimatorStateInfo(layer).normalizedTime);
                    yield return null;
                }
                /* อันเก่ามีปัญหาตรง Time
                while (_animator.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1f)
                {
                    yield return null;
                }
                */
            }

            Debug.Log("Animation has Finished");
        }
    }
}