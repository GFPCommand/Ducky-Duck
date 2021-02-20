using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class PurchaseSource : MonoBehaviour
{
    private int coins;
    public Text coinsText;

    public void OnPurchaseComplete(Product product)
    {
        coins = PlayerPrefs.GetInt("Coins");
        if (product.definition.id == "coins_75")
        {
            coins += 75;
            Result();
        } else if (product.definition.id == "coins_120")
        {
            coins += 120;
            Result();
        } else if (product.definition.id == "coins_200")
        {
            coins += 200;
            Result();
        } else if (product.definition.id == "no_ads")
        {

        }
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of product " + product.definition.id + "failed because " + reason);
    }

    private void Result()
    {
        PlayerPrefs.SetInt("Coins", coins);
        coinsText.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
