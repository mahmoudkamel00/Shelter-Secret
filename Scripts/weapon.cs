using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public int damage = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            shoot();
        }
    }
    void shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firepoint.position, firepoint.right);
        if (hitInfo)
        {
            enemies zombie = hitInfo.transform.GetComponent<enemies>();
            if(zombie != null)
            {
                zombie.takeDamage(damage);
            }
        }
    }
}
