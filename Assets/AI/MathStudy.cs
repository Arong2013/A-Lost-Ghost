using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MathStudy : MonoBehaviour
{
    [SerializeField]
    private List<int> li;
    // Start is called before the first frame update
    void Start()
    {       
        for (int i = 0; i < li.Count; i++)
        {
            for (int x = i; x < li.Count; x++)            
                if (li[i] > li[x])
                {
                    int s = li[x];
                    li[x] = li[i];
                    li[i] = s;
                }
        }
    }
}
