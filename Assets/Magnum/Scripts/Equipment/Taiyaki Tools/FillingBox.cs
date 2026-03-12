using UnityEngine;

public class FillingBox : MonoBehaviour
{
    //[RequireComponent]
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {

    }

}
