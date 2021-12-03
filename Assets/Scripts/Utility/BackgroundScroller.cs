using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public int scrollingSpeed = 10;
    public Camera mainCamera;
    public bool toggleDebug;

    private float scrollWidth;
    // Start is called before the first frame update
    void Start()
    {
        scrollWidth = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * 2;
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        if (transform.position.y + scrollWidth < mainCamera.transform.position.y - mainCamera.orthographicSize)
            transform.position += transform.up * scrollWidth * 4;
        transform.position -= transform.up * scrollingSpeed * Time.deltaTime;
    }
}
