using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public static UnityEvent OnEnterGoal = null;

    private void Awake()
    {
        if (OnEnterGoal == null)
            OnEnterGoal = new UnityEvent();
        else
            Debug.LogWarning("一個scene應該只存在一個goal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //其他scrpit用OnEnterGoal.AddListener(函數名稱)來註冊事件
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            OnEnterGoal.Invoke();
    }

    private void OnDestroy()
    {
        OnEnterGoal.RemoveAllListeners();
        OnEnterGoal = null;
    }
}
