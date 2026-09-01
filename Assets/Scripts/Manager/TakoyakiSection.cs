using UnityEngine;

namespace KomorebiKitchen
{
    public class TakoyakiSection : Section
    {
        [SerializeField] private GameObject _octopus;
        [SerializeField] private GameObject _shrimp;
        [SerializeField] private GameObject _bacon;

        private bool _isOctopusLocked;
        private bool _isShrimpLocked;
        private bool _isBaconLocked;

        public bool IsOctopusLocked
        {
            get { return _isOctopusLocked; }
            set { _isOctopusLocked = value; _octopus.SetActive(!value); }
        }

        public bool IsShrimpLocked
        {
            get { return _isShrimpLocked; }
            set { _isShrimpLocked = value; _shrimp.SetActive(!value); }
        }

        public bool IsBaconLocked
        {
            get { return _isBaconLocked; }
            set { _isBaconLocked = value; _bacon.SetActive(!value); }
        }
    }
}