using System;
using Unity.Properties;
using UnityEngine;

namespace KomorebiKitchen
{
    public class AmeSection : Section
    {
        [SerializeField] private GameObject _grape;
        [SerializeField] private GameObject _strawberry;
        [SerializeField] private GameObject _orange;

        private bool _isGrapedLocked;
        private bool _isOrangeLocked;
        private bool _isStrawberryLocked;

        public bool IsGrapeLocked
        {
            get { return _isGrapedLocked; }
            set { _isGrapedLocked = value; _grape.SetActive(!value); }
        }

        public bool IsOrangeLocked
        {
            get { return _isOrangeLocked; }
            set { _isOrangeLocked = value; _orange.SetActive(!value); }
        }

        public bool IsStrawberryLocked
        {
            get { return _isStrawberryLocked; }
            set { _isStrawberryLocked = value; _strawberry.SetActive(!value); }
        }
    }
}