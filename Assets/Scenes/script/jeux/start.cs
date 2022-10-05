using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Cube;
    void Start()
    {
        Cube=Instantiate(Cube,new Vector3(-8,0,0),Quaternion.identity);
        Cube.GetComponent<SpriteRenderer>().color = new Color((float)((float)Random.Range(0, 100)/100), (float)((float)Random.Range(0, 100) / 100), (float)((float)Random.Range(0, 100) / 100), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
