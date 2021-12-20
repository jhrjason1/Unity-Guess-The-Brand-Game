using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;
    public Image image7;
    public Image image8;
    public Image image9;
    public Image image10;
    public Image image11;
    public Image image12;
    public Image image13;
    public Image image14;
    public Image image15;
    public Image image16;
    public Image image17;
    public Image image18;
    public Image image19;
    public Image image20;
    public Image image21;
    public Image image22;
    public Image image23;
    public Image image24;
    public Image image25;
    public CoinSystem coins;
    public GameObject Cointidakcukup;
    public Button[] hintButtons;
    public AudioSource hint;
    public AudioSource error;
    // Start is called before the first frame update
    void Start() {
        image1.enabled = false;    
    }
    // Update is called once per frame
    public void HintClick()
    {
        if(PlayerPrefs.GetInt("Coins") > 0){
            image1.enabled=true;
            image2.enabled=false;
            image3.enabled=false;
            image4.enabled=false;
            image5.gameObject.SetActive(false);
            image6.gameObject.SetActive(false);
            image7.gameObject.SetActive(false);
            image8.gameObject.SetActive(false);
            image9.gameObject.SetActive(false);
            image10.gameObject.SetActive(false);
            image11.gameObject.SetActive(false);
            image12.gameObject.SetActive(false);
            image13.gameObject.SetActive(false);
            image14.gameObject.SetActive(false);
            image15.gameObject.SetActive(false);
            image16.gameObject.SetActive(false);
            image17.gameObject.SetActive(false);
            image18.gameObject.SetActive(false);
            image19.gameObject.SetActive(false);
            image20.gameObject.SetActive(false);
            image21.gameObject.SetActive(false);
            image22.gameObject.SetActive(false);
            image23.gameObject.SetActive(false);
            image24.gameObject.SetActive(false);
            image25.gameObject.SetActive(false);
            coins.HintBuy();
            hint.Play();
            hintButtons[0].interactable = false;
        }else{
            Cointidakcukup.SetActive(true);
            error.Play();
        }       
    }
}
