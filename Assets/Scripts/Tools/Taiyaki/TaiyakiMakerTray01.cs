using UnityEngine;

public class TaiyakiMakerTray01 : MonoBehaviour, IInteractor
{
    [SerializeField] private TaiyakiMaker _taiyakiMaker;
    private string part = "Tray";

    public void Interact(Transform equipment)
    {
        _taiyakiMaker.Interact(part, GetComponent<Taiyaki>(), equipment);
    }


}
