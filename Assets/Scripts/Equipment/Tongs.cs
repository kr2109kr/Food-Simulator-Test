using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tongs : Equipment
{
    [SerializeField] private Animator _animator;
    public GameObject FoodObject { get; set; }

    public override void Interact(Player player)
    {
        base.Interact(player);
    }

    public void PickUp(GameObject gameObject)
    {
        
        _animator.SetBool("IsPickUp", true);
        FoodObject = gameObject;
        FoodObject.transform.SetParent(transform);
        StartCoroutine(Delay(0.5f, () => { FoodObject.transform.localPosition = Vector3.zero; FoodObject.transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, 0, transform.eulerAngles.z); }));
        
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
