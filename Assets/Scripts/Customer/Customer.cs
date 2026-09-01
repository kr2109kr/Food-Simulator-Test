using CustomerSystem;
using KomorebiKitchen.Environment;
using UnityEngine;

namespace KomorebiKitchen
{
    public class Customer : MonoBehaviour
    {
        private CustomerMovement _movement;
        private CustomerOrder _order;
        private Door _door;
        private Cashier _cashier;

        [SerializeField] private Transform _target;


        public void Init(Door door, Cashier cashier)
        {
            _door = door;
            _cashier = cashier;
        }



        private void Awake()
        {
            _movement = GetComponent<CustomerMovement>();
            _order = GetComponent<CustomerOrder>();
        }

        private void Start()
        {
            _movement.WalkToTarget(_door.WaitOnFootPath, () =>
            {
                _movement.WalkToTarget(_door.WaitOutsidePos, () =>
                {
                    _movement.WalkToTarget(_cashier.WaitPos, () =>
                    {
                        _order.WaitToOrder();
                        _door.Close();
                    });
                });
            });



            _door.OpenDoor();
            //_movement.WalkToTarget(_cashier.WaitPos);
            //_order.WaitToOrder();





            //_movement.WalkToDoor(_door, () => { OpenDoor(_door); _movement.WalkToCashier(_cashier, () => { _door.Close(); _order.WaitToOrder(); }         );});
            

        }

        private void OpenDoor(Door door)
        {
            door.OpenDoor();
        }
    }
}