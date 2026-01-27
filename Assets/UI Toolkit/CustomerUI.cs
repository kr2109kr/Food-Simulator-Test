using NUnit.Framework.Internal;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    [SerializeField] public float test;

    [SerializeField] private Money _money;


    [SerializeField] private VisualElement root;

    public VisualElement progress_0;
    public VisualElement progress_1;
    public VisualElement progress_2;

    public VisualElement icon_0;
    public VisualElement icon_1;
    public VisualElement icon_2;

    
    public Button button;


    [SerializeField] public Sprite iconSprite_RedBeans;
    [SerializeField] public Sprite iconSprite_Custard;
    [SerializeField] public Sprite iconSprite_Chocolate;

    
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        //progress_0 = root.Q<VisualElement>("Bar-1");
        //progress_0.style.width = new StyleLength(new Length(50, LengthUnit.Percent));


        //button = root.Q<Button>();
        

        icon_0 = root.Q<VisualElement>("Icon-0");
        icon_1 = root.Q<VisualElement>("Icon-1");
        icon_2 = root.Q<VisualElement>("Icon-2");

        //button.clicked += Button_clicked;

        //icon_2.style.backgroundImage = new StyleBackground(AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Images/Custard.png"));


    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //progress_0.style.width = new StyleLength(new Length(test, LengthUnit.Percent));
    }


    private void Button_clicked()
    {
        _money.AddMoney(100);
    }

    public void UpdateUI_0(Sprite sprite)
    {
        icon_0.style.backgroundImage = new StyleBackground(sprite);

    }

    public void UpdateUI_1(Sprite sprite)
    {
        icon_1.style.backgroundImage = new StyleBackground(sprite);

    }

    public void UpdateUI_2(Sprite sprite)
    {
        icon_2.style.backgroundImage = new StyleBackground(sprite);
        //icon.style.backgroundImage = new StyleBackground(sprite);
    }

    
}
