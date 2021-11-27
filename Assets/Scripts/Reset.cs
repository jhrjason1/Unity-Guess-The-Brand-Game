using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public int BaseLevel = 1;
    public int MaxLevel = 5;
    public int BaseCoin = 0;
    public int BaseUnlock = 0;
    public int MaxUnlock = 1;
    public Button[] unlockButton1;
    public Button[] unlockButton2;
    public CoinSystem coins;
    public Button[] lvlButtons;

    // Start is called before the first frame update
    public void ResetGame(){
        PlayerPrefs.GetInt("levelDi");
        PlayerPrefs.SetInt("levelDi", BaseLevel);
        PlayerPrefs.GetInt("levelSekarang");
        PlayerPrefs.SetInt("levelSekarang", BaseLevel);
        PlayerPrefs.GetInt("levelAt");
        PlayerPrefs.SetInt("levelAt", BaseLevel);
        PlayerPrefs.GetInt("levelTiga");
        PlayerPrefs.SetInt("levelTiga", BaseLevel);
        PlayerPrefs.GetInt("Lock");
        PlayerPrefs.SetInt("Lock", BaseLevel);
        coins.CoinReset();
        //int unlock = PlayerPrefs.GetInt("unlock");
        //PlayerPrefs.SetInt("unlock", BaseUnlock);
        unlockButton1[0].interactable = true;
        unlockButton2[0].interactable = true;
        lvlButtons[1].interactable = false;
        lvlButtons[2].interactable = false;
    }

    public void CheatGame(){
        PlayerPrefs.GetInt("levelDi");
        PlayerPrefs.SetInt("levelDi", MaxLevel);
        PlayerPrefs.GetInt("levelTiga");
        PlayerPrefs.SetInt("levelTiga", MaxLevel);
        PlayerPrefs.GetInt("levelSekarang");
        PlayerPrefs.SetInt("levelSekarang", 5);
        coins.CoinCheat();
        //int unlock = PlayerPrefs.GetInt("unlock");
        //PlayerPrefs.SetInt("unlock", MaxUnlock);
        unlockButton1[0].interactable = false;
        unlockButton2[0].interactable = false;
        lvlButtons[1].interactable = true;
        lvlButtons[2].interactable = true;
    }
}
