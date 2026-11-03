
using UnityEngine;
using TMPro;
public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 500f;
    public TextMeshProUGUI timerText;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            gameover();

        }

        timerText.text = Mathf.Ceil(timeRemaining).ToString();

    }

    void gameover() 
    {

        Time.timeScale = 0f;
        
   
    }

}
