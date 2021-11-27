using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2Selection : MonoBehaviour
{
    public Button[] lvlButtons;
    // Start is called before the first frame update
    void Start()
    {
        int levelNow = PlayerPrefs.GetInt("levelSekarang", 1);

        for(int i=0; i < lvlButtons.Length; i++){
            if(i + 1 > levelNow)
                lvlButtons[i].interactable = false;
        }
    }
}
