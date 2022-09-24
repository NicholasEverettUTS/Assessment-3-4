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

    GameObject[,] mapArray;

    private GameObject LevelLayoutParent;
    private GameObject LevelLayoutParent1;
    private GameObject LevelLayoutParent2;
    private GameObject LevelLayoutParent3;

    [SerializeField]
    private GameObject outsideCorner;
    [SerializeField]
    private GameObject outsideWall;
    [SerializeField]
    private GameObject insideCorner;
    [SerializeField]
    private GameObject insideWall;
    [SerializeField]
    private GameObject standardPellet;
    [SerializeField]
    private GameObject powerPellet;
    [SerializeField]
    private GameObject junction;

    private GameObject holder;


    int xIndex = -13;
    int yIndex = 14;
    // Start is called before the first frame update
    void Start()
    {
        mapArray = new GameObject[levelMap.GetLength(0), levelMap.GetLength(1)];
        mapArray = new GameObject[levelMap.GetLength(0), levelMap.GetLength(1)];
        LevelLayoutParent = GameObject.Find("LevelLayoutParent");
        LevelLayoutParent1 = GameObject.Find("LevelLayoutParent (1)");
        LevelLayoutParent2 = GameObject.Find("LevelLayoutParent (2)");
        LevelLayoutParent3 = GameObject.Find("LevelLayoutParent (3)");
        destroyLevelOne();
        generator();
        rotator();
        mirror();
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

    void generator()
    {
        for (int y = 0; y < levelMap.GetLength(0); y++)
        {
            for (int x = 0; x < levelMap.GetLength(1); x++)
            {
                switch (levelMap[y, x])
                {
                    case 0:
                        mapArray[y, x] = null;
                        break;
                    case 1:
                        mapArray[y, x] = Instantiate(outsideCorner, new Vector3(xIndex, yIndex, 0), Quaternion.identity);
                        break;
                    case 2:
                        mapArray[y, x] = Instantiate(outsideWall, new Vector3(xIndex, yIndex, 0), Quaternion.identity);
                        break;
                    case 3:
                        mapArray[y, x] = Instantiate(insideCorner, new Vector3(xIndex, yIndex, 0), Quaternion.identity);
                        break;
                    case 4:
                        mapArray[y, x] = Instantiate(insideWall, new Vector3(xIndex, yIndex, 0), Quaternion.identity);
                        break;
                    case 5:
                        mapArray[y, x] = Instantiate(standardPellet, new Vector3(xIndex, yIndex, 0), Quaternion.identity);
                        break;
                    case 6:
                        mapArray[y, x] = Instantiate(powerPellet, new Vector3(xIndex, yIndex, 0), Quaternion.identity);
                        break;
                    case 7:
                        mapArray[y, x] = Instantiate(junction, new Vector3(xIndex, yIndex, 0), Quaternion.identity);
                        break;
                }
                xIndex++;
            }
            yIndex--;
            xIndex = -13;
        }
    }

    void rotator()
    {
        for (int y = 0; y < levelMap.GetLength(0); y++)
        {
            for (int x = 0; x < levelMap.GetLength(1); x++)
            {
                switch (levelMap[y, x])
                {
                    case 1:
                        if (y != 0)
                        {
                            if (mapArray[y - 1, x] != null)
                            {
                                if (mapArray[y - 1, x].transform.rotation.eulerAngles.z == 90)
                                {
                                    if (x != 0 && mapArray[y, x - 1] != null)
                                    {
                                        if (mapArray[y, x - 1].transform.rotation.eulerAngles.z == 0)
                                        {
                                            mapArray[y, x].transform.Rotate(0, 0, 180);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        mapArray[y, x].transform.Rotate(0, 0, 90);
                                        break;
                                    }
                                }
                            }
                        }
                        if (x != 0)
                        {
                            if (mapArray[y, x - 1].transform.rotation.eulerAngles.z == 90 || mapArray[y, x - 1].transform.rotation.eulerAngles.z == 180)
                            {
                                mapArray[y, x].transform.Rotate(0, 0, 270);
                                break;
                            }
                        }
                        break;
                    case 2:
                        if (x != 0)
                        {
                            if (mapArray[y, x - 1] != null)
                            {
                                if (mapArray[y, x - 1].transform.rotation.eulerAngles.z == 90 || mapArray[y, x - 1].transform.rotation.eulerAngles.z == 180)
                                {
                                    mapArray[y, x].transform.Rotate(0, 0, 180);
                                    break;
                                }
                            }
                        }
                        if (y != 0)
                        {
                            if (mapArray[y - 1, x] != null)
                            {
                                if (mapArray[y - 1, x].transform.rotation.eulerAngles.z == 0 || mapArray[y - 1, x].transform.rotation.eulerAngles.z == 90 || mapArray[y - 1, x].transform.rotation.eulerAngles.z == 270)
                                {
                                    mapArray[y, x].transform.Rotate(0, 0, 90);
                                    break;
                                }
                            }
                        }
                        break;

                    case 3:
                        if (levelMap[y - 1, x] == 5 || levelMap[y - 1, x] == 0)
                        {
                            if (levelMap[y, x - 1] == 5 || levelMap[y, x - 1] == 0)
                            {
                                mapArray[y, x].transform.Rotate(0, 0, 0);
                                break;
                            }
                        }
                        if (levelMap[y + 1, x] == 5 || levelMap[y + 1, x] == 0)
                        {
                            if (levelMap[y, x - 1] == 5 || levelMap[y, x - 1] == 0)
                            {
                                mapArray[y, x].transform.Rotate(0, 0, 90);
                                break;
                            }
                        }
                        if (levelMap[y - 1, x] == 5 || levelMap[y - 1, x] == 0)
                        {
                            if (levelMap[y, x - 1] == 5 || levelMap[y, x - 1] == 0)
                            {
                                mapArray[y, x].transform.Rotate(0, 0, 0);
                                break;
                            }
                        }
                        if (levelMap[y - 1, x] == 5 || levelMap[y - 1, x] == 0)
                        {
                            if (levelMap[y, x + 1] == 5 || levelMap[y, x + 1] == 0)
                            {
                                mapArray[y, x].transform.Rotate(0, 0, 270);
                                break;
                            }
                        }
                        if (levelMap[y + 1, x] == 5 || levelMap[y + 1, x] == 0)
                        {
                            if (levelMap[y, x + 1] == 5 || levelMap[y, x + 1] == 0)
                            {
                                mapArray[y, x].transform.Rotate(0, 0, 180);
                                break;
                            }
                        }
                        if (levelMap[y + 1, x - 1] == 5 || levelMap[y + 1, x - 1] == 0)
                        {
                            mapArray[y, x].transform.Rotate(0, 0, 270);
                            break;
                        }
                        if (levelMap[y - 1, x - 1] == 5 || levelMap[y - 1, x - 1] == 0)
                        {
                            mapArray[y, x].transform.Rotate(0, 0, 180);
                            break;
                        }
                        if (levelMap[y + 1, x + 1] == 5 || levelMap[y + 1, x + 1] == 0)
                        {
                            mapArray[y, x].transform.Rotate(0, 0, 0);
                            break;
                        }
                        if (levelMap[y - 1, x + 1] == 5 || levelMap[y - 1, x + 1] == 0)
                        {
                            mapArray[y, x].transform.Rotate(0, 0, 90);
                            break;
                        }
                        break;
                    case 4:
                        if (mapArray[y - 1, x] != null)
                        {
                            if (mapArray[y - 1, x].transform.rotation.eulerAngles.z == 90 || mapArray[y - 1, x].transform.rotation.eulerAngles.z == 270 || levelMap[y - 1, x] == 7 || levelMap[y - 1, x] == 3)
                            {
                                mapArray[y, x].transform.Rotate(0, 0, 90);
                            }
                        }
                        break;
                }
            }
        }
    }

    void mirror()
    {
        for (int y = 0; y < mapArray.GetLength(0) - 2; y++)
        {
            for (int x = 0; x < mapArray.GetLength(1); x++)
                {
                if (mapArray[y, x] != null)
                {
                    mapArray[y, x].transform.parent = LevelLayoutParent.transform;
                }
            }
        }
        Debug.Log(mapArray[13, 10].transform.position);
        Debug.Log(mapArray[14, 10].transform.position);
        LevelLayoutParent1 = Instantiate(LevelLayoutParent, new Vector3(1, 0, 0), Quaternion.identity);
        LevelLayoutParent1.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        LevelLayoutParent2 = Instantiate(LevelLayoutParent, new Vector3(0, 0, 0), Quaternion.identity);
        LevelLayoutParent2.transform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
        for (int x = 0; x < levelMap.GetLength(1); x++)
        {
            if (mapArray[levelMap.GetLength(0) - 1, x] != null)
            {
                mapArray[levelMap.GetLength(0) - 1, x].transform.parent = LevelLayoutParent.transform;
            }
        }
        LevelLayoutParent3 = Instantiate(LevelLayoutParent, new Vector3(1, 0, 0), Quaternion.identity);
        LevelLayoutParent3.transform.localScale = new Vector3(-1.0f, -1.0f, 1.0f);
    }
}