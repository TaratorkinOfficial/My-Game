using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Image[] skins;
    private int skinNum;
    private SpriteRenderer _playerBallSkin;
    void Start()
    {
        _playerBallSkin = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        skinNum = PlayerPrefs.GetInt("skinSave");
        for (int i = 0; i <= skinNum; i++)
        {
            _playerBallSkin.sprite = skins[i].sprite;
        }
    }
    void Update()
    {
        
    }
}
