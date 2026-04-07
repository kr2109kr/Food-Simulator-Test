using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using static IchigoAmeData;

public class IchigoAmeCup : Equipment
{
    [SerializeField] private Transform[] _slot = new Transform[3];
    public bool IsFull { get; private set; }

    public override void Interact(Player player)
    {
        //base.Interact(player);

        if (player.GetEquipment() is Stick stick)
        {
            TransferStick(stick);
            player.UnEquip();
        }
    }

    public void TransferStick(Stick stick)
    {
        void TransferObject(int index)
        {
            stick.transform.SetParent(_slot[index], false);
            stick.transform.localPosition = Vector3.zero;
            stick.transform.localRotation = Quaternion.identity;
            stick.transform.localScale = Vector3.one;
        }

        for (int i = 0; i < _slot.Length; i++)
        {
            if (IsSlotEmpty(i))
            {
                TransferObject(i);

                //_animator.SetTrigger(_animator.parameters[i].name);

                Debug.Log("New Stick : " + i + " " + _slot[i]);
                //AudioManager.Instance.PlayOneShot(FMODEvents.Instance.AddFruit, transform.position);
                break;
            }
        }

        if (!IsSlotEmpty(_slot.Length - 1))
        {
            IsFull = true;
            Debug.Log("Full");
        }


    }

    public bool IsSlotEmpty(int index)
    {
        return _slot[index].childCount == 0;
    }
}
