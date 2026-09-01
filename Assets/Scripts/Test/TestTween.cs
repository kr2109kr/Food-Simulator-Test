using UnityEngine;
using DG.Tweening;

public class TestTween : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Transform _cube;
    void Start()
    {
        _cube.DOMoveX(20, 3).SetLoops(-1, LoopType.Yoyo);
    }
}
