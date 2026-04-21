using UnityEngine;

public class Pot : Equipment
{
    [SerializeField] private Transform _placeholder;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact(Player player)
    {
        if (player.GetEquipment() is Stick stick)
        {

            stick.transform.SetParent(_placeholder);
            stick.transform.localPosition = Vector3.zero;
            stick.transform.localRotation = Quaternion.identity;
            
            
            _animator.SetTrigger("Sugarcoat");
            
            player.IsInteracting = true;
            StartCoroutine(PlayAnimationAndWait(_animator, "Sugarcoat", 0, () => {
                player.Equip(stick);
                stick.SugarCoatFruits();
                player.IsInteracting = false;
            }));
            

            //stick.SugarCoatFruits();
        }

        if (player.GetEquipment() is null)
        {
            Debug.Log("Nooo");
        }
    }
}
