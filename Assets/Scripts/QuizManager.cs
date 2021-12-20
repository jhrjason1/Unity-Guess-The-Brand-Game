using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{   

    public static QuizManager instance;

    [SerializeField]
    private QuestionData question;

    [SerializeField]
    private Image questionImage;

    [SerializeField]
    public WordData[] answerWordArray;

    [SerializeField]
    public WordData[] optionWordArray;

    private char[] charArray = new char[12];
    private int currentAnswerIndex = 0;
    private bool correctAnswer = true;
    private List<int> selectedWordIndex;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameManager gameManager;
    public CoinSystem coins;
    public Text TextTimer;
    public float Waktu = 5;
    public bool GameAktif = true;
    public GameObject CanvasWaktuHabis;

    public AudioSource win;
    public AudioSource lose;
    public AudioSource erase;
    public AudioSource answer;

    private void Awake(){
        if(instance == null) instance = this;
        else
            Destroy(gameObject);
        
        selectedWordIndex = new List<int>();
    }
    
    private void Start() {
        SetQuestion();
    }

    private void SetQuestion(){

        currentAnswerIndex = 0;
        selectedWordIndex.Clear();

        ResetQuestion();
        ResetLastWord();

        questionImage.sprite = question.questionImage;

        for(int i = 0; i < question.answer.Length; i++)
        {
            charArray[i] = char.ToUpper(question.answer[i]);
        }

        for(int i = question.answer.Length; i < optionWordArray.Length; i++)
        {
            charArray[i] = (char)UnityEngine.Random.Range(65, 91);
        }

        charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();

        for(int i = 0; i < optionWordArray.Length; i++)
        {
            optionWordArray[i].SetWord(charArray[i]);
        }
    }  

    public void SelectedOption(WordData wordData){

        if(currentAnswerIndex >= question.answer.Length) return;

        selectedWordIndex.Add(wordData.transform.GetSiblingIndex());
        answerWordArray[currentAnswerIndex].SetWord(wordData.wordValue);
        answer.Play();
        wordData.gameObject.SetActive(false);
        currentAnswerIndex++;

        if(currentAnswerIndex >= question.answer.Length){
            correctAnswer = true;

            for(int i = 0; i < question.answer.Length; i++){
                if(char.ToUpper(question.answer[i]) != char.ToUpper(answerWordArray[i].wordValue)){
                    correctAnswer = false;
                    break;
                }
            }

            if(correctAnswer){
                Debug.Log("Your answer is correct !");
                WinPanel.SetActive(true);
                win.Play();
                gameManager.WinLevel();
                coins.CoinUpdate();
                GameAktif = false;
            }else if(!correctAnswer){
                Debug.Log("Your answer is incorrect, please try again !");
                LosePanel.SetActive(true);
                lose.Play();
                GameAktif = false;
            }
        }
    }

    public void ResetQuestion(){
        for(int i = 0; i < answerWordArray.Length; i++){
            answerWordArray[i].gameObject.SetActive(true);
            answerWordArray[i].SetWord('_');
        }
        for(int i = question.answer.Length; i < answerWordArray.Length; i++){
            answerWordArray[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < optionWordArray.Length; i++)
        {
            optionWordArray[i].gameObject.SetActive(true);
        }

        currentAnswerIndex = 0;
    }

    public void ResetLastWord(){
        if(selectedWordIndex.Count > 0)
        {
            int index = selectedWordIndex[selectedWordIndex.Count - 1];
            optionWordArray[index].gameObject.SetActive(true);
            selectedWordIndex.RemoveAt(selectedWordIndex.Count -1);
            currentAnswerIndex--;
            answerWordArray[currentAnswerIndex].SetWord('_');
            erase.Play();
        }
        
    }

    void SetText()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60);
        int Detik = Mathf.FloorToInt(Waktu % 60);
        TextTimer.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }

    float s;

    void Update()
    {
        if(GameAktif)
        {
            s += Time.deltaTime;
            if(s >= 1)
            {
                Waktu--;
                s = 0;
            }
        }
        if(GameAktif && Waktu <= 0)
        {
            Debug.Log("Stage Failed");
            CanvasWaktuHabis.SetActive(true);
            lose.Play();
            GameAktif = false;
        }   
        SetText();
    }

    public void ResetTimer(){
        Waktu = 10;
        SetText();
        GameAktif = true;
    }
}

[System.Serializable]
public class QuestionData{

    public Sprite questionImage;
    public string answer;
}