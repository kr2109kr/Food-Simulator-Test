using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace KomorebiKitchen.Environment
{
    public class Radio : MonoBehaviour
    {
        AudioManager _audioManager;
        [SerializeField] private StudioEventEmitter _emitter;
        [SerializeField] private EventReference[] _eventReference;

        EventInstance _musicEvent;
        
        private void Awake()
        {
            
        }

        private void Start()
        {
            _musicEvent = AudioManager.Instance.CreateEventInstance(_eventReference[0]);
            _musicEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            _musicEvent.start();
        }
    }
}