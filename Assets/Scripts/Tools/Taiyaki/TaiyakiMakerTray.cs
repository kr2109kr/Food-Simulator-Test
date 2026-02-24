using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TaiyakiMakerTray : MonoBehaviour, IInteractor
{
    [SerializeField] private TaiyakiMaker _taiyakiMaker;
    private string part = "Tray";

    private bool isTrayEmpty;

    [SerializeField] private GameObject _taiyakiPrefab;

    [SerializeField] private Vector3 _target = Vector3.zero;

    public GameObject TaiyakiGameObject { get; private set; }
    public GameObject combinedTaiyaki { get; set; }

    [SerializeField] private GameObject _fillingPrefab;

    [field: SerializeField] public bool IsAvaliable { get; set; } = true;

    public void Interact(Transform transform)
    {
        //_taiyakiMaker.Interact(_taiyaki, this.transform);
        TaiyakiGameObject = Instantiate(_taiyakiPrefab, this.transform);
        TaiyakiGameObject.GetComponent<Taiyaki>().StartTimer();
        FillRaw(TaiyakiGameObject.transform);

        
    }


    public bool IsEmpty()
    {
        if (transform.childCount != 0)
        {
            //Debug.Log(name + " is not Empty");
            return false;
        }
        else
        {
            //Debug.Log(name + " is Empty");
            return true;
        }
    }

    public void FillRaw(Transform rawTaiyaki)
    {
        StartCoroutine(FillRaw(rawTaiyaki));

        IEnumerator FillRaw(Transform rawTaiyaki)
        {
            float step = 0.02f * Time.fixedDeltaTime;
            Vector3 target = new Vector3(rawTaiyaki.localPosition.x, _target.y, rawTaiyaki.localPosition.z);


            while (rawTaiyaki.localPosition.y != target.y)
            {
                rawTaiyaki.localPosition = Vector3.MoveTowards(rawTaiyaki.transform.localPosition, target, step);
                yield return null;
            }

            yield return rawTaiyaki.GetComponent<Taiyaki>().Timer(5f);
        }
    }

    public void AddFilling(string color)
    {
        if (color == "Red-Beans")
        {
            var fillingObject = Instantiate(_fillingPrefab, TaiyakiGameObject.transform);
            fillingObject.GetComponent<MeshRenderer>().material.color = fillingObject.GetComponent<Filling>()._redBeanColor;
        }
        else if (color == "Custard")
        {
            var fillingObject = Instantiate(_fillingPrefab, TaiyakiGameObject.transform);
            fillingObject.GetComponent<MeshRenderer>().material.color = fillingObject.GetComponent<Filling>()._custardColor;
        }
        else if (color == "Chocolate")
        {
            var fillingObject = Instantiate(_fillingPrefab, TaiyakiGameObject.transform);
            fillingObject.GetComponent<MeshRenderer>().material.color = fillingObject.GetComponent<Filling>()._chocolateColor;
        }
    }

    public void Destroy()
    {
        Destroy(TaiyakiGameObject);
    }

    public void Combine(GameObject sideTaiyaki)
    {
        var taiyaki = new GameObject("Taiyaki");
        TaiyakiGameObject.transform.SetParent(taiyaki.transform, true);

    }
}
