using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private GameObject CanvasTextAnnoun;
    [SerializeField] private Image ImageBackSettings;
    [SerializeField] private Sprite NightOn;
    [SerializeField] private Sprite NightOff;
    [SerializeField] private Toggle _soundMode;
    [SerializeField] private Toggle _nightMode;
    [SerializeField] private Toggle _nightMode1;
    [SerializeField] private TextMeshProUGUI _textBesScore;
    [SerializeField] private TextMeshProUGUI _textStars;
    [SerializeField] private GameObject fingerMove;
    [SerializeField] private GameObject backCustStartGame;
    private CanvasAnnounHendler _canvasAnnounHendler;
    private int i;
    private int j;
    public GameObject startGamePanel;
    public GameObject inGamePanel;
    public GameObject loseGamePanel;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("StaticInts") == 0) SaveStaticInts();
    }
    void Start()
    {
        _textBesScore.text = PlayerPrefs.GetInt("score").ToString();
        _textStars.text = PlayerPrefs.GetInt("stars").ToString();
        _canvasAnnounHendler = CanvasTextAnnoun.GetComponent<CanvasAnnounHendler>();
        i = PlayerPrefs.GetInt("night");
        // NightMode
        if (i == -1) _nightMode.isOn = true;
        else _nightMode.isOn = false;
        if (i == -1) _nightMode1.isOn = false;
        else _nightMode1.isOn = true;
        // SoundMode
        j = PlayerPrefs.GetInt("sound");
        if (j > 0) _soundMode.isOn = true;
        else _soundMode.isOn = false;
    }
    public void StartsGame()
    {
        fingerMove.SetActive(false);
        startGamePanel.SetActive(false);
        inGamePanel.SetActive(true);
        backCustStartGame.SetActive(false);
    }

    #region NightMode Saves SoundMode
    private void SaveStaticInts()
    {
        PlayerPrefs.SetInt("StaticInts", 1);
        PlayerPrefs.SetInt("sound", 1);
        PlayerPrefs.SetInt("night", -1);
    }
    public void NightSwitch(bool isOn)
    {
            if (isOn)
            {
                if (_nightMode.isOn == true) _nightMode1.isOn = false;
                ImageBackSettings.sprite = NightOn;
                print("on");
                PlayerPrefs.SetInt("night", -1);
            }
            else
            {
                if (_nightMode.isOn == false) _nightMode1.isOn = true;
                ImageBackSettings.sprite = NightOff;
                print("off");
                PlayerPrefs.SetInt("night", 1);
            }
    }
    public void NightSwitch1(bool isOn)
    {
  
            if (isOn)
            {
                if (_nightMode1.isOn == true) _nightMode.isOn = false;
                //if (_test1.isOn == true) _test1.isOn = false;
                ImageBackSettings.sprite = NightOff;
                print("off");

            }
            else
            {
                if (_nightMode1.isOn == false) _nightMode.isOn = true;
                //if (_test1.isOn == false) _test1.isOn = true;
                ImageBackSettings.sprite = NightOn;
                print("on");
            }
    }
    public void SoundMode()
    {
        print("SoundMode");
        if (_soundMode.isOn == true)
        {
            print("ON");
            //SoundON
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            //SoundOFF
            PlayerPrefs.SetInt("sound", -1);
        }
    } 
    #endregion

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            
        }
    }
    public void AnnounceActivate(string text, Vector2 pos)
    {
        CanvasTextAnnoun.transform.position = pos;
        _canvasAnnounHendler.Announce(text);
    }
    public void UpdateScore(int score, int scoreB)
    {
        textScore.text = score.ToString();
        _textBesScore.text = scoreB.ToString();
    }
    public void UpdateStars(int stars)
    {
        _textStars.text = stars.ToString();
        
    }
    public void Lose()
    {
        _textBesScore.text = PlayerPrefs.GetInt("score").ToString();
        loseGamePanel.SetActive(true);
        inGamePanel.GetComponentInChildren<Image>().gameObject.SetActive(false);
    }
    public void HideSprites(int sortOrder)
    {
        gameObject.GetComponent<Canvas>().sortingOrder = sortOrder;
    }
    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        
    }
}
