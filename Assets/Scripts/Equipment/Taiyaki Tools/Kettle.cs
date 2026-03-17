using UnityEngine;
using UnityEngine.InputSystem;

public class Kettle : Equipment
{
    [SerializeField] private Animator _animator;

    public void IsPouring()
    {
        _animator.SetTrigger("IsPouring");
    }
}
