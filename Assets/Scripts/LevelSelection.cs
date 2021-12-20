using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public CoinSystem coins;
    public Button[] lvlButtons;
    public Button[] unlockButton1;
    public Button[] unlockButton2;
    public GameObject NotificationPanel;
    public GameObject NotificationPanel2;
    public int lockbutton = 1;
    public int level = 1;
    public AudioSource error;
    public AudioSource unlock;
    // Start is called before the first frame update
    void Start()
    {

        int level = PlayerPrefs.GetInt("levelAt");
        PlayerPrefs.SetInt("levelAt", level);
        //int unlock = PlayerPrefs.GetInt("unlock", 0);

        for(int i=0; i < lvlButtons.Length; i++){
            if(i + 1 > level){
                lvlButtons[i].interactable = false;
            }else{
                lvlButtons[i].interactable = true;
            }
        }

        int lockbutton = PlayerPrefs.GetInt("Lock", 1);
        for(int i=0; i < unlockButton1.Length; i++){
            if(i + 2 > lockbutton){
                unlockButton1[i].interactable = true;
            }else{
                unlockButton1[i].interactable = false;
            }
        }

        for(int i=0; i < unlockButton2.Length; i++){
            if(i + 3 > lockbutton){
                unlockButton2[i].interactable = true;
            }else{
                unlockButton2[i].interactable = false;
            }
        }
        //if(unlock == 1){
            //unlockButton[0].interactable = false;
       // }else{
            //unlockButton[0].interactable = true;
        //}
    }

    void Update() {
        level = PlayerPrefs.GetInt("levelAt"); 
    }

    public void Level2Update(){
        if(PlayerPrefs.GetInt("levelDi") == 5 && PlayerPrefs.GetInt("Coins") >= 500){
            lvlButtons[1].interactable = true;
            unlock.Play();
            coins.CoinMin();
            BaseLevelUp();
        }else{
            NotificationPanel.SetActive(true);
            //error = GetComponent<AudioSource>();
            error.Play();
            //PlayerPrefs.SetInt("unlock", 0);
            unlockButton1[0].interactable = true;
        }
    }

    public void Level3Update(){

        if(PlayerPrefs.GetInt("levelSekarang") == 5 && PlayerPrefs.GetInt("Coins") >= 500){
            lvlButtons[2].interactable = true;
            unlock.Play();
            coins.CoinMin();
            lockbutton = lockbutton + 1;
            BaseLevelUp();
        }else{
            NotificationPanel2.SetActive(true);
            //error = GetComponent<AudioSource>();
            error.Play();
            //PlayerPrefs.SetInt("unlock", 0);
            unlockButton2[0].interactable = true;
        }
    }

   public void BaseLevelUp(){
        level = level + 1;
        lockbutton = lockbutton + 1;
        PlayerPrefs.SetInt("levelAt", level);
        PlayerPrefs.SetInt("Lock", lockbutton);
   }
}
