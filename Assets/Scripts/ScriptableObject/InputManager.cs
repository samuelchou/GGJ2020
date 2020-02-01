using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InputManager : ScriptableObject
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public string giveKeyCode(string name)
    {
        switch(name)
        {
            case "Up":
                return up.ToString();
            case "Down":
                return down.ToString();
            case "Left":
                return left.ToString();
            case "Right":
                return right.ToString();
            case "Jump":
                return jump.ToString();
            default:
                return null;
        }
    }

    public void setKey(string name, KeyCode newKey)
    {
        switch (name)
        {
            case "Up":
                up = newKey;
                break;
            case "Down":
                down = newKey;
                break;
            case "Left":
                left = newKey;
                break;
            case "Right":
                right = newKey;
                break;
            case "Jump":
                jump = newKey;
                break;         
            default:
                break;
        }
    }

    public void Reset()
    {
        up = KeyCode.W;
        down = KeyCode.S;
        left = KeyCode.A;
        right = KeyCode.D;
        jump = KeyCode.Space;
    }

    public bool checkValid(KeyCode newKey)
    {
        if (newKey == up || newKey == down || newKey == left || newKey == right || newKey == jump || newKey == KeyCode.None || newKey == KeyCode.Return || newKey == KeyCode.Escape)
            return false;
        else
            return true;
    }
}
