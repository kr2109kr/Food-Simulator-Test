using System.CodeDom.Compiler;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodPrice", menuName = "Scriptable Objects/FoodPrice")]
public class FoodPrice : ScriptableObject
{
    public int TaiyakiPrice;
    public int RedBeansPrice;
    public int CustardPrice;
    public int ChocolatePrice;

    public int TakoyakiPrice;
    public int OctopusPrice;
    public int ShrimpPrice;
    public int BaconPrice;

    public int IchigoAmePrice;
    public int StrawberryPrice;
    public int OrangePrice;
    public int GrapePrice;

    private void Start()
    {

    }
}
