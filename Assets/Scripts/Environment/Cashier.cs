using UnityEngine;

public class Cashier : MonoBehaviour
{
    [SerializeField] public Vector3 _waitOffset;

    public Vector3 WaitPos
    {
        get { return transform.position + _waitOffset; }
        set { _waitOffset = value; }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position + _waitOffset, 0.5f);
    }
}
