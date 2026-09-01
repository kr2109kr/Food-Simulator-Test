using Unity.Properties;
using UnityEngine;

[CreateAssetMenu(fileName = "IchigoAmeSectionSO", menuName = "Scriptable Objects/IchigoAmeSectionSO")]
public class IchigoAmeSectionSO : ScriptableObject
{
    [field: SerializeField] public bool IsSectionLocked { get; private set; }
    private bool isStrawberryLocked;
    private bool isOrangeLocked;
    private bool isGrapeLocked;
}
