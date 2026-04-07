using FMOD.Studio;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private EventInstance _musicInstance { get; set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in The Scene");
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        InitializeMusic();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    private void InitializeMusic()
    {
        _musicInstance = CreateEventInstance(FMODEvents.Instance.Music);
        _musicInstance.start();
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        return RuntimeManager.CreateInstance(eventReference);
    }
}
