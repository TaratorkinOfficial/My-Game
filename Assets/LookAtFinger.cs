using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAtFinger : MonoBehaviour
{
    private Vector3 _finger;
    private bool _isFlying;
    void Start()
    {
        _isFlying = true;
    }
    public void Params(Vector3 finger, bool isFlying)
    {
        _finger = finger;
        _isFlying = isFlying;
    }
    void Update()
    {
        if (!_isFlying)
        {
            var dir = transform.position - _finger;
            var angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        //else transform.rotation = Quaternion.identity;
    }
}
