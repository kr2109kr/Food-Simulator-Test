using FoodSystem;
using UnityEngine;

public class Taiyaki : MonoBehaviour
{
    private TaiyakiData _taiyakiData;

    //Test
    private Taiyaki taiyaki = new();

    private void Awake()
    {
        _taiyakiData = new();

        //Test
        taiyaki.SetFillingData(TaiyakiData.Filling.RedBeans);// param: FillingBox.GetFilling();
        taiyaki.SetDonessData(TaiyakiData.Side.Left, TaiyakiData.Doness.Excellent);// param: TaiyakiMaker.xxx();
    }

    public void SetFillingData(TaiyakiData.Filling filling)
    {
        _taiyakiData.FillingType = filling;
    }

    public void SetDonessData(TaiyakiData.Side side, TaiyakiData.Doness doness)
    {
        _taiyakiData.SetDoness(side, doness);
    }
}
