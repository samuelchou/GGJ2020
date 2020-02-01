using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SockCanvas : MonoBehaviour
{
    public Image[] images;
    public List<int> sockHashes = new List<int>();

    public void AddSock(int hash)
    {
        for(int i = 0; i < sockHashes.Count; i++)
        {
            if(sockHashes[i] == hash)
            {
                sockHashes.RemoveAt(i);
                for (int j = i + 1; j < sockHashes.Count; j++)
                {
                    return;
                }
                    return;
            }
        }
        sockHashes.Add(hash);
        switch (hash)
        {
            case 1:
                images[sockHashes.Count - 1].color = Color.red;
                break;
            case 2:
                images[sockHashes.Count - 1].color = Color.green;
                break;
            case 3:
                images[sockHashes.Count - 1].color = Color.blue;
                break;
            case 4:
                images[sockHashes.Count - 1].color = Color.grey;
                break;
            case 5:
                images[sockHashes.Count - 1].color = Color.cyan;
                break;
            default:
                images[sockHashes.Count - 1].color = Color.clear;
                break;
        }
    }
}
