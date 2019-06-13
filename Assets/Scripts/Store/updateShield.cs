using UnityEngine.UI;
using UnityEngine;

public class updateShield : MonoBehaviour
{

    public Text sc;
    private int scCount;

    void Update()
    {
        scCount = PlayerPrefs.GetInt("Shield");
        sc.text = scCount.ToString();
    }
}
