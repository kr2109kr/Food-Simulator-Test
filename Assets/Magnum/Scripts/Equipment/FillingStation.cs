using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FillingStation : MonoBehaviour
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

    private void SelectRedBeans()
    {
        
    }

    private void SelectCustart()
    {

    }

    private void SelectChocolate()
    {

    }

    public void Interact()
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
