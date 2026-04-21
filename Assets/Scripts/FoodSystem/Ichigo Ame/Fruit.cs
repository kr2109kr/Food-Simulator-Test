using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject _sugarCoating;
    private Animator _animator;
    private AnimatorControllerParameter _controllerParameter;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _sugarCoating.SetActive(false);
    }

    public void SugarCoat()
    {
        _sugarCoating.SetActive(true);
        _animator.SetTrigger("Sugar");
    }
}
