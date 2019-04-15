using UnityEngine;

public class MoveShield : MonoBehaviour
{

    public Transform shield;
    [SerializeField]
    private float speed = 10f;

    void OnMouseDrag()
    {
        if (!Player.lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > 2.5 ? 2.5f : mousePos.x;
            mousePos.x = mousePos.x < -2.5 ? -2.5f : mousePos.x;
            shield.position = Vector2.MoveTowards(shield.position, new Vector2(mousePos.x, shield.position.y), speed * Time.deltaTime);
        }
    }
}
