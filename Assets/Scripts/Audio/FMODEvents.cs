using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    public static FMODEvents Instance { get; private set; }

    [field: SerializeField] public EventReference Clicked { get; private set; }


    [field: Header("Game Manager SFX")]
    [field: SerializeField] public EventReference AddMoney { get; private set; }


    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference FootSteps { get; private set; }
    [field: SerializeField] public EventReference Interact { get; private set; }
    [field: SerializeField] public EventReference Equip { get; private set; }
    [field: SerializeField] public EventReference UnEquip { get; private set; }

    [field: Header("Ichigo Ame SFX")]
    [field: SerializeField] public EventReference AddFruit { get; private set; }


    [Header("Music")]
    [field: SerializeField] public EventReference Music { get; private set; }


    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one FMODEVENTS in The Scene");
        }
        else
        {
            Instance = this;
        }
    }
}
