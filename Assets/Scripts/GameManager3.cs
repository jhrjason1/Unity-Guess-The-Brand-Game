using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public string nextLevel3 = "Level 02";
    public int levelToReach3 = 2;
    // Start is called before the first frame update

    public void WinLevel3()
    {
        if(PlayerPrefs.GetInt("levelTiga") < levelToReach3){
                PlayerPrefs.SetInt("levelTiga", levelToReach3);
        }
    }
}