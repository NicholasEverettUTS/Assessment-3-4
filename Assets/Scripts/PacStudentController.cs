using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private Tweener tweener;
    [SerializeField]
    private GameObject pacStudent;
    private char lastInput;
    private char currentInput;
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
    };

    // Start is called before the first frame update
    void Start()
    {
        tweener = tweener = GetComponent<Tweener>();
        Debug.Log(pacStudent.transform.position.y * 1 - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            lastInput = 'd';
            
        }

        if (Input.GetKeyDown("s"))
        {
            lastInput = 's';
        }

        if (Input.GetKeyDown("a"))
        {
            lastInput = 'a';
        }

        if (Input.GetKeyDown("w"))
        {
            lastInput = 'w';
        }

        inputter(lastInput);

        switch (currentInput) { 
            case 'd':
                if(tweener.TweenExists(pacStudent.transform) == false)
                {
                    tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x + 1, pacStudent.transform.position.y, 0.0f), 0.2f);
                }
                break;
            case 's':
                if (tweener.TweenExists(pacStudent.transform) == false)
                {
                    tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y - 1, 0.0f), 0.2f);
                }
                break;
            case 'a':
                if (tweener.TweenExists(pacStudent.transform) == false)
                {
                    tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x - 1, pacStudent.transform.position.y, 0.0f), 0.2f);
                }
                break;
            case 'w':
                if (tweener.TweenExists(pacStudent.transform) == false)
                {
                    tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1, 0.0f), 0.2f);
                }
                break;
        }

        void inputter(char c)
        {
            switch (c)
            {
                case 'd':
                    if (pacStudent.transform.position.x + 1 > -14 && pacStudent.transform.position.x + 1 < 14)
                    {
                        float xCoordinate = pacStudent.transform.position.x + 1;
                        float yCoordinate = pacStudent.transform.position.y;
                        for (int y = 14; y > -15; y--)
                        {
                            for (int x = -13; x < 15; x++)
                            {
                                if (xCoordinate == x && yCoordinate == y)
                                {
                                    Debug.Log("hit");
                                    Debug.Log(xCoordinate + 14);
                                    //Debug.Log(yCoordinate*-1 + 14);
                                    if (levelMap[(int)xCoordinate + 13, (int)yCoordinate * -1 + 14] == 5 ||
                                        levelMap[(int)xCoordinate + 13, (int)yCoordinate * -1 + 14] == 6 ||
                                        levelMap[(int)xCoordinate + 13, (int)yCoordinate * -1 + 14] == 0)
                                    {
                                        currentInput = 'd';
                                        Debug.Log(currentInput);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 's':
                    if (pacStudent.transform.position.y *1 -1 > -14 && pacStudent.transform.position.y *1 -1 < 15)
                    {
                        float xCoordinate = pacStudent.transform.position.x;
                        float yCoordinate = pacStudent.transform.position.y - 1;
                        for (int y = 14; y > -15; y--)
                        {
                            for (int x = -13; x < 15; x++)
                            {
                                if (xCoordinate == x && yCoordinate == y)
                                {
                                    Debug.Log("hit");
                                    Debug.Log(xCoordinate + 13);
                                    Debug.Log(yCoordinate * -1 + 14);
                                    if (levelMap[(int)xCoordinate + 13, (int)yCoordinate *1 + 14] == 5 ||
                                        levelMap[(int)xCoordinate + 13, (int)yCoordinate *1 + 14] == 6 ||
                                        levelMap[(int)xCoordinate + 13, (int)yCoordinate *1 + 14] == 0)
                                    {
                                        currentInput = 's';
                                        Debug.Log(currentInput);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 'a':
                    if (pacStudent.transform.position.x + 1 > -13 && pacStudent.transform.position.x + 1 < 14)
                    {
                        float xCoordinate = pacStudent.transform.position.x - 1;
                        float yCoordinate = pacStudent.transform.position.y;
                        for (int y = 14; y > -15; y--)
                        {
                            for (int x = -13; x < 15; x++)
                            {
                                if (xCoordinate == x && yCoordinate == y)
                                {
                                    Debug.Log("hit");
                                    Debug.Log(xCoordinate + 14);
                                    //Debug.Log(yCoordinate*-1 + 14);
                                    if (levelMap[(int)xCoordinate + 13, (int)yCoordinate +13] == 5 ||
                                        levelMap[(int)xCoordinate + 13, (int)yCoordinate + 14] == 6 ||
                                        levelMap[(int)xCoordinate + 13, (int)yCoordinate + 14] == 0)
                                    {
                                        currentInput = 'a';
                                        Debug.Log(currentInput);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 'w':
                    if (pacStudent.transform.position.y * 1 - 1 > -14 && pacStudent.transform.position.y * 1 - 1 < 15)
                    {
                        float xCoordinate = pacStudent.transform.position.x;
                        float yCoordinate = pacStudent.transform.position.y + 1;
                        for (int y = 14; y > -15; y--)
                        {
                            for (int x = -13; x < 15; x++)
                            {
                                if (xCoordinate == x && yCoordinate == y)
                                {
                                    Debug.Log("hit");
                                    Debug.Log(xCoordinate + 13);
                                    Debug.Log(yCoordinate * -1 + 14);
                                    if (levelMap[(int)xCoordinate + 13, (int)yCoordinate * 1 + 14] == 5 ||
                                        levelMap[(int)xCoordinate + 13, (int)yCoordinate * 1 + 14] == 6 ||
                                        levelMap[(int)xCoordinate + 13, (int)yCoordinate * 1 + 14] == 0)
                                    {
                                        currentInput = 'w';
                                        Debug.Log(currentInput);
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            
           
        }
    }
}
