using FoodSystem;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Takoyaki : MonoBehaviour
{
    [SerializeField] private TakoyakiData _takoyakiData;

    

    [SerializeField] private Material[] _materialsForChange;
    private MeshRenderer _meshRenderer;

    private bool isPauseCooking;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }


    private void Start()
    {
        StartTest();
    }

    private void StartTest()
    {
        StartCoroutine(CookingTimer(10f));
        _takoyakiData.filling = TakoyakiData.Filling.Tako;
        _takoyakiData.doness = TakoyakiData.Doness.Burnt;
    }

    public void SetFilling(TakoyakiData.Filling filling)
    {
        _takoyakiData.filling = filling;
    }

    public TakoyakiData.Filling GetFilling()
    {
        return _takoyakiData.filling;
    }

    public void SetDoness()
    {
        _takoyakiData.doness = TakoyakiData.Doness.Uncooked;
    }

    public void SetMaterial(Material material)
    {
        _meshRenderer.material = material;
    }
    
    IEnumerator CookingTimer(float seconds)
    {
        
        float timer = 0;
        float duration = seconds;

        foreach (Material material in _materialsForChange)
        {
            if (!isPauseCooking)
            {
                while (timer < duration)
                {
                    timer += Time.deltaTime;
                    yield return null;

                    SetMaterial(material);
                }
                timer = 0;
            }
        }
    }
    
}
