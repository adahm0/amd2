using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InvestmentTimer : MonoBehaviour
{
    public Text timerText; // اسحب هنا UI Text اللي يعرض الوقت
    public string loseSceneName = "los"; // اسم مشهد الخسارة

    private float timeRemaining = 90f; // 1 دقيقة و 30 ثانية

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            SceneManager.LoadScene("los");
        }
    }
}
