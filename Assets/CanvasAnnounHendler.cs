using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;


public class CanvasAnnounHendler : MonoBehaviour
{
    public GameObject annon;
    private TextMeshPro _text;
    void Start()
    {
        _text = annon.GetComponent<TextMeshPro>();
    }
    public async void Announce(string text)
    {
        _text.text = text;
        await Task.Delay(20);
        annon.GetComponent<Animation>().Play();

    }

    void Update()
    {
        
    }
}
