using FoodSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class Taiyaki : MonoBehaviour
{
    private TaiyakiData _taiyakiData;
    private MeshRenderer _meshRenderer;

    [SerializeField] private Material _underCookedMaterial;
    [SerializeField] private Material _burntMaterial;
    [SerializeField] private Material _excellentMaterial;

    //Test
    //private Taiyaki taiyaki = new();

    private void Awake()
    {
        _taiyakiData = new();
        _meshRenderer = GetComponent<MeshRenderer>();

        //Test
        //taiyaki.SetFillingData(TaiyakiData.Filling.RedBeans);// param: FillingBox.GetFilling();
        //taiyaki.SetDonessData(TaiyakiData.Side.Left, TaiyakiData.Doness.Excellent);// param: TaiyakiMaker.xxx();

        
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            _meshRenderer.material = _burntMaterial;
        }
    }

    public void SetFillingData(TaiyakiData.Filling filling)
    {
        _taiyakiData.FillingType = filling;
    }

    public void SetDonessData(TaiyakiData.Side side, TaiyakiData.Doness doness)
    {
        _meshRenderer.material = _burntMaterial;
        _taiyakiData.SetDoness(side, doness);
    }

    public void PauseCooking()//left right
    {
        
    }

    

}
