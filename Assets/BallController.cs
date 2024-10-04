using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int ballId;
    public int ballSize;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogFormat("BallController {0} Start!", ballId);
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
            ballSize += 1;
            gameObject.transform.localScale = new Vector3(ballSize * 1.0f, ballSize * 1.0f, 0);
            Destroy(collision.gameObject);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Click!");
    }
}
