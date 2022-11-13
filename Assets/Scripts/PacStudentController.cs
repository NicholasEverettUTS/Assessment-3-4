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
    //private ParticleSystem hitWall;
    private ParticleSystem deathPartciles;
    private GameObject particleObject;
    //private GameObject hitWallObject;
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
        particles = pacStudent.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        particles.Stop(true);
        //hitWall.Stop(true);
        tweener = GetComponent<Tweener>();
        pacStudent.GetComponent<Animator>().enabled = false;
        particleObject = pacStudent.transform.GetChild(0).gameObject;
        //hitWallObject = pacStudent.transform.GetChild(1).gameObject;
       // hitWallObject.SetActive(false);
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
        //hitWall.Stop(true);
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
                                    //doMoveCheck();
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    pacStudent.GetComponent<Animator>().enabled = false;
                                    particles.Stop(true);
                                    //hitWall.Play();
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
                                    //hitWallObject.SetActive(true);
                                    particles.Play();
                                }
                                else
                                {
                                    doMove = false;
                                    //doMoveCheck();
                                    pacStudent.GetComponent<Animator>().enabled = false;
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Stop(true);
                                    //hitWallObject.SetActive(true);
                                    //hitWall.Play();
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
                                    //doMoveCheck();
                                    pacStudent.GetComponent<Animator>().enabled = false;
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Stop(true);
                                    //hitWallObject.SetActive(true);
                                    //hitWall.Play();
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
                                    //doMoveCheck();
                                    pacStudent.GetComponent<Animator>().enabled = false;
                                    audioSwitch(levelMap[(int)yCoordinate * -1 + 14, (int)xCoordinate + 13]);
                                    particles.Stop(true);
                                    //hitWallObject.SetActive(true);
                                    //hitWall.Play();
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

    //private void doMoveCheck()
    //{
        //doMove = false;
        //Debug.Log("hit");
        //hitWall.Play();
        //if (doMove == false)
        //{
            //hitWall.Stop(false);
            //will play und and partciles regardless of whether or not a collision has occured (with my current design,
            //collisions with walls should be impossible.
            //audioSwitch(4);
            //hitWall.Play();
            //hitWall.Stop(true);
        //}

    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit");
        if (other.gameObject.tag == "wall")
        {
            //doMove = false;
            Debug.Log("hit");

            switch (currentInput)
            {
                case 'd':
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
                    break;
                case 's':
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
                    break;
                case 'a':
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
                    break;
                case 'w':
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
                    break;
            }
            //doMoveCheck();
        }

        if (other.gameObject.tag == "teleport")
        {
            Debug.Log("hit");
            this.transform.position = new Vector3(14f, 0f, 0f);
        }
        else if (other.gameObject.tag == "teleport2")
            this.transform.position = new Vector3(-13f, 0f, 0f);
    }
}
