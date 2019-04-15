using UnityEngine;

public class winlose : MonoBehaviour
{
    public GameObject win, lose;

    private void Start()
    {
        if (lvlsPlayer.lose == true && lvlsPlayer.win == false)
        {
            lose.SetActive(true);
            win.SetActive(false);
        } else if (lvlsPlayer.lose == false && lvlsPlayer.win == true)
        {
            lose.SetActive(false);
            win.SetActive(true);
        }
    }
}
