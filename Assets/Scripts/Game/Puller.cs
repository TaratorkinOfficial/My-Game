using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : MonoBehaviour
{
    [HideInInspector] public Vector3 _firstPoint;
    [HideInInspector] public Vector3 _dragedPoint;
    [SerializeField] private TrajectoryCreator trajectoryCreator;
    public Vector3 speed;
    public Vector3 speed1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
