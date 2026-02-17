using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RawTaiyaki : MonoBehaviour
{
    private UnityEvent<Collider> OnColliderEnterEvent;
    [SerializeField] private TaiyakiMaker _taiyakiMaker;

    private UnityEvent<Transform> InteractEvent;

    [Header("DonessChangeTime")]
    [SerializeField] private float CookedStateTime;
    [SerializeField] private float OvercookedStateTime;

    [SerializeField] private Color _color;

    [SerializeField] private TaiyakiSO _taiyakiSO;

    private class Data
    {
        public State state = State.Undercooked;
        public Color color;
        public float cookingTimer = 10f;

        public enum State
        {
            Undercooked,
            Excellent,
            OverCooked
        }
    }
    

    private void Awake()
    {
        StartTimer();
    }

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        StartTimer();
        ChangeColor(_taiyakiSO.overcookedColor);
    }

    public void Interact()
    {
        _taiyakiMaker.FillRaw(transform);
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        float timer = 0;
        float duration = 5f;

        while (timer < duration)
        {
            //if (PickUp()){yield break;}
            timer += Time.deltaTime;
            yield return null;            

        }
    }

    private void ChangeState()
    {

    }

    private void ChangeColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
    }


    private void PlaySFX()
    {

    }

    private bool PickUp()
    {
        if (Keyboard.current.xKey.isPressed)
        {
            return true;
        }
        else return false;
    }

}
