using System.Collections;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _targetPos;
    [SerializeField] private float _targetX;
    [SerializeField] private float _speed;
    [SerializeField] private float _delayBeforeLoop;

    private void Start()
    {
        _startPos = transform.position;
        _targetPos = new Vector3(_targetX, transform.position.y, transform.position.z);
        StartCoroutine(Move(0f));
    }

    private IEnumerator Move(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {

            float step = _speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.position, _targetPos, step);

            if (Vector3.Distance(transform.position, _targetPos) < 0.001f)
            {
                // Reset the target position to the original object position.
                //EndPos *= -1.0f;
                transform.position = _startPos;
                yield return Move(_delayBeforeLoop);
            }

            yield return null;
        }
    }
}
