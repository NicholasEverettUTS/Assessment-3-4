using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private Tweener tweener;
    [SerializeField]
    private GameObject pacStudent;
    [SerializeField]
    private AudioClip clip1;
    [SerializeField]
    private AudioClip clip2;
    [SerializeField]
    private AudioClip clip3;
    private AudioSource sound;
    private char lastInput;
    private char currentInput;
    bool doMove = false;
    Animator animator;
    private ParticleSystem particles;
    private GameObject particleObject;
    int z = 0;
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
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
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
        tweener = GetComponent<Tweener>();
        pacStudent.GetComponent<Animator>().enabled = false;
        particleObject = pacStudent.transform.GetChild(0).gameObject;
        particles = pacStudent.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        particles.Stop(true);
        sound = pacStudent.GetComponent<AudioSource>();
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
        obstacleCheck(currentInput);
        mover(currentInput);
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
                                if (levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 5 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 6 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 0)
                                {
                                    currentInput = 'd';
                                }
                            }
                        }
                    }
                }
                break;
            case 's':
                if (pacStudent.transform.position.y * 1 - 1 > -14 && pacStudent.transform.position.y * 1 - 1 < 15)
                {
                    float xCoordinate = pacStudent.transform.position.x;
                    float yCoordinate = pacStudent.transform.position.y - 1;
                    for (int y = 14; y > -15; y--)
                    {
                        for (int x = -13; x < 15; x++)
                        {
                            if (xCoordinate == x && yCoordinate == y)
                            {
                                if (levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 5 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 6 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 0)
                                {
                                    currentInput = 's';
                                }

                            }
                        }
                    }
                }
                break;
            case 'a':
                if (pacStudent.transform.position.x + 1 > -13 && pacStudent.transform.position.x + 1 < 15)
                {
                    float xCoordinate = pacStudent.transform.position.x - 1;
                    float yCoordinate = pacStudent.transform.position.y;
                    for (int y = 14; y > -15; y--)
                    {
                        for (int x = -13; x < 14; x++)
                        {
                            if (xCoordinate == x && yCoordinate == y)
                            {
                                if (levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 5 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 6 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 0)
                                {
                                    currentInput = 'a';
                                }
                            }
                        }
                    }
                }
                break;
            case 'w':
                if (pacStudent.transform.position.y * -1 - 1 > -15 && pacStudent.transform.position.y * -1 - 1 < 15)
                {
                    float xCoordinate = pacStudent.transform.position.x;
                    float yCoordinate = pacStudent.transform.position.y + 1;
                    for (int y = 14; y > -15; y--)
                    {
                        for (int x = -13; x < 15; x++)
                        {
                            if (xCoordinate == x && yCoordinate == y)
                            {
                                if (levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 5 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 6 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 0)
                                {
                                    currentInput = 'w';
                                }
                            }
                        }
                    }
                }
                break;
        }

    }
    private void obstacleCheck(char c)
    {
        switch (c)
        {
            case 'd':
                if (pacStudent.transform.position.x + 1 > -13 && pacStudent.transform.position.x + 1 < 15)
                {
                    float xCoordinate = pacStudent.transform.position.x + 1;
                    float yCoordinate = pacStudent.transform.position.y;
                    for (int y = 14; y > -15; y--)
                    {
                        for (int x = -13; x < 15; x++)
                        {
                            if (xCoordinate == x && yCoordinate == y)
                            {
                                if (levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 5 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 6 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 0)
                                {
                                    doMove = true;
                                    pacStudent.GetComponent<Animator>().enabled = true;
                                    pacStudent.GetComponent<Animator>().SetTrigger("RightWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("DownWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("LeftWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("UpWalkTrigger");
                                    particleObject.SetActive(true);
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Play();
                                }
                                else
                                {
                                    doMove = false;
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    pacStudent.GetComponent<Animator>().enabled = false;
                                    particles.Stop(true);
                                }
                            }
                        }
                    }
                }
                break;
            case 's':
                if (pacStudent.transform.position.y * 1 + 1 > -14 && pacStudent.transform.position.y * 1 + 1 < 15)
                {
                    float xCoordinate = pacStudent.transform.position.x;
                    float yCoordinate = pacStudent.transform.position.y - 1;
                    for (int y = 14; y > -15; y--)
                    {
                        for (int x = -13; x < 15; x++)
                        {
                            if (xCoordinate == x && yCoordinate == y)
                            {
                                if (levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 5 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 6 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 0)
                                {
                                    doMove = true;
                                    pacStudent.GetComponent<Animator>().enabled = true;
                                    pacStudent.GetComponent<Animator>().ResetTrigger("RightWalkTrigger");
                                    pacStudent.GetComponent<Animator>().SetTrigger("DownWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("LeftWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("UpWalkTrigger");
                                    particleObject.SetActive(true);
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Play();
                                }
                                else
                                {
                                    doMove = false;
                                    pacStudent.GetComponent<Animator>().enabled = false;
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Stop(true);
                                }
                            }
                        }
                    }
                }
                break;
            case 'a':
                if (pacStudent.transform.position.x - 1 > -14 && pacStudent.transform.position.x - 1 < 14)
                {
                    float xCoordinate = pacStudent.transform.position.x - 1;
                    float yCoordinate = pacStudent.transform.position.y;
                    for (int y = 14; y > -15; y--)
                    {
                        for (int x = -13; x < 15; x++)
                        {
                            if (xCoordinate == x && yCoordinate == y)
                            {
                                if (levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 5 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 6 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 0)
                                {
                                    doMove = true;
                                    pacStudent.GetComponent<Animator>().enabled = true;
                                    pacStudent.GetComponent<Animator>().ResetTrigger("RightWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("DownWalkTrigger");
                                    pacStudent.GetComponent<Animator>().SetTrigger("LeftWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("UpWalkTrigger");
                                    particleObject.SetActive(true);
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Play();
                                }
                                else
                                {
                                    doMove = false;
                                    pacStudent.GetComponent<Animator>().enabled = false;
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Stop(true);
                                }
                            }
                        }
                    }
                }
                break;
            case 'w':
                if (pacStudent.transform.position.y * -1 - 1 > -15 && pacStudent.transform.position.y * -1 - 1 < 15)
                {
                    float xCoordinate = pacStudent.transform.position.x;
                    float yCoordinate = pacStudent.transform.position.y + 1;
                    for (int y = 14; y > -15; y--)
                    {
                        for (int x = -13; x < 15; x++)
                        {
                            if (xCoordinate == x && yCoordinate == y)
                            {

                                if (levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 5 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 6 ||
                                    levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13] == 0)
                                {
                                    doMove = true;
                                    pacStudent.GetComponent<Animator>().enabled = true;
                                    pacStudent.GetComponent<Animator>().ResetTrigger("RightWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("DownWalkTrigger");
                                    pacStudent.GetComponent<Animator>().ResetTrigger("LeftWalkTrigger");
                                    pacStudent.GetComponent<Animator>().SetTrigger("UpWalkTrigger");
                                    particleObject.SetActive(true);
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Play();
                                }
                                else
                                {
                                    doMove = false;
                                    pacStudent.GetComponent<Animator>().enabled = false;
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Stop(true);
                                }
                            }
                        }
                    }
                }
                break;
        }
    }
    private void mover(char c)
    {
        switch (c)
        {
            case 'd':
                if (tweener.TweenExists(pacStudent.transform) == false)
                {
                    if (doMove == true)
                        tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x + 1, pacStudent.transform.position.y, 0.0f), 0.2f);
                }
                break;
            case 's':
                if (tweener.TweenExists(pacStudent.transform) == false)
                {
                    if (doMove == true)
                        tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y - 1, 0.0f), 0.2f);
                }
                break;
            case 'a':
                if (tweener.TweenExists(pacStudent.transform) == false)
                {
                    if (doMove == true)
                        tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x - 1, pacStudent.transform.position.y, 0.0f), 0.2f);
                }
                break;
            case 'w':
                if (tweener.TweenExists(pacStudent.transform) == false)
                {
                    if (doMove == true)
                        tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1, 0.0f), 0.2f);
                }
                break;
        }
    }
    private void audioSwitch(int i)
    {
        if (i == 5 || i == 6)
        {
            sound.enabled = true;
            sound.clip = clip1;
            sound.Play();
        }
        else if (i == 0)
        {
            sound.enabled = true;
            sound.clip = clip2;
            sound.Play();
        }
        else
        {
            StartCoroutine(audioSwitch2());
        }
    }
    private IEnumerator audioSwitch2()
    {
        sound.clip = clip3;
        if (sound.enabled == true && z == 0)
        {
            z++;
            sound.Play();
            yield return new WaitWhile(() => sound.isPlaying);
            sound.enabled = false;
            z = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            doMove = false;
            if (transform.rotation.x == 0)
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
        }
    }
}
