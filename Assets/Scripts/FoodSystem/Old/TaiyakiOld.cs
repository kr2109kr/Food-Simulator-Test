using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace FoodSystem
{
    public class TaiyakiOld : MonoBehaviour
    {
        private UnityEvent<Collider> OnColliderEnterEvent;

        private UnityEvent<Transform> InteractEvent;

        [Header("DonessChangeTime")]
        [SerializeField] private float CookedStateTime;
        [SerializeField] private float OvercookedStateTime;



        [SerializeField] private Data _data;

        public bool isPause;

        private TaiyakiDataOLD taiyakiData = new();



        [Serializable]
        private class Data
        {
            public Color undercookColor;
            public Color excellentColor;
            public Color overcookedColor;

            public Side side;

            public enum State
            {
                Undercooked,
                Excellent,
                Overcooked
            }

            public enum Side
            {
                Left,
                Right
            }

            public Color GetColor(State state)
            {   
                switch (state)
                {
                    case State.Undercooked: return undercookColor;

                    case State.Excellent: return excellentColor;

                    //case State.Overcooked: return overcookedColor;

                    default: return Color.grey;
                }
            }
        }

        public void SetFilling(TaiyakiDataOLD.Filling filling)
        {
            taiyakiData.FillingType = filling;
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
            StartCoroutine(Timer(5));
        }

        private void Start()
        {
            
        }

        public IEnumerator Timer(float seconds)
        {
            float timer = 0;
            float duration = 15f;

            foreach (Data.State state in Enum.GetValues(typeof(Data.State)))
            {
                ChangeColor(_data.GetColor(state));

                while (timer < duration)
                {
                    //if (PickUp()){yield break;}
                    if (!isPause)
                    {
                        timer += Time.deltaTime;
                    }
                    yield return null;
                }

                timer = 0;
            }
        }

        public void Pause()
        {
            isPause = true;
        }

        public void UnPause()
        {
            isPause = false;
        }

        private void NextState()
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
}