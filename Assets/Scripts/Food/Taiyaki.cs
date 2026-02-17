using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Taiyaki : MonoBehaviour
{
    private UnityEvent<Collider> OnColliderEnterEvent;
    [SerializeField] private TaiyakiMaker _taiyakiMaker;

    private UnityEvent<Transform> InteractEvent;

    [Header("DonessChangeTime")]
    [SerializeField] private float CookedStateTime;
    [SerializeField] private float OvercookedStateTime;

    

    [SerializeField] private TaiyakiSO _taiyakiSO;

    [SerializeField] private Data _data;







    [Serializable]
    private class Data
    {
        public Color undercookColor;
        public Color excellentColor;
        public Color overcookedColor;

        public enum State
        {
            Undercooked,
            Excellent,
            Overcooked
        }

        public Color GetColor(State state)
        {
            switch (state)
            {
                case State.Undercooked: return undercookColor;

                case State.Excellent: return excellentColor;

                case State.Overcooked: return overcookedColor;

                default: return Color.grey;
            }
        }
    }




    public void StartCooking()
    {
        

    }

    public void Interact()
    {
        //_taiyakiMaker.FillRaw(transform);
    }

    public void StartTimer()
    {
    }

    private void Start()
    {
        
    }

    public IEnumerator Timer(float seconds)
    {
        float timer = 0;
        float duration = 5f;

        foreach (Data.State state in Enum.GetValues(typeof(Data.State)))
        {
            ChangeColor(_data.GetColor(state));
            while (timer < duration)
            {
                //if (PickUp()){yield break;}

                timer += Time.deltaTime;
                yield return null;
            }
            
            timer = 0;
            
        }
    }

    private void NextState()
    {
        
    }

    public void Combine()
    {
        //Combine 2 Side of Taiyaki;
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
