using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeBall : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    float throwForceinXY = 1f;

    [SerializeField]
    float throwForceinZ = 50f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // touch screen 
        if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)
        {

            touchTimeStart = Time.time;

           
            startPos = Input.GetTouch(0).position;
        }
        // if your finger is release
        if (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
           // marking time when you release it
            touchTimeFinish = Time.time;
           
            //calculate swipe time interval

            timeInterval = touchTimeFinish - touchTimeStart;

            //getting release finger position

            endPos = Input.GetTouch(0).position;
            // calculating swipe direciton in 2d space

            direction = startPos - endPos;
            // add force to balls rigidbody in 3d space depending on swap time , direction  and throw forces
            rb.isKinematic = false;
            rb.AddForce(-direction.x * throwForceinXY, -direction.y * throwForceinXY, throwForceinZ / timeInterval);
         
            //ball in 4 sec. destroy
            Destroy(gameObject, 4f);
        
        }
    }
}
