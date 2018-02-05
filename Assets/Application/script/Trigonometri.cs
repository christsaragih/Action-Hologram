using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometri  {
    public float X, Y, R;

    public Trigonometri(Vector2 value1, Vector2 value2)
    {
        X = value1.x-value2.x;
        Y = value1.y-value2.y;
        if (X < 0) {
            X *= -1;
        }
        if (Y < 0)
        {
            Y *= -1;
        }
    }
    public float GetValueR() {
        R = Mathf.Pow(X, 2) + Mathf.Pow(Y, 2);
        R = Mathf.Sqrt(R);
        return R;
    }
}
