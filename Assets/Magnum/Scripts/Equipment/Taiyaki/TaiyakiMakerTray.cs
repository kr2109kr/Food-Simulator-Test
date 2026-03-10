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

    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _target = Vector3.zero;
    

    public GameObject TaiyakiGameObject { get; private set; }
    public GameObject combinedTaiyaki { get; set; }

    [SerializeField] private GameObject _fillingPrefab;

    [field: SerializeField] public bool IsAvaliable { get; set; } = true;
    



    private bool isUsing;


    public void Interact(Equipment playerEquipment)
    {
        if (playerEquipment != null && playerEquipment.CheckEquipment("Batter"))
        {
            //_taiyakiMaker.Interact(_taiyaki, this.transform);
            TaiyakiGameObject = Instantiate(_taiyakiPrefab, transform);
            TaiyakiGameObject.transform.localPosition = _startPosition;

            var _batter = playerEquipment.GetComponent<Batter>();
            _batter.IsPouring();

            //TaiyakiGameObject.GetComponent<Taiyaki>().StartTimer();
            FillRaw(TaiyakiGameObject.transform);
        }

        if (playerEquipment != null && playerEquipment.CheckEquipment("Tongs"))
        {
            if (combinedTaiyaki != null)
            {
                var _tongs = playerEquipment.GetComponent<Tongs>();

                _tongs.PickUp(combinedTaiyaki);
                RemoveToOtherTray();

            }
            
            //Tongs.PickupTaiyaki();
        }
    }


    public bool IsNotEmpty()
    {
        if (transform.childCount != 0)
        {
            //Debug.Log(name + " is not Empty");
            return true;
        }
        else
        {
            //Debug.Log(name + " is Empty");
            return false;
        }
    }

    public void CreateCombinedTaiyaki()
    {
        combinedTaiyaki = new GameObject("Taiyaki");
        combinedTaiyaki.transform.SetParent(transform, false);
    }

    public void SetCombinedTaiyaki(Taiyaki otherTaiyaki)
    {

        TaiyakiGameObject.transform.SetParent(combinedTaiyaki.transform);

        otherTaiyaki.transform.SetParent(combinedTaiyaki.transform);

        otherTaiyaki.transform.localRotation = Quaternion.Euler(0,0,180);
        otherTaiyaki.transform.localPosition = Vector3.zero;
    }

    //
    

    public void RemoveToOtherTray()
    {
        combinedTaiyaki = null;
    }

    public void RecieveCombinedTaiyaki(GameObject combinedTaiyaki)
    {
        this.combinedTaiyaki = combinedTaiyaki;

        Debug.Log(combinedTaiyaki.transform.eulerAngles.z);


        //combinedTaiyaki.transform.localRotation = Quaternion.Euler(0, 0, 0);
        combinedTaiyaki.transform.Rotate(0, 0, 180);




        combinedTaiyaki.transform.localPosition = Vector3.zero;
    }
    //
    

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
}
