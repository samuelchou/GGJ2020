using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SockCanvas : MonoBehaviour
{
    public static SockCanvas instance = null;
    public Image[] images;
    public List<int> sockHashes = new List<int>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public bool AddSock(int hash)
    {
        for(int i = 0; i < sockHashes.Count; i++)
        {
            if(sockHashes[i] == hash)
            {
                sockHashes.RemoveAt(i);
                for (int j = 0; j < 5; j++)
                {
                    int index = ((j >= sockHashes.Count) ? 0 : sockHashes[j]);
                    switch (index)
                    {
                        case 1:
                            images[j].color = Color.red;
                            break;
                        case 2:
                            images[j].color = Color.green;
                            break;
                        case 3:
                            images[j].color = Color.blue;
                            break;
                        case 4:
                            images[j].color = Color.grey;
                            break;
                        case 5:
                            images[j].color = Color.cyan;
                            break;
                        default:
                            images[j].color = Color.clear;
                            break;
                    }
                }
                Debug.Log("PAIR");
                return true;
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
        return false;
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
