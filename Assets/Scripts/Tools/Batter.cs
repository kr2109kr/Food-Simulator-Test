using UnityEngine;

public class Batter : MonoBehaviour
{
    private void Update()
    {
        Ray ray = new(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Found");
            
        }
    }
    public void Use()
    {
        Ray ray = new(transform.position, Vector3.down);
    }

    public void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }
}
