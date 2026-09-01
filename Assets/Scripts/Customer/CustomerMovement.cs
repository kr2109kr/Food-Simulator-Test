using CustomerSystem;
using DG.Tweening;
using KomorebiKitchen.Environment;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    [Header("Walk Route")]
    

    private Vector3[] _targetsPos;

    [SerializeField] private float _speed;
    private Animator _animator;
    private CustomerOrder _customerOrder;


    //private Vector3[] _path = new Vector3[] { new Vector3(26, 1.95f, 7), new Vector3(-6.957843f, 2, 7), new Vector3(-6.957843f, 2, -7) };

    private void Awake()
    {
        _customerOrder = GetComponent<CustomerOrder>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //Debug.Log(_path[^1]);
        //Debug.Log(_path.Reverse().ToArray()[^1]);
    }

    private void OpenDoor(Door door)
    {
        door.OpenDoor();
    }

    public void WalkToTarget(Vector3 targetPos)
    {
        _animator.SetTrigger("Walk");
        transform.DOMove(targetPos, 15f);
        transform.LookAt(targetPos);
    }

    public void WalkToTarget(Vector3 targetPos, TweenCallback test)
    {
        _animator.SetTrigger("Walk");
        transform.DOMove(targetPos, 15f).OnComplete(test);
        transform.LookAt(targetPos);
    }

    public Tween WalkToDoor(Door door, TweenCallback tweenCallback)
    {
        _animator.SetTrigger("Walk");

        TweenCallback tween = () => 
        {
            _animator.SetTrigger("Idle");
            _animator.SetTrigger("Angry");
            transform.DOLookAt(door.GetComponent<Renderer>().bounds.center, 0f, AxisConstraint.Y);
        };

        tween += tweenCallback;
        return transform.DOMove(door.OutsidePos, 15f).OnComplete(tween);
    }


    public void WalkToCashier(Cashier cashier, TweenCallback tweenCallback)
    {
        transform.DOMove(cashier.WaitPos, 15f).SetOptions(AxisConstraint.Z).OnComplete(tweenCallback);
    }
}
