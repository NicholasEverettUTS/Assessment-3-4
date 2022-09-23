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
        if (thisTransform.position.x == -12.0f) //&& thisTransform.position.x == 13.0f
        {
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-7.0f, 13.0f, 0.0f), 1.0f);
        }
    }
}
