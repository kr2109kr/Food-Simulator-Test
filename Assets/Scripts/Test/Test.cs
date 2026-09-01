using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Test : MonoBehaviour, IInteractor
{
    private MeshRenderer m_MeshRenderer;

    private Material _mat;
    private static readonly int OutlineIntensity = Shader.PropertyToID("_OutlineIntensity");
    private static readonly int Enable = Shader.PropertyToID("Enable");

    void Awake()
    {
        _mat = GetComponent<Renderer>().materials[^1];
        //_mat.SetFloat(OutlineIntensity, 0f); // ปิดก่อน
        _mat.SetFloat(OutlineIntensity, 0f);
    }

    public void SetSelected(bool isSelected)
    {
        //_mat.SetFloat(OutlineIntensity, isSelected ? 1.5f : 0f);
    }
    private void Start()
    {
        
    }


    public void EnableOutline()
    {
        _mat.SetFloat(OutlineIntensity, 1f);
    }
    public void DisableOutline()
    {
        _mat.SetFloat(OutlineIntensity, 0f);
    }

    void IInteractor.Interact(Player player)
    {
        //_mat.SetFloat(OutlineIntensity, 1f);
    }
}
