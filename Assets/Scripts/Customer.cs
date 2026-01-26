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

    [SerializeField] private Food _food;

    private void Start()
    {
        StartCoroutine(CountdownTimer(_waitTimeSeconds));
        
    }

    private void CheckOrder()
    {

    }

    private IEnumerator CountdownTimer(float seconds)
    {
        float max = seconds;
        Order();
        while (seconds > 0)
        {
            _customerUI.test = (seconds / max) * 100;
            seconds -= Time.deltaTime;
            yield return null;
        }

        yield return CountdownTimer(max);
    }

    

    private void Order()
    {
        _food.RandomFood();
        //int random_0 = Random.Range(0, _taiyaki.datas.Length);
        //_customerUI.UpdateUI_0(_taiyaki.datas[random_0].sprite);

        //int random_0 = Random.Range(0, _taiyaki.datas.Length);
        //_customerUI.UpdateUI_0(_taiyaki.datas[random_0].sprite);
        //Debug.Log("Order : " + _taiyaki.datas[random].name);
        
    }
}
