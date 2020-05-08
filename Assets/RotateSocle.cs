using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSocle : MonoBehaviour
{
    public float lastRota;
    public ManagerFirst manager;
    bool active;

    Touch[] touches;
    bool isFirstFrameWithTwoTouches;
    float cachedTouchDistance;
    float cachedTouchAngle;
    Vector3 cachedAugmentationRotation;

    // Start is called before the first frame update
    void Start()
    {
        lastRota = transform.localEulerAngles.y;
        this.cachedAugmentationRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastRota < transform.localEulerAngles.y)
            lastRota = transform.localEulerAngles.y;

        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.Clamp(transform.localEulerAngles.y+0.3f, 180, 359), transform.localEulerAngles.z);
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 0.1f, transform.localEulerAngles.z);

        this.touches = Input.touches;

        if (Input.touchCount == 2)
        {
            float currentTouchDistance = Vector2.Distance(this.touches[0].position, this.touches[1].position);
            float diff_y = this.touches[0].position.y - this.touches[1].position.y;
            float diff_x = this.touches[0].position.x - this.touches[1].position.x;
            float currentTouchAngle = Mathf.Atan2(diff_y, diff_x) * Mathf.Rad2Deg;

            if (this.isFirstFrameWithTwoTouches)
            {
                this.cachedTouchDistance = currentTouchDistance;
                this.cachedTouchAngle = currentTouchAngle;
                this.isFirstFrameWithTwoTouches = false;
            }

            float angleDelta = currentTouchAngle - this.cachedTouchAngle;
            float scaleMultiplier = (currentTouchDistance / this.cachedTouchDistance);

            if(Mathf.Sign(angleDelta) == -1)
                transform.localEulerAngles = this.cachedAugmentationRotation - new Vector3(transform.rotation.x, angleDelta * 2f, transform.rotation.z);
            
        }
        else
        {
            isFirstFrameWithTwoTouches = true;
            this.cachedAugmentationRotation = transform.localEulerAngles;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.Clamp(transform.localEulerAngles.y, lastRota, 359), transform.localEulerAngles.z);
        if (transform.localEulerAngles.y <= 359 && transform.localEulerAngles.y >= 357 && !active)
        {
            active = true;
            GetComponentInChildren<Animation>().Play();
            //manager.targets.Add(gameObject);
            Invoke("ManagerAdd", 3.3f);
        }
    }

    void ManagerAdd()
    {
        manager.targets.Add(gameObject);
    }
}
