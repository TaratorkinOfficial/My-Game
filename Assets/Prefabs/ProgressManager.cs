using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int score;
    private int stars;
    [HideInInspector] public UiController uiController;
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
        //_score = score;
        //_stars = stars;
    }
    public void AddScore(int _score)
    {
        score = _score;
        _scoreSav = score;
        uiController.UpdateScore(score, _scoreSav);
        if(_scoreSav<score&& !_once)
        {
            scoreVFX.Play();
            _once = true;
        }
    }
    public void AddStars(int _stars)
    {
        stars += _stars;
        uiController.UpdateStars(stars);
    }
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("score", _scoreSav);
        PlayerPrefs.SetInt("stars", stars);
    }
    void Update()
    {
        
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveProgress();
        }
    }
}
