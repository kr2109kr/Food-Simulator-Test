using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaiyakiMakerPan : MonoBehaviour, IInteractor
{
    [field: SerializeField] public TaiyakiMakerTray[] taiyakiMakerTrays { get; private set; }
    [SerializeField] private TaiyakiMaker _taiyakiMaker;
    [SerializeField] private TaiyakiMakerPan _otherTaiyakiMakerPan;
    private bool isClosed = false;

    private GameObject combinedTaiyaki;

    [SerializeField] private GameObject taiyaki;

    public void Flip()
    {
        isClosed = !isClosed;

        transform.Rotate(new Vector3(0, 0, 180));


    }

    public void Interact(Transform transform)
    {
        Flip();

        if (isClosed)
        {
            for (int i = 0; i < taiyakiMakerTrays.Length; i++)
            {
                CheckBothTray(i);
            }
        }
    }

    private void CheckBothTray(int index)
    {
        if (CheckTray(index) && CheckOtherTray(index))
        {
            Combine(index);
        }

        else if (taiyakiMakerTrays[index].combinedTaiyaki != null)
        {
            Switch(index);
        }
    }

    private bool CheckTray(int index)
    {
        if (!taiyakiMakerTrays[index].IsEmpty()) { return true; }

        else { return false; }
    }

    private bool CheckOtherTray(int index)
    {
        if (_otherTaiyakiMakerPan.CheckTray(index)) { return true; }
        else { return false; }
    }

    private void Combine(int index)
    {
        combinedTaiyaki = new GameObject("Taiyaki");
        combinedTaiyaki.transform.SetParent(_otherTaiyakiMakerPan.taiyakiMakerTrays[index].transform);

        taiyakiMakerTrays[index].TaiyakiGameObject.transform.SetParent(combinedTaiyaki.transform);
        _otherTaiyakiMakerPan.taiyakiMakerTrays[index].TaiyakiGameObject.transform.SetParent(combinedTaiyaki.transform);

        taiyakiMakerTrays[index].IsAvaliable = false;
        _otherTaiyakiMakerPan.taiyakiMakerTrays[index].IsAvaliable = false;

        taiyakiMakerTrays[index].combinedTaiyaki = combinedTaiyaki;
        _otherTaiyakiMakerPan.taiyakiMakerTrays[index].combinedTaiyaki = combinedTaiyaki;


        Switch(index);
    }

    private void Switch(int index)
    {
        taiyakiMakerTrays[index].combinedTaiyaki.transform.SetParent(_otherTaiyakiMakerPan.taiyakiMakerTrays[index].transform);
    }
}
