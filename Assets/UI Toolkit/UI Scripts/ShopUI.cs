using KomorebiKitchen;
using System;
using System.Linq;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopUI : MonoBehaviour
{
    private VisualElement _root;
    private Button _unlockTakoyakiButton;

    // ===== Ichigo Ame =====
    private Button _unlockIchigoAmeButton;
    private Button _unlockStrawberryButton;
    private Button _unlockGrapeButton;
    private Button _unlockOrangeButton;

    private Button _equipmentIchigoAme;
    private VisualElement _fillingIchigoAme;

    [SerializeField] private FoodPrice _foodPrice;

    //Test Data
    private int _grapePrice = 10;
    private int _orangePrice = 20;
    private int _strawberryPrice = 30;


    


    [SerializeField] private SectionManager _sectionManager;


    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _unlockTakoyakiButton = _root.Q<Button>("Takoyaki");
        //_unlockIchigoAmeButton = _root.Q("IchigoAme").Q<Button>("Filling");


        Debug.Log("aa");

        GameManager.Instance.OnShopMenu.AddListener(OpenShopMenu);
        #region wdwdw

        #endregion
    }

    private void OnEnable()
    {
        _root.dataSource = _foodPrice;
        TaiyakiBinding();
        TakoyakiBinding();
        IchigoAmeBinding();

        SubscribeToEvents();
    }

    private void OnDisable()
    {

    }



    private void TaiyakiBinding()
    {
        var redBeans = _root.Q("Taiyaki").Q("Type").Q("RedBeans").Q("Price");
        var custard = _root.Q("Taiyaki").Q("Type").Q("Custard").Q("Price");
        var chocolate = _root.Q("Taiyaki").Q("Type").Q("Chocolate").Q("Price");

        redBeans.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("RedBeansPrice"), bindingMode = BindingMode.ToTarget });
        custard.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("CustardPrice"), bindingMode = BindingMode.ToTarget });
        chocolate.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("ChocolatePrice"), bindingMode = BindingMode.ToTarget });

        var unlockRedBeansButton = _root.Q("Taiyaki").Q("Type").Q<Button>("RedBeans");
        var unlockCustardButton = _root.Q("Taiyaki").Q("Type").Q<Button>("Custard");
        var unlockChocolateButton = _root.Q("Taiyaki").Q("Type").Q<Button>("Chocolate");

        unlockRedBeansButton.clicked += _sectionManager.UnlockRedBeans;
        unlockCustardButton.clicked += _sectionManager.UnlockCustard;
        unlockChocolateButton.clicked += _sectionManager.UnlockChocolate;
    }


    private void TaiyakiUnbinding()
    {
        var redBeans = _root.Q("Taiyaki").Q("Type").Q("RedBeans").Q("Price");
        var custard = _root.Q("Taiyaki").Q("Type").Q("Custard").Q("Price");
        var chocolate = _root.Q("Taiyaki").Q("Type").Q("Chocolate").Q("Price");

        redBeans.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("RedBeansPrice"), bindingMode = BindingMode.ToTarget });
        custard.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("CustardPrice"), bindingMode = BindingMode.ToTarget });
        chocolate.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("ChocolatePrice"), bindingMode = BindingMode.ToTarget });

        var unlockRedBeansButton = _root.Q("Taiyaki").Q("Type").Q<Button>("RedBeans");
        var unlockCustardButton = _root.Q("Taiyaki").Q("Type").Q<Button>("Custard");
        var unlockChocolateButton = _root.Q("Taiyaki").Q("Type").Q<Button>("Chocolate");

        unlockRedBeansButton.clicked -= _sectionManager.UnlockRedBeans;
        unlockCustardButton.clicked -= _sectionManager.UnlockCustard;
        unlockChocolateButton.clicked -= _sectionManager.UnlockChocolate;
    }

    private void TakoyakiBinding()
    {
        var octopus = _root.Q("Takoyaki").Q("Type").Q("Octopus").Q("Price");
        var shrimp = _root.Q("Takoyaki").Q("Type").Q("Shrimp").Q("Price");
        var bacon = _root.Q("Takoyaki").Q("Type").Q("Bacon").Q("Price");

        octopus.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("OctopusPrice"), bindingMode = BindingMode.ToTarget });
        shrimp.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("ShrimpPrice"), bindingMode = BindingMode.ToTarget });
        bacon.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("BaconPrice"), bindingMode = BindingMode.ToTarget });

        var unlockOctopusButton = _root.Q("Takoyaki").Q("Type").Q<Button>("Octopus");
        var unlockShrimpButton = _root.Q("Takoyaki").Q("Type").Q<Button>("Shrimp");
        var unlockBaconButton = _root.Q("Takoyaki").Q("Type").Q<Button>("Bacon");

        unlockOctopusButton.clicked += _sectionManager.UnlockRedBeans;
        unlockShrimpButton.clicked += _sectionManager.UnlockStrawberry;
        unlockBaconButton.clicked += _sectionManager.UnlockOrange;
    }

    private void IchigoAmeBinding()
    {
        _equipmentIchigoAme = _root.Q("IchigoAme").Q<Button>("Equipment");
        _fillingIchigoAme = _root.Q("IchigoAme").Q<VisualElement>("Fruits");

        var _test = _root.Q("IchigoAme").Q("Equipment").Q("Price");
        



        // DataSource
        //_root.dataSource = _foodPrice;

        _equipmentIchigoAme.bindingPath = "Price";


        var nameBinding = new DataBinding()
        {
            dataSourcePath = new PropertyPath("IchigoAmePrice"),
            bindingMode = BindingMode.ToTarget
        };

        _test.SetBinding("text", nameBinding);


        var strawberry = _root.Q("IchigoAme").Q("Type").Q("Strawberry").Q("Price");
        strawberry.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("StrawberryPrice"), bindingMode = BindingMode.ToTarget });

        var orange = _root.Q("IchigoAme").Q("Type").Q("Orange").Q("Price");
        orange.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("OrangePrice"), bindingMode = BindingMode.ToTarget });

        var grape = _root.Q("IchigoAme").Q("Type").Q("Grape").Q("Price");
        grape.SetBinding("text", new DataBinding() { dataSourcePath = new PropertyPath("GrapePrice"), bindingMode = BindingMode.ToTarget });


        var strawberryButton = _root.Q("IchigoAme").Q("Type").Q<Button>("Strawberry");
        var grapeButton = _root.Q("IchigoAme").Q("Type").Q<Button>("Grape");
        var orangeButton = _root.Q("IchigoAme").Q("Type").Q<Button>("Orange");



        grapeButton.clicked += _sectionManager.UnlockGrape;
        strawberryButton.clicked += _sectionManager.UnlockStrawberry;
        orangeButton.clicked += _sectionManager.UnlockOrange;
    }

    

    private void SubscribeToEvents()
    {
        _equipmentIchigoAme.clicked += UnlockIchigoAme;
    }



    private void OpenShopMenu(bool value)
    {
        gameObject.SetActive(value);
    }

    

    private void UnlockTakoyaki()
    {
        _sectionManager.UnlockTakoyakiSection();
        _unlockTakoyakiButton.style.display = DisplayStyle.None;
    }

    private void UnlockIchigoAme()
    {
        _sectionManager.UnlockIchigoAmeSection();
        _equipmentIchigoAme.style.display = DisplayStyle.None;
        _fillingIchigoAme.style.display = DisplayStyle.Flex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Test()
    {

    }
}
