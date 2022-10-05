using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Cube;
    public GameObject Sol;
    void Start()
    {
        Instantiate(Cube,new Vector3(-8,0,0),Quaternion.identity);
        Sol.GetComponent<SpriteRenderer>().color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
