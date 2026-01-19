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

    [SerializeField] private Taiyaki _taiyaki;

    private void Start()
    {
        //StartCoroutine(CountdownTimer(_waitTimeSeconds));
        Order();
    }

    private IEnumerator CountdownTimer(float seconds)
    {
        float max = seconds;

        while (seconds > 0)
        {
            _customerUI.test = (seconds / max) * 100;
            seconds -= Time.deltaTime;
            yield return null;
        }
        Debug.Log("หมดเวลา" + seconds);
    }


    private void Order()
    {
        int random =Random.Range(0, _taiyaki.datas.Length);
        //_customerUI.UpdateUI(_taiyaki.datas[random].sprite);
        Debug.Log("Order : " + _taiyaki.datas[random].name);
    }
}
