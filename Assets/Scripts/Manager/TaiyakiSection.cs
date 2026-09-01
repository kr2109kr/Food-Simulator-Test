using KomorebiKitchen;
using UnityEngine;

public class TaiyakiSection : Section
{
    [SerializeField] private GameObject _redBeans;
    [SerializeField] private GameObject _custard;
    [SerializeField] private GameObject _chocolate;

    private bool _isRedBeansLocked;
    private bool _isCustardLocked;
    private bool _isChocolateLocked;

    public bool IsRedBeansLocked
    {
        get { return _isRedBeansLocked; }
        set { _isRedBeansLocked = value; _redBeans.SetActive(!value); }
    }

    public bool IsCustardLocked
    {
        get { return _isCustardLocked; }
        set { _isCustardLocked = value; _custard.SetActive(!value); }
    }

    public bool IsChocolateLocked
    {
        get { return _isChocolateLocked; }
        set { _isChocolateLocked = value; _chocolate.SetActive(!value); }
    }
}
