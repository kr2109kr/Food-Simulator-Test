using System.Collections;
using UnityEngine;

public class SideTaiyaki : MonoBehaviour
{
    [SerializeField] private TaiyakiData _taiyakiSO;

    private MeshRenderer _meshRenderer;

    private bool isPauseCooking;
    [SerializeField] private Material[] _materialsForChange;

    public TaiyakiData _dataForCheck = new TaiyakiData();

    private void Start()
    {
        //StartCoroutine(CookingTimer(15f));
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeMaterial(Material material)
    {
        _meshRenderer.material = material;
    }


    public void StartCooking()
    {
        //StartCoroutine(CookingTimer(5f));
    }

    public IEnumerator CookingTimer(float seconds)
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

                    ChangeMaterial(material);

                }

                timer = 0;
            }
        }
    }
}
