using System;
using System.Collections;
using UnityEngine;

public class Equipment : MonoBehaviour, IInteractor
{
    [SerializeField] private Station _station;

    [SerializeField] private Vector3 _offsetPosition;
    private CameraSwitch CameraSwitch;

    [field: SerializeField] public string NameTag { get; private set; }

    
    [field: SerializeField] public Vector3 HoldPostion { get; set; }
    [field: SerializeField] public Vector3 HoldRotation { get; set; }

    [SerializeField] private Transform test;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }


    public virtual void Interact(Player player)
    {
        if (!player.GetEquipment())
        {
            player.Equip(this);
            //_boxCollider.enabled = false;
        }
    }


    public void FollowCursor(Transform cursorPosition)
    {
        //transform.position = 
    }



    public void TransferToStation(Station station)
    {
        transform.SetParent(station.transform);
        transform.localPosition = HoldPostion;
        transform.localRotation = Quaternion.Euler(HoldRotation);
        //transform.localScale = Vector3.one;

        //transform.localPosition = station.GetResetEquipmentPos();
    }

    public Vector3 GetOffsetPosition()
    {
        return _offsetPosition;
    }
    ///
    public bool CheckEquipmentOLD(string name)
    {
        if (NameTag == name)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public bool Check(Type type)
    {
        if (this.GetType() == type)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void SetStation(Station station)
    {
        _station = station;
    }

    protected IEnumerator PlayAnimationAndWait(Animator animator, string name, int layer, Action action)
    {
        IEnumerator WaitForAnimation(Animator animator, string name, int layer)
        {
            while (!animator.IsInTransition(layer))
            {
                yield return null;
            }

            while (animator.IsInTransition(layer))
            {
                yield return null;
            }

            if (animator.GetCurrentAnimatorStateInfo(layer).IsName(name))
            {
                while (animator.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1f)
                {
                    yield return null;
                }
            }

            Debug.Log("Animation has Finished");
        }

        yield return WaitForAnimation(animator, name, layer);
        action();
    }

    
}
