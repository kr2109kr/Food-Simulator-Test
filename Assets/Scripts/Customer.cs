using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Customer : MonoBehaviour
{
    [SerializeField] private float _waitTimeSeconds;
    [SerializeField] private float _delayBeforeNewOrder;

    [SerializeField, TextArea] private string Debug_String;

    [SerializeField] private CustomerUI _customerUI;

    [SerializeField] private string order;

    [SerializeField] private TaiyakiSO _taiyaki;

    private Food.Taiyaki.Filling _taiyakiFilling;

    private MeshRenderer _meshRenderer;
    private Color _defaultColor;

    [Header("Sprite")]
    [SerializeField] private Sprite[] _sprites;


    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material.color;
    }

    private void Start()
    {
        StartCoroutine(CountdownTimer(_waitTimeSeconds));
    }

    

    private IEnumerator CountdownTimer(float seconds)
    {
        ChangeColor(_defaultColor);
        float max = seconds;

        Order();

        while (seconds > 0)
        {
            //_customerUI.test = (seconds / max) * 100;
            
            seconds -= Time.deltaTime;
            yield return null;
        }

        yield return CountdownTimer(max);
    }

    private void Order()
    {
        _taiyakiFilling = Food.Taiyaki.RandomFilling();
        //Debug.Log(gameObject.name + "order" + _taiyakiFilling);

        //int random_0 = Random.Range(0, _taiyaki.datas.Length);

        if (name == "Customer-0")
        {
            switch (_taiyakiFilling)
            {
                case Food.Taiyaki.Filling.RedBeans:
                    _customerUI.UpdateUI_0(_customerUI.iconSprite_RedBeans);
                    break;
                case Food.Taiyaki.Filling.Custart:
                    _customerUI.UpdateUI_0(_customerUI.iconSprite_Custard);
                    break;
                case Food.Taiyaki.Filling.Chocolate:
                    _customerUI.UpdateUI_0(_customerUI.iconSprite_Chocolate);
                    break;

            }
        }

        else if (name == "Customer-1")
        {
            switch (_taiyakiFilling)
            {
                case Food.Taiyaki.Filling.RedBeans:
                    _customerUI.UpdateUI_1(_customerUI.iconSprite_RedBeans);
                    break;
                case Food.Taiyaki.Filling.Custart:
                    _customerUI.UpdateUI_1(_customerUI.iconSprite_Custard);
                    break;
                case Food.Taiyaki.Filling.Chocolate:
                    _customerUI.UpdateUI_1(_customerUI.iconSprite_Chocolate);
                    break;

            }
        }

        else if (name == "Customer-2")
        {
            switch (_taiyakiFilling)
            {
                case Food.Taiyaki.Filling.RedBeans:
                    _customerUI.UpdateUI_2(_customerUI.iconSprite_RedBeans);
                    break;
                case Food.Taiyaki.Filling.Custart:
                    _customerUI.UpdateUI_2(_customerUI.iconSprite_Custard);
                    break;
                case Food.Taiyaki.Filling.Chocolate:
                    _customerUI.UpdateUI_2(_customerUI.iconSprite_Chocolate);
                    break;

            }
        }

        else
        {
            Debug.Log("Error");
        }

        //int random_0 = Random.Range(0, _taiyaki.datas.Length);
        //_customerUI.UpdateUI_0(_taiyaki.datas[random_0].sprite);
        //Debug.Log("Order : " + _taiyaki.datas[random].name);

    }

    public void CheckOrder(Food.Taiyaki.Filling filling)
    {
        Debug.Log("Customer " + _taiyakiFilling + filling);
        if (_taiyakiFilling == filling)
        {
            ChangeColor(Color.green);
        }
        else if (_taiyakiFilling != filling)
        {
            ChangeColor(Color.red);
        }
    }

    private void ChangeColor(Color color)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
    }
}
