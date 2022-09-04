using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Threading.Tasks;

public class CustomizeManager : MonoBehaviour
{
    private Button _selfButton;
    private Image _selfBallImage;
    private Sprite _selfBallSkin;
    private SpriteRenderer _playerBallSkin;
    private string _name;
    private Transform _buttPlusT;
    private Button _buttPlus;
    private string _skinNameSave;

    void Start()
    {
        _playerBallSkin = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        _selfBallImage = GetComponent<Image>();
        _selfBallSkin = _selfBallImage.sprite;
        _selfButton = GetComponent<Button>();
        if (!CompareTag("firstSkin"))
        {
            _buttPlusT = transform.GetChild(0);
            _buttPlus= _buttPlusT.GetComponent<Button>();
            _skinNameSave = gameObject.name;
            _buttPlus.onClick.AddListener(EnableButtonSkin);   
            if (PlayerPrefs.GetInt(_skinNameSave) == 1)
            {
                _buttPlusT.gameObject.SetActive(false);
                _selfButton.interactable = true;
            }
            else
            {
                _buttPlusT.gameObject.SetActive(true);
                _selfButton.interactable = false;
            }
        }
    }
    //Add to onClick Button
    public void CangeSkin(int skinNum)
    {
        _playerBallSkin.sprite = _selfBallSkin;
        PlayerPrefs.SetInt("skinSave", skinNum);
    }
    private void EnableButtonSkin()
    {
        PlayerPrefs.SetInt(_skinNameSave, 1);
    }
}
