using System.Collections;
using UnityEngine;

public class SideTaiyaki : MonoBehaviour
{
    [SerializeField] private TaiyakiData _taiyakiSO;

    private MeshRenderer _meshRenderer;

    [SerializeField] private GameObject _redBeansFilling;
    [SerializeField] private GameObject _custardFilling;
    [SerializeField] private GameObject _chocolateFilling;

    private bool isPauseCooking;
    [SerializeField] private Material[] _materialsForChange;

    public TaiyakiData.Filling Filling;

    public void ShowRedBeans()
    {
        _redBeansFilling.SetActive(true);
    }

    public void ShowCustard()
    {
        _custardFilling.SetActive(true);
    }

    public void ShowChocolate()
    {
        _chocolateFilling.SetActive(true);
    }

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
