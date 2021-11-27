using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    public Text coinDisplayText;

    public int currentCoin = 0;

    public int winCoins = 100;

    void Start() {
        currentCoin = 0;

        if(PlayerPrefs.HasKey("Coins")){
            currentCoin = PlayerPrefs.GetInt("Coins");
            PlayerPrefs.SetInt("Coins", currentCoin);
        }
        coinDisplayText.text = ": " + currentCoin;
    }

    public void CoinUpdate(){
        currentCoin = currentCoin + winCoins;
        coinDisplayText.text = ": " + currentCoin;
        PlayerPrefs.SetInt("Coins", currentCoin);
    }

    void Update() {
        currentCoin = PlayerPrefs.GetInt("Coins"); 
    }

    public void CoinMin(){
        currentCoin = currentCoin - 500;
        coinDisplayText.text = ": " + currentCoin;
        PlayerPrefs.SetInt("Coins", currentCoin);
    }

    public void HintBuy(){
        currentCoin = currentCoin - 100;
        coinDisplayText.text = ": " + currentCoin;
        PlayerPrefs.SetInt("Coins", currentCoin);
    }

    public void CoinReset(){
        currentCoin = 0;
        coinDisplayText.text = ": " + currentCoin;
        PlayerPrefs.SetInt("Coins", currentCoin);
    }

     public void CoinCheat(){
        currentCoin = 5000;
        coinDisplayText.text = ": " + currentCoin;
        PlayerPrefs.SetInt("Coins", currentCoin);
    }
    // Start is called before the first frame update
}
