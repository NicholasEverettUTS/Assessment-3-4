using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CherryController : MonoBehaviour
{
    public GameObject cherry;
    private Tweener tweener;
    private GameObject thisCherry;
    int rand;
    int rand2;
    int num;
    double radius = 20;
    bool generation = false;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if(generation == false)
            StartCoroutine(generator());
    }

    IEnumerator generator()
    {
        generation = true;
        yield return new WaitForSeconds(10);
        rand = UnityEngine.Random.Range(-20, 20);
        num = (int)Mathf.Sqrt((float)(radius * radius) - (float)(rand * rand));
        rand2 = UnityEngine.Random.Range(0, 2);
        if (rand2 == 1)
        {
            num = num * -1;
        }

        thisCherry = Instantiate(cherry, new Vector3(rand, num, 0.0f), Quaternion.identity);


        tweener.AddTween(thisCherry.transform, thisCherry.transform.position, new Vector3(rand*-1, num*-1, 0.0f), 10f);
        yield return new WaitUntil(() => tweener.TweenExists(thisCherry.transform) == false);
        Destroy(thisCherry);
        generation = false;
    }
}
