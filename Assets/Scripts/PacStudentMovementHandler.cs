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
        tweener = tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform thisTransform = pacStudent.transform;
        if (thisTransform.position.x == -12.0f && thisTransform.position.y == 13.0f)
        {
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-7.0f, 13.0f, 0.0f), 1.0f);
        }
        if (thisTransform.position.x == -7.0f && thisTransform.position.y == 13.0f)
        {
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-7.0f, 9.0f, 0.0f), 1.0f);
        }
        if (thisTransform.position.x == -7.0f && thisTransform.position.y == 9.0f)
        {
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-12.0f, 9.0f, 0.0f), 1.0f);
        }
        if (thisTransform.position.x == -12.0f && thisTransform.position.y == 9.0f)
        {
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-12.0f, 13.0f, 0.0f), 1.0f);
        }

    }
}
