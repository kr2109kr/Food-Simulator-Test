using UnityEngine;

public class BowlManager : MonoBehaviour
{
    public GameObject bowlPrefab;
    private void Update()
    {
        if (transform.childCount <= 0)
        {
            Instantiate(bowlPrefab, transform);
        }
    }
}
