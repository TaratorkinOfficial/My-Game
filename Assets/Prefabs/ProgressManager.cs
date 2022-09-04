using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int score;
    private int stars;
    public UiController uiController;
    private int _scoreSav;
    private int _starsSav;
    private bool _once;
    [SerializeField] private ParticleSystem scoreVFX;

    void Start()
    {
        _scoreSav = PlayerPrefs.GetInt("score");
        _starsSav = PlayerPrefs.GetInt("stars");
        stars = _starsSav;
        score = 0;
        uiController.UpdateScore(score, _scoreSav);
        uiController.UpdateStars(stars);
    }
    public void AddScore(int _score)
    {
        score = _score;
        uiController.UpdateScore(score, PlayerPrefs.GetInt("score"));
        if(_scoreSav<score&& !_once)
        {
            scoreVFX.Play();
            _once = true;
        }
        if(_scoreSav < score)
        {
            _scoreSav = score;
            SaveProgress();
        }
    }
    public void AddStars(int _stars)
    {
        stars = PlayerPrefs.GetInt("stars")+ _stars;
        uiController.UpdateStars(stars);
        SaveProgress();
    }
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("score", _scoreSav);
        PlayerPrefs.SetInt("stars", stars);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveProgress();
        }
    }
}
