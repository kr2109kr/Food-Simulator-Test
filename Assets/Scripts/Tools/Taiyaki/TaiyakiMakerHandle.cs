using UnityEngine;

public class TaiyakiMakerHandle : MonoBehaviour
{
    [SerializeField] private TaiyakiMaker _taiyakiMaker;
    private string part = "Handle";

    public void Interact(Transform equipment)
    {
        _taiyakiMaker.Interact(part);
    }
}
