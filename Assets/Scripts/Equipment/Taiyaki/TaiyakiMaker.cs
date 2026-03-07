using UnityEngine;

public interface IInteractor
{
    void Interact(Equipment playerEquipment);

}

public class TaiyakiMaker : MonoBehaviour
{
    [SerializeField] private Vector3 _target;

    [SerializeField] public TaiyakiMakerPan _leftPan;
    [SerializeField] public TaiyakiMakerPan _rightPan;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="taiyaki"></param>
    /// <param name="taiyakiParent"></param>
    /// 
    



    public bool CheckEquipment(Transform equipment, string name)
    {
        if (equipment.name == name) { return true; }
        else { return false; }
    }

    public void StartCombine(TaiyakiMakerPan pan)
    {
        for (int index= 0; index < _leftPan.GetTraysLength(); index++)
        {
            if (AreBothTraysNotEmpty(index))
            {
                Combine(index, pan);
            }

            else if (DoseAnyTrayHasCombineTaiyaki(index))
            {
                FlipTray(index, pan);
            }
        }
    }

    public bool AreBothTraysNotEmpty(int index)
    {
        return (_leftPan.IsTrayNotEmpty(index) && _rightPan.IsTrayNotEmpty(index));
    }

    private bool DoseAnyTrayHasCombineTaiyaki(int index)
    {
        return (_leftPan.DoesTrayHasCombined(index) || _rightPan.DoesTrayHasCombined(index));
    }

    public void Combine(int index, TaiyakiMakerPan pan)
    {
        pan.CreateCombinedAtTray(index);
    }

    public void FlipTray(int index, TaiyakiMakerPan pan)
    {
        pan.Switch(index);
    }
}
