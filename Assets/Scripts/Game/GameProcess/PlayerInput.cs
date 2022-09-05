using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public PlayerBall playerBall;
    public TrajectoryCreator trajectoryCreator;
    [SerializeField] float pushForce = 4f;
    private Camera cam;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private Vector2 force;
    private float distance;
    private UiController _uiController;
    private float _ratio;
    private float _width;
    private float _height;
    private float blendAnim;
    void Start()
    {
        _uiController = playerBall.uiController;
        cam = Camera.main;
        playerBall.isFlying = true;
        Input.multiTouchEnabled = false;
        PadOptimization();
    }

    private void PadOptimization()
    {
        _width = Screen.width;
        _height = Screen.height;
        _ratio = _width / _height;
        if (_ratio > .65f) pushForce *= 1.2f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!playerBall.isFlying && Input.touches.Length < 2)
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            if (distance < 2.5f) distance = Vector2.Distance(startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
            force = direction * distance * pushForce;
            trajectoryCreator.UpdateDots(playerBall.pos, force);
            blendAnim = distance;
            playerBall.lookAtFinger.Params(endPoint, playerBall.isFlying);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _uiController.StartsGame();
        if (!playerBall.isFlying && Input.touches.Length < 2)
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            trajectoryCreator.Show();
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!playerBall.isFlying && Input.touches.Length < 2)
        {
            playerBall.ActivateRb();
            playerBall.Push(force);
            trajectoryCreator.Hide();
        }
    }
    void Update()
    {
        if (!playerBall.isFlying && Input.touches.Length < 2)
        {
            playerBall.busketController.BlenderAnim(blendAnim);
        }
    }
}
