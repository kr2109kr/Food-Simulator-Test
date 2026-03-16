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

    [SerializeField] private Money _money;


    [SerializeField] private VisualElement root;

    public VisualElement icon_0;
    public VisualElement icon_1;
    public VisualElement icon_2;

    public VisualElement progress_0;
    public VisualElement progressBar;
    public VisualElement progress_2;


    [SerializeField] private Image _image;

    public Button button;


    [SerializeField] public Sprite _redBeansSprite;
    [SerializeField] public Sprite _custardSprite;
    [SerializeField] public Sprite _chocolateSprite;

    [Header("Customer State")]
    [SerializeField] private Sprite orderSprite;
    [SerializeField] private Sprite happySprite;
    [SerializeField] private Sprite angrySprite;
    [SerializeField] private Sprite moneySprite;
    [SerializeField] private Sprite tipsSprite;

    private TextElement textElement;
    [SerializeField] private Customer _customer;

    private void OnEnable()
    {
        
        _customer.OnOrderedFoodEvent.AddListener(ChangeIconToFoodOrdered);
        _customer.Test.AddListener(ChangeProgress);
        _customer.OnAngryEvent.AddListener(ChangeIconToAngry);
        _customer.OnHappyEvent.AddListener(ChangeIconToHappy);

    }

    

    private void OnDisable()
    {
        _customer.OnOrderedFoodEvent.RemoveAllListeners();
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
        ChangeIconToWaitingToOrder();
        

    }

    private void Update()
    {
        //progress_0.style.width = new StyleLength(new Length(test, LengthUnit.Percent));
        //textElement.text = "Money: " + _money._money;
    }


    public void ChangeIconToWaitingToOrder()
    {
        _image.sprite = orderSprite;
        progressBar.style.display = DisplayStyle.None;
    }

    public void ChangeIconToFoodOrdered()
    {
        if (_customer.FoodOrderList.GetFoodType() == FoodData.FoodType.Taiyaki)
        {
            TaiyakiData taiyakiData = (TaiyakiData)_customer.FoodOrderList[0];

            switch (taiyakiData._filling)
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

        progressBar.style.display = DisplayStyle.Flex;
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
}
