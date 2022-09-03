using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTest : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float force;
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();

    }
    public void AddF()
    {
        _rb.AddForce(Vector2.up*force, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
