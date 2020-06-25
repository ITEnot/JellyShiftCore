using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public Vector3 installPos;

    public Vector2 startPos;
    public Vector2 direction;
    public Vector2 sizeConstraints;

    public Vector3 maxScale;
    public Vector3 minScale;

    private float yRange;

    public WaypointsFree.WaypointsTraveler traveler;
    public GameObject loseText;

    private void Start()
    {
        yRange = Math.Abs(sizeConstraints[1]) + Math.Abs(sizeConstraints[0]);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    startPos = touch.position;
                    calculateSize(direction.y);
                    break;
            }
        }

    }

    public void calculateSize(float y)
    {
            float sizePercent = y / yRange;
          
            if (transform.localScale.y >= minScale.y && transform.localScale.y <= maxScale.y)
            {
                float newY = transform.localScale.y + transform.localScale.y * sizePercent;
                float newX = (float)Math.Cos(newY) + 1.5f ;

                if (newY < minScale.y)
                    newY = minScale.y;

                if (newY > maxScale.y)
                    newY = maxScale.y;
                transform.localScale = new Vector3(newX, newY, transform.localScale.z);
            }

        transform.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localScale.y * 0.5f,
                transform.localPosition.z
                );
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        traveler.enabled = false;
        loseText.SetActive(true);
    }

    public void Restart()
    {
        loseText.SetActive(false);
        traveler.ResetTraveler();
        traveler.enabled = true;
      
    }
}
