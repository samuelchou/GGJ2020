using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCanvas : MonoBehaviour
{
    private CanvasGroup group;

    private void Start()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
        PlayerControl.OnDie.AddListener(Appear);
    }

    public void Appear()
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }
}
