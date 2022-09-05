using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHandler : MonoBehaviour
{
    static Plane plane;
    public GameObject leftBorder;
    public GameObject rightBorder;
    [HideInInspector] public Vector2 upBorderPoint;
    [HideInInspector] public Vector2 downBorderPoint;
    [HideInInspector] public Vector2 rightTop;
    [SerializeField] private Transform playerBall;


    void Start()
    {
        #region
        //Debug.Log(CalcPosition(new Vector2(0f, 0f)));
        //Debug.Log(CalcPosition(new Vector2(Screen.width, 0f)));
        //Debug.Log(CalcPosition(new Vector2(0f, Screen.height)));
        //Debug.Log(CalcPosition(new Vector2(Screen.width, Screen.height)));

        //Debug.Log(CalcPosition(new Vector2(Screen.width/2, 0f)));
        //Debug.Log(CalcPosition(new Vector2(0f, Screen.height/2)));
        #endregion
        plane = new Plane(transform.forward, transform.position);
        rightBorder.transform.position = CalcPosition(new Vector2(Screen.width, Screen.height / 2));
        leftBorder.transform.position = CalcPosition(new Vector2(0f, Screen.height / 2));
        upBorderPoint = CalcPosition(new Vector2(Screen.width / 2, Screen.height));
        downBorderPoint = CalcPosition(new Vector2(Screen.width / 2, 0f));
        rightTop = CalcPosition(new Vector2(Screen.width, Screen.height));
    }


    public Vector3 CalcPosition(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        float dist = 0f;
        Vector3 pos = Vector3.zero;
        if (plane.Raycast(ray, out dist))
            pos = ray.GetPoint(dist);
        return pos;
    }
}
