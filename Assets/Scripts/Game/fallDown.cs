using UnityEngine;

public class fallDown : MonoBehaviour
{
    private float fallSpeed = 5f;

    void Update()
    {
        if (transform.position.y <= -6f) Destroy(gameObject);

        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }
}
