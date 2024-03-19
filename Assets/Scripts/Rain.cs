using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Rain : MonoBehaviour
{
    private float size;
    private int score;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 5);

        switch (type)
        {
            case 1:
                size = 0.8f;
                score = 1;
                sprite.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
                break;
            case 2:
                size = 1.0f;
                score = 3;
                sprite.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
                break;
            case 3:
                size = 1.2f;
                score = 5;
                sprite.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
                break;
            case 4:
                size = 0.8f;
                score = -5;
                sprite.color =new Color(255 / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 255.0f / 255.0f); 
                break;
        }

        transform.localScale = new Vector3(size, size, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Untagged"))
        {
            return;
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(score);
        }
        Destroy(gameObject);
    }
}
