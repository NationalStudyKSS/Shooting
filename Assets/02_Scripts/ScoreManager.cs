using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public GameObject _inputDiscription;

    public TextMesh scoreText;
    private int _gameScore;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(DisableAfterSeconds(5f));
    }

    IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _inputDiscription.SetActive(false);
    }

    public void AddScore(int amount)
    {
        _gameScore += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "SCORE : " + _gameScore + "Á¡";
    }
}
