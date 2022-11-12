using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    //private Tween activeTween;
    private List<Tween> activeTweens = new List<Tween>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeTweens != null)
        {
            for (int i = 0; i < activeTweens.Count; i++)
            {
                float distance = Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos);
                float timePassed = Time.time - activeTweens[i].StartTime;
                if (distance > 0.1f)
                {
                    float thisTime = timePassed / activeTweens[i].Duration;
                    activeTweens[i].Target.position = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, thisTime);
                }
                else if (distance <= 0.1f)
                {
                    activeTweens[i].Target.position = activeTweens[i].EndPos;
                    activeTweens.RemoveAt(i);
                }
            }
        }
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (TweenExists(targetObject) == false)
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        return false;
    }

    public bool TweenExists(Transform target)
    {
        for (int i = 0; i < activeTweens.Count; i++)
        {
            Transform tweenTarget = activeTweens[i].Target;
            if (tweenTarget == target)
            {
                return true;
            }
        }
        return false;
    }
}
