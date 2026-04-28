using UnityEngine;

public class HalfTakoyaki : Takoyaki
{
    [SerializeField] private GameObject _takoFilling;
    [SerializeField] private GameObject _shrimpFilling;
    [SerializeField] private GameObject _baconFilling;

    public void ShowTako()
    {
        _takoFilling.SetActive(true);
    }

    public void ShowShrimp()
    {
        _shrimpFilling.SetActive(true);
    }
    public void ShowBacon()
    {
        _baconFilling.SetActive(true);
    }
}
