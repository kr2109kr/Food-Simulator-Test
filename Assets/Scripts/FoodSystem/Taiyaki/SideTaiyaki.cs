using System.Collections;
using UnityEngine;

public class SideTaiyaki : MonoBehaviour
{
    [SerializeField] private TaiyakiData _taiyakiSO;

    private MeshRenderer _meshRenderer;

    private bool isPauseCooking;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        
    }
    public void ChangeMaterial(Material material)
    {
        _meshRenderer.material = material;
    }


    public void StartCooking()
    {
        //StartCoroutine(CookingTimer(15f));
    }

    /*
    public IEnumerator CookingTimer(float seconds)
    {
        float timer = 0;
        float duration = seconds;

        foreach (TaiyakiData.MaterialMapping materialMapping in _taiyakiSO._materialMappings)
        {
            if (!isPauseCooking)
            {
                while (timer < duration)
                {
                    timer += Time.deltaTime;
                    yield return null;

                    ChangeMaterial(materialMapping.material);
                }

                timer = 0;
            }
        }
    }
    */
}
