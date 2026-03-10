using UnityEngine;
using UnityEngine.InputSystem;

public class Batter : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void IsPouring()
    {
        _animator.SetTrigger("IsPouring");
    }
}
