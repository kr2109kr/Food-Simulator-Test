using UnityEngine;

public class TaiyakiMakerPan : MonoBehaviour, IInteractor
{
    [SerializeField] private TaiyakiMakerTray[] _trays;
    [SerializeField] private TaiyakiMaker _taiyakiMaker;
    public bool IsClosed { get; set; }

    [SerializeField] private GameObject taiyaki;

    private Taiyaki _taiyaki;

    [field: SerializeField] public Side SideOfPan { get; private set; }

    [SerializeField] private Equipment _requiredEquipment;
    

    public enum Side
    {
        Left,
        Right
    }


    public void Interact(Equipment playerEquipment)
    {

        if (playerEquipment is null)
        {
            Close();
        }

        
        if (IsClosed)
        {
            _taiyakiMaker.StartCombine(this);
        }
    }

    public void Close()
    {
        IsClosed = !IsClosed;

        transform.Rotate(new Vector3(0, 0, 180));
    }

    public int GetTraysLength()
    {
        return _trays.Length;
    }


    public void CreateCombinedAtTray(int indexOfTray)
    {
        GetAnotherPan()._trays[indexOfTray].CreateCombinedTaiyaki();
        GetAnotherPan()._trays[indexOfTray].SetCombinedTaiyaki(GetTaiyaki(indexOfTray));
    }


    //
    public void Switch(int index)
    {
        if (_trays[index].combinedTaiyaki != null)
        {
            _trays[index].combinedTaiyaki.transform.SetParent(GetAnotherPan()._trays[index].transform);
            
            GetAnotherPan()._trays[index].RecieveCombinedTaiyaki(_trays[index].combinedTaiyaki);
            _trays[index].RemoveToOtherTray();
        }
        else
        {
            GetAnotherPan()._trays[index].combinedTaiyaki.transform.SetParent(_trays[index].transform);
            GetAnotherPan()._trays[index].RemoveToOtherTray();

            _trays[index].RecieveCombinedTaiyaki(GetAnotherPan()._trays[index].combinedTaiyaki);
            GetAnotherPan()._trays[index].RemoveToOtherTray();
        }
    }
    //




    public TaiyakiMakerPan GetAnotherPan()
    {
        if (SideOfPan == Side.Left)
        {
            return _taiyakiMaker._rightPan;
        }

        else if (SideOfPan == Side.Right)
        {
            return _taiyakiMaker._leftPan;
        }

        else return null;
    }


    public TaiyakiMakerTray GetTrays(int indexOfTray)
    {
        return _trays[indexOfTray];
    }


    public Taiyaki GetTaiyaki(int index)
    {
        return _trays[index].TaiyakiGameObject.GetComponent<Taiyaki>();
    }

    private void GetCombinedTaiyaki()
    {
        return;
    }

    

    /// <summary>
    /// //
    /// </summary>
    /// <param name="index"></param>

    public bool IsTrayNotEmpty(int index)
    {
        return (_trays[index].IsNotEmpty());
    }

    public bool DoesTrayHasCombined(int index)
    {
        return (_trays[index].combinedTaiyaki);
    }
}
