using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform target;
    public TextMeshProUGUI scoreText;

    float score;
    int formattedScore;


    public void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        score += Time.deltaTime * 100;
        formattedScore = Mathf.FloorToInt(score);
        scoreText.text = $"Score: {formattedScore}";
        PlayerPrefs.SetInt("FinalScore", formattedScore);
    }
}
