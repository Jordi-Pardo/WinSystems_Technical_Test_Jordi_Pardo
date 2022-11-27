using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer figure;
    Vector3 nextPos;
    Vector3 nextPosition = Vector3.zero;
    public void Setup(Sprite sprite)
    {
        figure.sprite = sprite;
        nextPos = transform.localPosition - new Vector3(0, 2.2f + figure.bounds.size.y, 0);
        nextPosition = transform.localPosition;
    }

    public void UpdateMe(float speed, bool wantsToStop)
    {

    }
    public void StartScroll()
    {
        StartCoroutine(ScrollCO());
    }

    private IEnumerator ScrollCO()
    {
        float current = 0;
        float target = 1;
        float delta = 0;
        while (delta < target)
        {
            delta = Mathf.MoveTowards(current, target, Time.deltaTime);
            transform.localPosition = Vector3.Lerp(nextPosition, nextPos, delta);
            yield return null;
        }
    }
}
