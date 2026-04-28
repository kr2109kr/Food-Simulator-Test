using FoodSystem;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;

[Serializable]
public class Taiyaki : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    
    Material[] _materials;

    private bool _isPauseCookingLeft;
    private bool _isPauseCookingRight;

    public TaiyakiData _taiyakiSO;
    public TaiyakiData _dataForCheck;


    private TaiyakiData.Filling _currnetFilling;


    [SerializeField] private Material[] _materialsForChange;

    //Test
    //private Taiyaki taiyaki = new();]

    private TaiyakiData _taiyakiData;
    
    private class SideTaiyaki
    {
        public TaiyakiDataOLD taiyakiData;

    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _materials = _meshRenderer.materials;
        //Test
        //taiyaki.SetFillingData(TaiyakiData.Filling.RedBeans);// param: FillingBox.GetFilling();
        //taiyaki.SetDonessData(TaiyakiData.Side.Left, TaiyakiData.Doness.Excellent);// param: TaiyakiMaker.xxx();
    }

    private void Start()
    {
        StartCoroutine(CookingTimer(8f));
        
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            //ChangeLeftMaterials(_underCookedMaterial);
        }

        

    }

    /*
    public FoodData GetFood()
    {
        return _dataForCheck;
    }
    */


    public TaiyakiData GetFood()
    {
        return _taiyakiData;
    }

    public void ChangeMaterials(TaiyakiData.Side side, Material material)
    {
        switch (side)
        {
            case TaiyakiData.Side.Left:
                _materials[0] = _meshRenderer.materials[0];
                _materials[1] = material;
                break;
            case TaiyakiData.Side.Right:
                _materials[0] = material;
                _materials[1] = _meshRenderer.materials[1];
                break;
        }

        _meshRenderer.materials = _materials;
    }

    public void SetFillingData(TaiyakiData.Filling filling)
    {
        _dataForCheck.filling = filling;
    }

    public void SetDonessData(TaiyakiData.Side side, TaiyakiData.Doness doness)
    {

        //_meshRenderer.material ;
        _dataForCheck.leftDoness = doness;
        _dataForCheck.rightDoness = doness;
    }

    public void PauseCooking(TaiyakiData.Side side)//left right
    {
        _isPauseCookingLeft = side == TaiyakiData.Side.Left ? true : _isPauseCookingRight = true;
        //_isPauseCookingLeft = true;
        //_isPauseCookingRight = true;

    }

    public void ChangeDoness()
    {

    }

    public void ChangeFilling()
    {

    }

    public void Cooking()
    {
        
    }

    public IEnumerator CookingTimer(float seconds)
    {
        float timer = 0;
        float duration = seconds;

        foreach (Material material in _materialsForChange)
        {
            if (!_isPauseCookingLeft && !_isPauseCookingRight)
            {
                while (timer < duration)
                {
                    timer += Time.deltaTime;
                    yield return null;

                    ChangeMaterials(TaiyakiData.Side.Left, material);
                    ChangeMaterials(TaiyakiData.Side.Right, material);


                }

                timer = 0;
            }   
        }

        /*
        foreach (TaiyakiData.Doness state in Enum.GetValues(typeof(TaiyakiData.Doness)))
        {
            //ChangeColor(_data.GetColor(state));





            while (timer < duration)
            {
                if (!_isPauseCookingLeft)
                {
                    timer += Time.deltaTime;
                }
                yield return null;
            }

            timer = 0;
        }
        */
    }

    private void OnDestroy()
    {

    }

}
