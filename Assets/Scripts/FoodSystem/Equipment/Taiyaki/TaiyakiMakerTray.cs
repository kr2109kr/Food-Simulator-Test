using FoodSystem;
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

    Taiyaki _taiyaki;
    SideTaiyaki _sideTaiyaki;

    private bool isUsing;

    private void Start()
    {
        if (IsNotEmpty())
        {
            combinedTaiyaki = transform.GetChild(0).gameObject;
        }
    }

    public void Interact(Player player)
    {
        if (player.GetEquipment() is Kettle kettle)
        {
            kettle.IsPouring();
            FillRaw();
        }

        else if (player.GetEquipment() != null && player.GetEquipment().CheckEquipmentOLD("Tongs"))
        {
            if (combinedTaiyaki != null)
            {
                var _tongs = player.GetEquipment().GetComponent<Tongs>();

                _tongs.PickUp(combinedTaiyaki);
                combinedTaiyaki.GetComponent<Taiyaki>().PauseCooking(TaiyakiDataOLD.Side.Left);

                RemoveToOtherTray();


            }   
        }
    }

    public bool IsNotEmpty()
    {
        if (transform.childCount != 0)
        {
            return true;
        }

        else
        {
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

        //TaiyakiGameObject.transform.SetParent(combinedTaiyaki.transform);

        //otherTaiyaki.transform.SetParent(combinedTaiyaki.transform);

        combinedTaiyaki = otherTaiyaki.gameObject;
        combinedTaiyaki.transform.localRotation = Quaternion.Euler(0,0,180);
        combinedTaiyaki.transform.localPosition = Vector3.zero;
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


        combinedTaiyaki.transform.localRotation = Quaternion.Euler(0, 0, 180);
        //combinedTaiyaki.transform.Rotate(0, 0, 180);

        


        combinedTaiyaki.transform.localPosition = Vector3.zero;
    }
    //

    
    public void FillRaw()
    {
        IEnumerator FillRaw(Transform rawTaiyaki)
        {
            float step = 0.02f * Time.fixedDeltaTime;
            Vector3 target = new Vector3(rawTaiyaki.localPosition.x, _target.y, rawTaiyaki.localPosition.z);


            while (rawTaiyaki.localPosition.y != target.y)
            {
                rawTaiyaki.localPosition = Vector3.MoveTowards(rawTaiyaki.transform.localPosition, target, step);
                yield return null;
            }

            rawTaiyaki.GetComponent<SideTaiyaki>().StartCooking();
        }


        TaiyakiGameObject = Instantiate(_taiyakiPrefab, transform);
        TaiyakiGameObject.transform.localPosition = _startPosition;

        //TaiyakiGameObject.GetComponent<SideTaiyaki>().StartCooking();

        StartCoroutine(FillRaw(TaiyakiGameObject.transform));

        
    }



    public void AddFilling(string color)
    {

        /*
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
        */
    }

    
}
