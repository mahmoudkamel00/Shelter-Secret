using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameralvl3 : MonoBehaviour
{

    public float CameraSpeed = 3f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > -11 && target.position.x < 45) 
        {
            if (target.position.y < 14 && target.position.y > -13) {

                Vector3 newpos = new Vector3(target.position.x, target.position.y, -10f);
                transform.position = Vector3.Slerp(transform.position, newpos, CameraSpeed * Time.deltaTime);
           }
        }
    }
}
