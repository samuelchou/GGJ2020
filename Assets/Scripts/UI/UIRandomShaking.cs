//UI Random Shaking made by STC
//Contact:          stc.ntu@gmail.com
//Last maintained:  2017/09/15
//Usage:            Make something on UI shake. CAUTION: Might be a little annoying.
//Notice:           It require a RectTransform to use it. If the thing don't get one, the script will summon one.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
public class UIRandomShaking : MonoBehaviour
{

    
    public float[] leftUpPoint = new float[2] { -5, 5 };
    public float[] rightDownPoint = new float[2] { 5, -5 };

    private RectTransform rectTransform;
    private Vector2 newPosition;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //Debug.Log(rectTransform.anchoredPosition);
    }
    
    void Update()
    {
        newPosition = new Vector2(
            Random.Range(leftUpPoint[0], rightDownPoint[0]),
            Random.Range(leftUpPoint[1], rightDownPoint[1]));
        rectTransform.anchoredPosition = newPosition;

    }
}
