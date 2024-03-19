using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dir;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            sprite.flipX = !sprite.flipX;
            dir *= -1;
        }
        
        if (transform.position.x > 2.6f)
        {
            sprite.flipX = true;
            dir = -1;
        }
        else if (transform.position.x < -2.6f)
        {
            sprite.flipX = false;
            dir = 1;
        }
        
        transform.position += Vector3.right * (dir * (moveSpeed * Time.deltaTime));
    }

 
}
