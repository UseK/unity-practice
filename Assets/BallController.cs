using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int ballId;
    public int ballSize;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogFormat("BallController {0} Start!", ballId);
        BallRenderer.RerenderBall(gameObject, ballSize);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    { // 接触した直後
        Debug.Log("OnTriggerEnter!!");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver")) {
            Debug.Log("Gave Over!!");
        };
        BallController collisionController = collision.gameObject.GetComponent<BallController>();
        if (collisionController != null
        && collisionController.ballId < ballId
        && collisionController.ballSize == ballSize)
        {
            Debug.LogFormat("Same Size Ball {0} Collision!", ballSize);
            Debug.LogFormat("Distance {0}", Vector2.Distance(collisionController.transform.position, transform.position));
            GameController game = FindObjectOfType<GameController>();
            game.score += PowerOf10(ballSize);
            game.RenderScore();
            Debug.LogFormat("Score: {0}", game.score);
            ballSize += 1;
            BallRenderer.RerenderBall(gameObject, ballSize);
            Debug.LogFormat("radius ", gameObject.GetComponent<CircleCollider2D>().radius);
            Destroy(collision.gameObject);
        }
    }

    int PowerOf10(int p)
    {
        int result = 1;
        for (int i = 0; i < p; i++) { result *= 10; }
        return result;
    }

    void OnMouseDown()
    {
        Debug.Log("Click!");
    }
}
