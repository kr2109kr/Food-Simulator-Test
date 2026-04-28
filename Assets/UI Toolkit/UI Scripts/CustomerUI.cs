using CustomerSystem;
using FoodSystem;
using NUnit.Framework.Internal;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CustomerUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    [SerializeField] public float test;

    [SerializeField] private GameManager _money;


    [SerializeField] private VisualElement root;

    public VisualElement icon_0;
    public VisualElement icon_1;
    public VisualElement icon_2;

    public VisualElement progress_0;
    public VisualElement progressBar;
    public VisualElement progress_2;


    [SerializeField] private Image _image;

    public Button button;

    [Header("Taiyaki Icon")]
    [SerializeField] private Sprite _redBeansSprite;
    [SerializeField] private Sprite _custardSprite;
    [SerializeField] private Sprite _chocolateSprite;

    [Header("Takoyaki Icon")]
    [SerializeField] private Sprite _takoSprite;
    [SerializeField] private Sprite _shrimpSprite;
    [SerializeField] private Sprite _baconSprite;


    [Header("IchigoAme Icon")]
    [SerializeField] private Sprite _strawberrySprite;
    [SerializeField] private Sprite _OrangeSprite;
    [SerializeField] private Sprite _GrapeSprite;
    [SerializeField] private Sprite _MixedSprite;


    [Header("Customer State")]
    [SerializeField] private Sprite orderSprite;
    [SerializeField] private Sprite happySprite;
    [SerializeField] private Sprite angrySprite;
    [SerializeField] private Sprite moneySprite;
    [SerializeField] private Sprite tipsSprite;

    private TextElement textElement;
    [SerializeField] private CustomerOrder _customer;

    private void OnEnable()
    {
        _customer.OnWaitingToOrder.AddListener(ChangeIconToWaitingToOrder);
        _customer.OnWaitingForFood.AddListener(ChangeIconToFoodOrdered);
        //_customer.Test.AddListener(ChangeProgress);
        _customer.OnAngryEvent.AddListener(ChangeIconToAngry);
        _customer.OnHappyEvent.AddListener(ChangeIconToHappy);
        _customer.OnFinishedEvent.AddListener(CloseUI);

    }

    

    private void OnDisable()
    {
        _customer.OnWaitingToOrder.RemoveListener(ChangeIconToWaitingToOrder);
        _customer.OnWaitingForFood.RemoveListener(ChangeIconToFoodOrdered);
    }

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        progress_0 = root.Q<VisualElement>("ProgressBarValue");

        //progress_0.style.width = new StyleLength(new Length(50, LengthUnit.Percent));
        progressBar = root.Q<VisualElement>("ProgressBar");

        //button = root.Q<Button>();
        
        /*
        icon_0 = root.Q<VisualElement>("Icon-0");
        icon_1 = root.Q<VisualElement>("Icon-1");
        icon_2 = root.Q<VisualElement>("Icon-2");

        progress_0 = root.Q<VisualElement>("Progress-0");
        progress_1 = root.Q<VisualElement>("Progress-1");
        progress_2 = root.Q<VisualElement>("Progress-2");

        textElement = root.Q<TextElement>("Text");
        */

        _image = root.Q<Image>();



        //button.clicked += Button_clicked;

        //icon_2.style.backgroundImage = new StyleBackground(AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Images/Custard.png"));


        
    }

    private void Start()
    {
        root.style.display = DisplayStyle.None;
    }

    private void Update()
    {
        //progress_0.style.width = new StyleLength(new Length(test, LengthUnit.Percent));
        //textElement.text = "Money: " + _money._money;
    }



    public void ChangeIconToWaitingToOrder(float percent)
    {
        root.style.display = DisplayStyle.Flex;
        _image.sprite = orderSprite;
        progressBar.style.display = DisplayStyle.Flex;
        progress_0.style.maxHeight = new StyleLength(new Length(percent, LengthUnit.Percent));

    }



    public void ChangeIconToFoodOrdered(float percent)
    {
        if (_customer.FoodOrder is TaiyakiData taiyakiData)
        {
            switch (taiyakiData.filling)
            {
                case TaiyakiData.Filling.RedBeans:
                    _image.sprite = _redBeansSprite;
                    break;

                case TaiyakiData.Filling.Custard:
                    _image.sprite = _custardSprite;
                    break;

                case TaiyakiData.Filling.Chocolate:
                    _image.sprite = _chocolateSprite;
                    break;
            }  
        }

        else if (_customer.FoodOrder is TakoyakiData takoyakiData)
        {
            switch (takoyakiData.filling)
            {
                case TakoyakiData.Filling.Tako:
                    _image.sprite = _takoSprite;
                    break;

                case TakoyakiData.Filling.Shrimp:
                    _image.sprite = _shrimpSprite;
                    break;

                case TakoyakiData.Filling.Bacon:
                    _image.sprite = _baconSprite;
                    break;
            }
        }

        else if (_customer.FoodOrder is IchigoAmeData ichigoAmeData)
        {
            switch (ichigoAmeData.type)
            {
                case IchigoAmeData.Type.Strawberry:
                    _image.sprite = _strawberrySprite;
                    break;

                case IchigoAmeData.Type.Orange:
                    _image.sprite = _OrangeSprite;
                    break;

                case IchigoAmeData.Type.Grape:
                    _image.sprite = _GrapeSprite;
                    break;

                case IchigoAmeData.Type.Mixed:
                    _image.sprite = _MixedSprite;
                    break;
                default:
                    _image.sprite = null;
                    break;
            }
        }

        progress_0.style.maxHeight = new StyleLength(new Length(percent, LengthUnit.Percent));
    }

    public void ChangeProgress(float percent)
    {
        progress_0.style.maxHeight = new StyleLength(new Length(percent, LengthUnit.Percent));
    }

    public void ChangeIconToAngry()
    {
        _image.sprite = angrySprite;
        progressBar.style.display = DisplayStyle.None;
    }

    private void ChangeIconToHappy()
    {
        Debug.Log("Happy");
        _image.sprite = happySprite;
        progressBar.style.display = DisplayStyle.None;
    }

    private void Button_clicked()
    {
        _money.AddMoney(100);
    }

    public void UpdateUI_0(Sprite sprite)
    {
        icon_0.style.backgroundImage = new StyleBackground(sprite);

    }

    public void CloseUI()
    {
        root.style.display = DisplayStyle.None;
    }
    
}
