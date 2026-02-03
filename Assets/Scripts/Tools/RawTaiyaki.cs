using UnityEngine;
using UnityEngine.Events;

public class RawTaiyaki : MonoBehaviour
{
    private UnityEvent<Collider> OnColliderEnterEvent;
    [SerializeField] private TaiyakiMaker _taiyakiMaker;

    private UnityEvent<Transform> InteractEvent;


    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public void Interact()
    {
        _taiyakiMaker.FillRaw(transform);
    }
}
