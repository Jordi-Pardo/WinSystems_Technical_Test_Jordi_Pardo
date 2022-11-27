using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image figure;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform= GetComponent<RectTransform>();
    }
    public void Setup(Sprite sprite)
    {
        figure.sprite = sprite;
    }

    private void Update()
    {
        //Debug.Log($"Local position: {transform.localPosition}. World Position: {transform.position}");
        //Debug.Log($"Rect local position: {rectTransform.localPosition}. Rect World Position: {rectTransform.position}");
    }
    public void UpdateMe()
    {
        float speed = 200f;
        rectTransform.anchoredPosition -= speed * Time.deltaTime * new Vector2(0, 1);

    }
}
