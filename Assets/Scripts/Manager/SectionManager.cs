using UnityEngine;

namespace KomorebiKitchen
{
    public class SectionManager : MonoBehaviour
    {
        [SerializeField] private TaiyakiSection _taiyakiSection;
        [SerializeField] private TakoyakiSection _takoyakiSection;
        [SerializeField] private AmeSection _ameSection;
        
        private void Start()
        {
            _taiyakiSection.IsRedBeansLocked = true;
            _taiyakiSection.IsCustardLocked = true;
            _taiyakiSection.IsChocolateLocked = true;

            _takoyakiSection.IsOctopusLocked = true;
            _takoyakiSection.IsShrimpLocked = true;
            _takoyakiSection.IsBaconLocked = true;

            _ameSection.IsGrapeLocked = true;
            _ameSection.IsOrangeLocked = true;
            _ameSection.IsStrawberryLocked = true;
        }

        public void UnlockTaiyakiSection()
        {
            _taiyakiSection.IsLocked = false;
        }

        public void UnlockTakoyakiSection()
        {
            _takoyakiSection.IsLocked = false;
        }

        public void UnlockIchigoAmeSection()
        {
            _ameSection.IsLocked = false;
        }

        public void Unlock()
        {

        }

        public void UnlockRedBeans()
        {
            _taiyakiSection.IsRedBeansLocked = false;
        }

        public void UnlockCustard()
        {
            _taiyakiSection.IsCustardLocked = false;
        }

        public void UnlockChocolate()
        {
            _taiyakiSection.IsChocolateLocked = false;
        }

        public void UnlockStrawberry()
        {
            _ameSection.IsStrawberryLocked = false;
        }

        public void UnlockOrange()
        {
            _ameSection.IsOrangeLocked = false;
        }

        public void UnlockGrape()
        {
            _ameSection.IsGrapeLocked = false;
        }
    }
}