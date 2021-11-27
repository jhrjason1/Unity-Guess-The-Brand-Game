using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public string nextLevel2 = "Level 02";
    public int levelToReach2 = 2;
    // Start is called before the first frame update

    public void WinLevel2()
    {
        if(PlayerPrefs.GetInt("levelSekarang") < levelToReach2){
                PlayerPrefs.SetInt("levelSekarang", levelToReach2);
        }
    }
}