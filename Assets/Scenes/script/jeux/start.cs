using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> ListCube = new List<GameObject>();
    public GameObject Cube;
    private Network network;
    void Start()
    {

        network = GetComponent<Network>();
        CreateCube();
        //Cube =Instantiate(Cube,new Vector3(-8,0,0),Quaternion.identity);
        //Cube.GetComponent<SpriteRenderer>().color = new Color((float)((float)Random.Range(0, 100)/100), (float)((float)Random.Range(0, 100) / 100), (float)((float)Random.Range(0, 100) / 100), 1);
    }

    void CreateCube()
    {
        ListCube.Add(Instantiate(Cube, new Vector3(-8, 0, 0), Quaternion.identity));
        Debug.Log(ListCube[ListCube.Count - 1]);
        network.photonView.RPC("CreateCubeSync", RpcTarget.All,ListCube[ListCube.Count - 1]);
        
    }

    [PunRPC]
    public void CreateCubeSync(GameObject cube)
    {
        ListCube.Add(cube);
    }

}
