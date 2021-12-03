using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public int scrollingSpeed = 10;
    public Camera mainCamera;
    public bool toggleDebug;

    private float topOfScroller;
    private float bottomOfScroller;
    // Start is called before the first frame update
    void Start()
    {
        topOfScroller = transform.position.y;
        bottomOfScroller = transform.position.y;
        Bounds bnds;
        float buffMin, buffMax;
        foreach (Transform child in transform)
        {
            bnds = child.gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
            buffMax = child.transform.position.y + bnds.max.y;
            buffMin = child.transform.position.y + bnds.min.y;
            if (buffMax > topOfScroller)
                topOfScroller = buffMax;
            if (buffMin < bottomOfScroller)
                bottomOfScroller = buffMin;
        }
        topOfScroller -= transform.position.y;
        bottomOfScroller -= transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        if (transform.position.y + topOfScroller < mainCamera.transform.position.y - mainCamera.orthographicSize)
        {
            Debug.Log(transform.position + " " + topOfScroller * 4);
            transform.position += transform.up * topOfScroller * 4;
        }
        if (transform.position.y + bottomOfScroller < mainCamera.transform.position.y + mainCamera.orthographicSize)
        {
        }
        transform.position -= transform.up * scrollingSpeed * Time.deltaTime;
    }
}
