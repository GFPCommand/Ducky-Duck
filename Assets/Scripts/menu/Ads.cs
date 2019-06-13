using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    public int present;

    public void PresentAd ()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                resultCallback = ResultMoney
            };
            Advertisement.Show("rewardedVideo", options);
        } else
        {
            Debug.Log("Err");
        }
    }

    private void ResultMoney(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                present = PlayerPrefs.GetInt("Present");
                present++;
                PlayerPrefs.SetInt("Present", present);
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad was skipped!");
                break;
            case ShowResult.Failed:
                Debug.Log("Show ad was failed!");
                break;
        }
    }
}