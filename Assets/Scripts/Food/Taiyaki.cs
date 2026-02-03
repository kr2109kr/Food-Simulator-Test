using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Taiyaki : MonoBehaviour
{
    [field: SerializeField] public Food.Taiyaki.Filling _taiyakiFilling { get; private set; }
    [SerializeField] private Color _color;
    [SerializeField] private State _state;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        StartCoroutine(CookTimer());
    }

    private enum State
    {
        Uncooked,
        Done,
        Overcooked
    }

    private void Update()
    {
        if (_state == State.Overcooked)
        {
            _meshRenderer.material.color = _color;
        }
    }

    public void Cook()
    {

    }

    private IEnumerator CookTimer()
    {
        float timer = 0;
        float duration = 5f;

        //yield return new WaitForSeconds(5f);
        while (timer < duration)
        {
            if (PickUp())
            {
                yield break;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        _state = State.Overcooked;
    }

    private bool PickUp()
    {
        if (Keyboard.current.xKey.isPressed)
        {
            return true;
        }
        else return false;
    }
}
