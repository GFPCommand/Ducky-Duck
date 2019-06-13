using UnityEngine.UI;
using UnityEngine;

public class updatePresent : MonoBehaviour
{

    public Text present;
    private int presentCount;

    void Update()
    {
        presentCount = PlayerPrefs.GetInt("Present");
        present.text = presentCount.ToString();
    }
}
