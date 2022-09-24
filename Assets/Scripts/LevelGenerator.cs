using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    private GameObject LevelLayoutParent;
    private GameObject LevelLayoutParent1;
    private GameObject LevelLayoutParent2;
    private GameObject LevelLayoutParent3;
    // Start is called before the first frame update
    void Start()
    {
        LevelLayoutParent = GameObject.Find("LevelLayoutParent");
        LevelLayoutParent1 = GameObject.Find("LevelLayoutParent (1)");
        LevelLayoutParent2 = GameObject.Find("LevelLayoutParent (2)");
        LevelLayoutParent3 = GameObject.Find("LevelLayoutParent (3)");
        foreach (Transform child in LevelLayoutParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Destroy(LevelLayoutParent1);
        Destroy(LevelLayoutParent2);
        Destroy(LevelLayoutParent3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroyLevelOne()
    {
        foreach (Transform child in LevelLayoutParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Destroy(LevelLayoutParent1);
        Destroy(LevelLayoutParent2);
        Destroy(LevelLayoutParent3);
    }
}
