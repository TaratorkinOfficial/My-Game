using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]private GameObject playerBallPref;
    void Awake()
    {
        Instantiate(playerBallPref,transform.position,Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
