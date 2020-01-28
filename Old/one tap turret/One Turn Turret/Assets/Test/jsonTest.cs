using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class jsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        enemSeqNode node1 = new enemSeqNode();
        node1.enemTyp = EnemTyp.basic;
        node1.allowedSpawnArea = new List<int>();
        node1.allowedSpawnArea.Add(3);
        node1.delayTillSpawning = 5f;
        
        enemSeqNode node2 = new enemSeqNode();
        node2.enemTyp = EnemTyp.spiral;
        node2.allowedSpawnArea = new List<int>();
        node2.allowedSpawnArea.Add(5);
        node2.allowedSpawnArea.Add(6);
        node2.delayTillSpawning = 3.2f;
        
        enemSeqList testSeq = new enemSeqList();
        testSeq.nodeSeq = new enemSeqNode[] { node1, node2 };
        /*testSeq.nodeSeq[0] = new enemSeqNode();
        testSeq.nodeSeq[1] = new enemSeqNode();

        testSeq.nodeSeq[0].enemTyp = EnemTyp.basic;
        testSeq.nodeSeq[0].allowedSpawnArea = new List<int>();
        testSeq.nodeSeq[0].allowedSpawnArea.Add(3);
        testSeq.nodeSeq[0].delayTillSpawning = 5f;*/
        /*
        testSeq.nodeSeq[1].enemTyp = EnemTyp.spiral;
        testSeq.nodeSeq[1].allowedSpawnArea = new List<int>();
        testSeq.nodeSeq[1].allowedSpawnArea.Add(5);
        testSeq.nodeSeq[1].allowedSpawnArea.Add(6);
        testSeq.nodeSeq[1].delayTillSpawning = 3.2f;*/

        //Debug.Log(JsonUtility.ToJson(testSeq));

        List<int> testList = new List<int> { 1, 3, 5, 7, 8 };
        for(int i=0; i<10; i++)
        {
            Debug.Log(testList[UnityEngine.Random.Range(0, testList.Count)]);
        }
    }
}

[Serializable]
public class enemSeqList
{
    public enemSeqNode[] nodeSeq; 
}

[Serializable]
public class enemSeqNode
{
    public EnemTyp enemTyp;
    public List<int> allowedSpawnArea;
    public float delayTillSpawning;
}

public enum EnemTyp
{
    basic,
    spiral
}