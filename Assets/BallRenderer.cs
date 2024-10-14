
using System;
using System.Collections.ObjectModel;
using UnityEngine;
public static class BallRenderer
{
    static ReadOnlyCollection<Color> BALL_COLORS = Array.AsReadOnly(
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

    public static int MAX_BALL_COLORS = 8;

    public static void RerenderBall(GameObject ballObject, int ballSize)
    {
        ballObject.transform.localScale = new Vector3(ballSize * 0.5f, ballSize * 0.5f, 0);
        SpriteRenderer renderer = ballObject.GetComponent<SpriteRenderer>();
        renderer.color = BALL_COLORS[ballSize];
    }
}