using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractor
{
    void Interact(Transform transform);

}

public class TaiyakiMaker : MonoBehaviour
{
    [SerializeField] private Transform _taiyakiMakerTray;

    [SerializeField] private Vector3 _target;

    [SerializeField] private Transform _rightPan;


    private TaiyakiMakerTray _tray;

    [SerializeField] private TaiyakiMakerPan _leftTaiyakiMakerPan;
    [SerializeField] public TaiyakiMakerPan _rightTaiyakiMakerPan;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="taiyaki"></param>
    /// <param name="taiyakiParent"></param>
    /// 

    // TaiyaakiTray กดแล้วเติมแป้ง
    public void Interact(GameObject taiyaki, Transform taiyakiParent)
    {
        var taiyakiObject = (Instantiate(taiyaki, taiyakiParent));
        
        taiyakiObject.name = "Taiyaki";


        //FillRaw(taiyakiObject.transform);

        //PlaySFX

        //if(Finished){PlaySFX}
    }
    




    public void Interact(string name, Taiyaki taiyaki, Transform equipment)
    {
        if (name == "Handle" && CheckEquipment(equipment, ""))
        {
            
        }

        else if (name == "Tray" && CheckEquipment(equipment, "Batter"))
        {
            //FillRaw(taiyaki.transform);
        }
    }


    public bool CheckEquipment(Transform equipment, string name)
    {
        if (equipment.name == name)
        {
            return true;
        }

        return false;
    }

    public void CheckPan()
    {
        for (int i = 0; i < _leftTaiyakiMakerPan.taiyakiMakerTrays.Length; i++)
        {
            if (!_leftTaiyakiMakerPan.taiyakiMakerTrays[i].IsEmpty() && !_rightTaiyakiMakerPan.taiyakiMakerTrays[i].IsEmpty())
            {
                
            }
        }
        
    }



    public void Combine(GameObject leftTaiyaki, GameObject rightTaiyaki)
    {
        var combined = new GameObject("Taiyaki");
        leftTaiyaki.transform.SetParent(combined.transform, true);
        rightTaiyaki.transform.SetParent(combined.transform, true);

    }
}
