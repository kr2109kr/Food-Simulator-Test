using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace KomorebiKitchen.Environment
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform _door;
        [SerializeField] private Vector3 _doorClosedPos;
        [SerializeField] private Vector3 _doorOpenPos;
        [SerializeField] private float _doorSpeed;


        [SerializeField] private Transform _insidePos;

        [field: SerializeField] public Vector3 OutsidePos { get; set; }
        [SerializeField] private Vector3 FootPathOffset;

        public Vector3 WaitOutsidePos
        {
            get { return transform.position + OutsidePos; }
        }

        public Vector3 WaitOnFootPath
        {
            get { return transform.position + FootPathOffset; }
        }


        private void Awake()
        {
            _door = GetComponent<Transform>();
        }

        public void OpenDoor()
        {
            _door.DORotate(new Vector3(0f, -90f, 0f), 3f);
        }

        public void Close()
        {
            _door.DORotate(new Vector3(0f, 0f, 0f), 3f);
        }

        private IEnumerator Open()
        {
            while (true)
            {
                transform.Rotate(0, 1, 0);
                yield return null;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(WaitOutsidePos, 0.5f);
            Gizmos.DrawSphere(WaitOnFootPath, 0.5f);
        }
    }
}