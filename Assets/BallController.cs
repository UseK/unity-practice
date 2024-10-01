using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int ballId;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BallController Start!");
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
        Debug.Log("Collision!");
        BallController collisionController = collision.gameObject.GetComponent<BallController>();
        if (collisionController != null && collisionController.ballId < ballId)
        {
            Destroy(collision.gameObject);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Click!");
    }
}
