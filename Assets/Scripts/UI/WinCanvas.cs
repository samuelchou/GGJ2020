using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{
    private CanvasGroup group;

    private void Start()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
        Goal.OnEnterGoal.AddListener(Appear);
    }

    public void Appear()
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }
}
