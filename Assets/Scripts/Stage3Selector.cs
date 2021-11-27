using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3Selector : MonoBehaviour
{
    public Button[] lvlButtons;
    // Start is called before the first frame update
    void Start()
    {
        int pilihLevel = PlayerPrefs.GetInt("levelTiga", 1);

        for(int i=0; i < lvlButtons.Length; i++){
            if(i + 1 > pilihLevel)
                lvlButtons[i].interactable = false;
        }
    }
}