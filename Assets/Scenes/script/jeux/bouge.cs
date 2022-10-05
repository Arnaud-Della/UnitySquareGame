using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position = new Vector2(transform.position.x + 1 * Time.deltaTime, transform.position.y);

        }
    }
}
