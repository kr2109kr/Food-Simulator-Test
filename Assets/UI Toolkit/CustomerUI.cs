using NUnit.Framework.Internal;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    [SerializeField] public float test;



    VisualElement root;
    VisualElement progress;

    public VisualElement icon;

    public Sprite sprite1;
    public float xzy;
    
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        Label label = root.Q<Label>("Test");
        progress = root.Q<VisualElement>("Bar");

        progress.style.width = new StyleLength(new Length(50, LengthUnit.Percent));


        label.text = "Hello";

        icon = root.Q<VisualElement>("Icon");

        //icon.style.backgroundImage = new StyleBackground(AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Images/Custard.png"));
        icon.style.backgroundImage = new StyleBackground(sprite1);
    }

    private void Update()
    {
        progress.style.width = new StyleLength(new Length(test, LengthUnit.Percent));
    }

    public void UpdateUI(Sprite sprite)
    {
        icon.style.backgroundImage = new StyleBackground(sprite);
    }
}
