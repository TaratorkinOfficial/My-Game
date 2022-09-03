using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class resetlvl : MonoBehaviour
{
    //private Camera cam;
    //public GameObject point;
    // Start is called before the first frame update
    public GameObject ddddddd;
    private ParticleSystem fd;
    void Start()
    {
        //gameObject.GetComponent<TextMeshProUGUI>().text = @"BEST SCORE 56";
        //cam = Camera.main;
        //Vector2 test = cam.WorldToScreenPoint(point.transform.position);
        //Vector2 test1 = cam.WorldToScreenPoint(point.GetComponent<Renderer>().bounds.max);
        //print(test);
        //print(test1);
        //fd = ddddddd.GetComponent<ParticleSystem>();

    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Partif()
    {
        //fd.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
