using UnityEngine;

public class winlose : MonoBehaviour
{
    public GameObject win, lose, next;

    private void Start()
    {
		if ((lvlsPlayer.lose == true && lvlsPlayer.win == false) || (lvlsPlayer.lose == true && lvlsPlayer.win == true))
        {
            lose.SetActive(true);
            win.SetActive(false);
            next.SetActive(false);
        } else if (lvlsPlayer.lose == false && lvlsPlayer.win == true)
        {
            lose.SetActive(false);
            win.SetActive(true);
		}
    }
}
