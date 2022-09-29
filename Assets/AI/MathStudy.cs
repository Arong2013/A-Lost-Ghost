using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[System.Serializable]
public class Hanoi
{
    public List<int> Top;
    public bool Move;
}


public class MathStudy : MonoBehaviour
{
    [SerializeField]
    private List<Hanoi> hanois;

    [SerializeField]
    private int counts;
    
    /*
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
    }*/

    public void Start()
    {/*
        for(int i =0; i<hanois.Count; i++)        
            for(int x = hanois[i].Top.Count; x< hanois[i].Top.Count; x++)
            {
                if(i == 0)
                {
                    hanois[i].Top[x]
                }
            }
        */
    }
}
