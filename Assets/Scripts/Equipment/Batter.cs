using UnityEngine;
using UnityEngine.InputSystem;

public class Batter : MonoBehaviour
{

    Vector3 _originalPos;


    private void Start()
    {
        _originalPos = transform.position;
    }

    private void Update()
    {
        Ray ray = new(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //Debug.Log("Found");
        }

        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            BackToOriginPos();
        }
    }
    public void Use()
    {
        Ray ray = new(transform.position, Vector3.down);
    }

    public void BackToOriginPos()
    {
        transform.position = _originalPos;

        
    }

    public void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }
}
