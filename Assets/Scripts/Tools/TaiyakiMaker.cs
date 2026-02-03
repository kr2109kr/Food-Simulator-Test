using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Rendering;
using System.Collections;

public class TaiyakiMaker : MonoBehaviour
{
    [SerializeField] private Transform raw_taiyaki_0;
    [SerializeField] private Transform raw_taiyaki_1;
    [SerializeField] private Transform raw_taiyaki_2;
    [SerializeField] private Transform raw_taiyaki_3;
    [SerializeField] private Transform raw_taiyaki_4;

    [SerializeField] private Vector3 _target;


    private void Start()
    {
        //FillRaw(raw_taiyaki_0);
    }

    private void Update()
    {
        //FillRawTaiyaki(raw_taiyaki_0);
        //FillRawTaiyaki(raw_taiyaki_1);
        //FillRawTaiyaki(raw_taiyaki_2);
        //FillRawTaiyaki(raw_taiyaki_3);
        //FillRawTaiyaki(raw_taiyaki_4);


    }

    public void FillRaw(Transform rawTaiyaki)
    {
        StartCoroutine(FillRaw(rawTaiyaki));

        IEnumerator FillRaw(Transform rawTaiyaki)
        {
            float step = 0.02f * Time.fixedDeltaTime;
            Vector3 target = new Vector3(rawTaiyaki.localPosition.x, _target.y, rawTaiyaki.localPosition.z);


            while (rawTaiyaki.localPosition.y != target.y)
            {
                rawTaiyaki.localPosition = Vector3.MoveTowards(rawTaiyaki.transform.localPosition, target, step);
                yield return null;
            }
        }
    }

    

    public void OnRawTaiyakiClick(Collision collision)
    {
        Debug.Log("Okay");
    }


}
