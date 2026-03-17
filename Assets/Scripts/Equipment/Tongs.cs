using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tongs : Equipment
{
    [SerializeField] private Animator _animator;
    public GameObject TaiyakiObject { get; set; }

    public void PickUp(GameObject taiyakiObject)
    {
        
        _animator.SetBool("IsPickUp", true);
        TaiyakiObject = taiyakiObject;
        TaiyakiObject.transform.SetParent(transform);
        StartCoroutine(Delay(0.5f, () => { TaiyakiObject.transform.localPosition = Vector3.zero; TaiyakiObject.transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, 0, transform.eulerAngles.z); }));
        
    }

    public void Open()
    {
        _animator.SetBool("IsPickUp", false);
    }

    private IEnumerator Delay(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }
}
