using CustomerSystem;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerWalk : MonoBehaviour
{
    [Header("Walk Route")]
    

    private Vector3[] _targetsPos;
    //private Vector3[] _targetsPos;

    [SerializeField] private float _speed;

    private CustomerManager _customerManager;
    private Animator _animator;
    private CustomerOrder _customerOrder;

    [SerializeField] private Transform test;

    private void Awake()
    {
        _customerManager = GetComponentInParent<CustomerManager>();
        _customerOrder = GetComponent<CustomerOrder>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _targetsPos = _customerManager.TargetsPos;
        _animator.SetTrigger("Walk");
        StartCoroutine(Walk(_customerManager.TargetsPos));
    }

    public void WalkAway()
    {
        StartCoroutine(WalkBack(_targetsPos));
    }


    public IEnumerator WalkBack(Vector3[] targetsPos)
    {
        _animator.SetTrigger("Walk");
        for (int i = _targetsPos.Length - 1; i >= 0; i--)
        {
            Debug.Log(i);
            transform.LookAt(targetsPos[i]);

            while (true)
            {

                float step = _speed * Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetsPos[i], step);

                if (Vector3.Distance(transform.position, targetsPos[i]) < 0.001f)
                {
                    // Reset the target position to the original object position.
                    //EndPos *= -1.0f;
                    //transform.position = _startPos;
                    //transform.rotation *= Quaternion.Euler(0, -90, 0);

                    break;
                }

                yield return null;
            }
        }

        transform.LookAt(_customerManager._spawnPos);
        while (true)
        {

            float step = _speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _customerManager._spawnPos, step);

            if (Vector3.Distance(transform.position, _customerManager._spawnPos) < 0.001f)
            {
                // Reset the target position to the original object position.
                //EndPos *= -1.0f;
                //transform.position = _startPos;
                //transform.rotation *= Quaternion.Euler(0, -90, 0);

                break;
            }

            yield return null;
        }

        Destroy(gameObject);
        _customerManager.CreateCustomer();
    }

    public IEnumerator Walk(Vector3[] targetsPos)
    {
        foreach (Vector3 target in _targetsPos)
        {
            transform.LookAt(target);

            while (true)
            {

                float step = _speed * Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, step);

                if (Vector3.Distance(transform.position, target) < 0.001f)
                {
                    // Reset the target position to the original object position.
                    //EndPos *= -1.0f;
                    //transform.position = _startPos;
                    //transform.rotation *= Quaternion.Euler(0, -90, 0);
                    
                    break;
                }

                yield return null;
            }
        }

        _animator.SetTrigger("Idle");
        _customerOrder.WaitToOrder();
    }

    public IEnumerator Walk(Vector3 targetPos)
    {
        while (true)
        {
            float step = _speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, step);

            if (Vector3.Distance(transform.position, targetPos) < 0.001f)
            {
                // Reset the target position to the original object position.
                //EndPos *= -1.0f;
                //transform.position = _startPos;
                //transform.rotation *= Quaternion.Euler(0, -90, 0);

                break;
            }

            yield return null;
        }
    }
}
