using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource collisionSound;
    [SerializeField] private AudioSource inBasketWithCollisSound;
    [SerializeField] private AudioSource inBasketWithOutCollisSound;
    [SerializeField] private AudioSource loseSound;
    [SerializeField] private AudioSource outBasketSound;
    [SerializeField] private AudioSource starSound;
    private string _name;
    public void PlayAudioSourse(string name)
    {
        _name = name;
        switch (_name)
        {
            case "collisionSound":
                collisionSound.Play();
                break;
            case "inBasketWithCollisSound":
                inBasketWithCollisSound.Play();
                break;
            case "inBasketWithOutCollisSound":
                inBasketWithOutCollisSound.Play();
                break;
            case "loseSound":
                loseSound.Play();
                break;
            case "outBasketSound":
                outBasketSound.Play();
                break;
            case "starSound":
                starSound.Play();
                break;
        }
    }
}
