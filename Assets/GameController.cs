using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SpriteRenderer aimBall;
    public GameObject dropBall;
    public int dropBallCount;
    // Start is called before the first frame update
    void Start()
    {
        dropBallCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        aimBall.transform.position += new Vector3(Input.GetAxis("Horizontal") * 0.001f, 0.0f, 0.0f);
    }

    public void MoveLeft()
    {
        Debug.Log("Left!!!");
        aimBall.transform.position += new Vector3(-0.1f, 0.0f, 0.0f);
    }
    public void MoveRight()
    {
        Debug.Log("Right!!!");
        aimBall.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
    }

    public void DoDropBall()
    {
        var ball = Instantiate(dropBall);
        ball.GetComponent<BallController>().ballId = dropBallCount;
        dropBallCount++;
        var x = aimBall.transform.position.x;
        var y = aimBall.transform.position.y;
        ball.transform.position = new Vector2(x, y);
    }
}
