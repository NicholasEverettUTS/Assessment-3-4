using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherry;
    private Tweener tweener;
    private GameObject thisCherry;
    int rand;
    int rand2;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(generator());
    }

    IEnumerator generator()
    {
        yield return new WaitForSeconds(10);
        rand = Random.Range(-50, 50);
        rand2 = Random.Range(0, 1);
        if (rand2 == 1)
        {
            num = rand * -1;
        }

        thisCherry = Instantiate(cherry, new Vector3(rand, num, 0.0f), Quaternion.identity);
        while(thisCherry.transform.position.x != rand*-1)
            tweener.AddTween(thisCherry.transform, thisCherry.transform.position, new Vector3(rand*-1, num*-1, 0.0f), 5f);
        Destroy(thisCherry);
    }
}
