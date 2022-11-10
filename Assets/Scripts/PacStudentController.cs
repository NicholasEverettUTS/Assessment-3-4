using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private Tweener tweener;
    [SerializeField]
    private GameObject pacStudent;
    // Start is called before the first frame update
    void Start()
    {
        tweener = tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x + 100, 0.0f, 0.0f), 3f);
        }

        if (Input.GetKeyDown("s"))
        {

        }

        if (Input.GetKeyDown("a"))
        {

        }

        if (Input.GetKeyDown("w"))
        {

        }
    }
}
