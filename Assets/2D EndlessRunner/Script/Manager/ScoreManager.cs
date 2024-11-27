using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private float score = 0f;


    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }
}
