using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovementHandler : MonoBehaviour
{
    private Tweener tweener;
    [SerializeField]
    private GameObject pacStudent;


    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform thisTransform = pacStudent.transform;
        if (thisTransform.position.x == -10f && thisTransform.position.y == 3f)
        {
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(10f, 3f, 0.0f), 3f);
        }
        if (thisTransform.position.x == 10f && thisTransform.position.y == 3f)
        {   
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(10f, -3f, 0.0f), 2f);
        }
        if (thisTransform.position.x == 10f && thisTransform.position.y == -3f)
        {
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-10f, -3f, 0.0f), 3f);
        }
        if (thisTransform.position.x == -10f && thisTransform.position.y == -3f)
        {   
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-10f, 3f, 0.0f), 2f);
        }

    }
}
