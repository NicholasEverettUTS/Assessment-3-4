using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
            float timePassed = Time.time - activeTween.StartTime;
            if (distance > 0.1f)
            {
                float thisTime = timePassed / activeTween.Duration;
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, thisTime);
            }
            else if (distance <= 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }
        }
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (TweenExists(targetObject) == false)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            return true;
        }
        return false;
    }

    public bool TweenExists(Transform target)
    {
        Transform tweenTarget = activeTween.Target;
        if (tweenTarget == target)
        {
            return true;
        }
        return false;
    }
}
