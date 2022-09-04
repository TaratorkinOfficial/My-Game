using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    Camera cam;
    public PlayerBall playerBall;
    public TrajectoryCreator trajectoryCreator;
    [SerializeField] float pushForce = 4f;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    private UiController _uiController;
    [Range(0f, 2.5f)] float _blend;

    void Start()
    {
        _uiController = playerBall.uiController;
        cam = Camera.main;
        playerBall.isFlying = true;
        Input.multiTouchEnabled = false;
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
            _blend = distance;
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
            playerBall.busketController.BlenderAnim(_blend);
    }
}
