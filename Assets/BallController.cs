using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class BallController : MonoBehaviour
{
    ReadOnlyCollection<Color> BALL_COLORS = Array.AsReadOnly(
        new Color[] {
             Color.black,
             Color.white,
             Color.gray,
             Color.blue,
             Color.cyan,
             Color.green,
             Color.yellow,
             Color.red,
        });
    public int ballId;
    public int ballSize;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogFormat("BallController {0} Start!", ballId);
        RerenderBall();
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
        BallController collisionController = collision.gameObject.GetComponent<BallController>();
        if (collisionController != null
        && collisionController.ballId < ballId
        && collisionController.ballSize == ballSize)
        {
            Debug.LogFormat("Same Size Ball {0} Collision!", ballSize);
            Debug.LogFormat("Distance {0}", Vector2.Distance(collisionController.transform.position, transform.position));
            GameController game = FindObjectOfType<GameController>();
            game.score += ballSize;
            game.RenderScore();
            Debug.LogFormat("Score: {0}", game.score);
            ballSize += 1;
            RerenderBall();
            Debug.LogFormat("radius ", gameObject.GetComponent<CircleCollider2D>().radius);
            Destroy(collision.gameObject);
        }
    }

    void RerenderBall() {
        gameObject.transform.localScale = new Vector3(ballSize * 0.5f, ballSize * 0.5f, 0);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color = BALL_COLORS[ballSize];
    }

    void OnMouseDown()
    {
        Debug.Log("Click!");
    }
}
