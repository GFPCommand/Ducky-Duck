using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform player;

    private float speed = 10f;

    void OnMouseDrag()
    {
        if (!Player.lose && !Pause.isPause && !LoadLevels.isLevels)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > 2.1 ? 2.1f : mousePos.x;
            mousePos.x = mousePos.x < -2.1 ? -2.1f : mousePos.x;
            player.position = Vector2.MoveTowards(player.position, new Vector2(mousePos.x, player.position.y), speed * Time.fixedDeltaTime);
        } else if (!PlayerLVL.lose && !Pause.isPause && LoadLevels.isLevels)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > 2.1 ? 2.1f : mousePos.x;
            mousePos.x = mousePos.x < -2.1 ? -2.1f : mousePos.x;
            player.position = Vector2.MoveTowards(player.position, new Vector2(mousePos.x, player.position.y), speed * Time.fixedDeltaTime);
        }
    }
}
