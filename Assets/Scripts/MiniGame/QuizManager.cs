using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    //public TextMeshProUGUI QuestionTxt;
    public Text QuestionTxt;
    public Text ScoreText;

    int totalQuestions = 0;
    public int score;


    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        
    }

  

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        //when right, count score
        score += 1;
        QnA.RemoveAt(currentQuestion);
        //generateQuestion();
        StartCoroutine(WaitForNext());
    }

    public void wrong()
    {
        //when answer is wrong
        QnA.RemoveAt(currentQuestion);
        //generateQuestion();
        StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;

            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);


            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();

        }
        else
        {
            Debug.Log("lalala");
            GameOver();
        }

    }

}
