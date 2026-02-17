using System;
using System.Collections;
using UnityEngine;

public interface IInteractor
{
    void Interact(Transform transform);

}

public class TaiyakiMaker : MonoBehaviour
{
    [SerializeField] private Transform _taiyakiMakerTray;

    [SerializeField] private Vector3 _target;

    [SerializeField] private Transform _rightPan;




    private void Start()
    {
        
    }

    private void Update()
    {
        //FillRawTaiyaki(raw_taiyaki_0);
        //FillRawTaiyaki(raw_taiyaki_1);
        //FillRawTaiyaki(raw_taiyaki_2);
        //FillRawTaiyaki(raw_taiyaki_3);
        //FillRawTaiyaki(raw_taiyaki_4);

        
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

    public void OnRawTaiyakiClick(Collision collision)
    {
        
    }

    

    public interface IInteractor
    {
        void Interact();
    }

    public void Interact(string name)
    {
        if (name == "Handle")
        {
            FlipPan();
        }
    }

    public void Interact(string name, Taiyaki taiyaki, Transform equipment)
    {
        if (name == "Handle")
        {
            FlipPan();
        }

        else if (name == "Tray" && CheckEquipment(equipment, "Batter"))
        {
            FillRaw(taiyaki.transform);
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


    public void FlipPan()
    {
        _rightPan.Rotate(new Vector3(0, 0, 180));
    }

    public bool IsFlipPanEnable()
    {
        return true;
    }
}
