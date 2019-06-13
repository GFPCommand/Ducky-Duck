using UnityEngine;
using UnityEngine.UI;

public class updateDoubleCoin : MonoBehaviour
{
    public Text dc;
    private int dcCount;

    void Update()
    {
        dcCount = PlayerPrefs.GetInt("doubleCoin");
        dc.text = dcCount.ToString();
    }
}
