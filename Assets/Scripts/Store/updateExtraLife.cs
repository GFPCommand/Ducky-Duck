using UnityEngine.UI;
using UnityEngine;

public class updateExtraLife : MonoBehaviour
{

    public Text el;
    private int elCount;

    void Update()
    {
        elCount = PlayerPrefs.GetInt("ExtraLife");
        el.text = elCount.ToString();
    }
}
