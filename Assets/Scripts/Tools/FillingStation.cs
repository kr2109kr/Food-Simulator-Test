using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FillingStation : MonoBehaviour, IInteractor
{
    [SerializeField] private GameObject _gameObject;

    Vector3 _originalPos;
    Filling _filling;

    private enum Filling
    {
        RedBeans,
        Custard,
        Chocolate
    }

    private void Start()
    {
        _originalPos = transform.position;
    }

    private void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            BackToOriginPos();
        }
    }

    public void BackToOriginPos()
    {
        transform.position = _originalPos;


    }

    private void SelectRedBeans()
    {
        
    }

    private void SelectCustart()
    {

    }

    private void SelectChocolate()
    {

    }

    public void Interact(Transform transform)
    {
        switch (_filling)
        {
            case Filling.RedBeans:
                break;
            case Filling.Custard:
                break;
            case Filling.Chocolate:
                break;
        } 

        FillFilling();
    }

    private void FillFilling()
    {
        //throw new NotImplementedException();
    }
}
