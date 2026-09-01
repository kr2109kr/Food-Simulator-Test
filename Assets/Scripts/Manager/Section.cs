using UnityEngine;

namespace KomorebiKitchen
{
    public class Section : MonoBehaviour
    {
        [SerializeField] private bool _isLocked;
        [SerializeField] private GameObject _gameObjectSection;

        public bool IsLocked
        {
            get { return _isLocked; }
            set { _isLocked = value; _gameObjectSection.SetActive(!value); }
        }

        private void OnValidate()
        {

        }
    }
}