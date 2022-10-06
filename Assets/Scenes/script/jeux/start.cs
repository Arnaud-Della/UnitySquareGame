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
    private PhotonView photonView;
    void Start()
    {
        photonView = PhotonView.Get(this);
        CreateCube();
        //Cube =Instantiate(Cube,new Vector3(-8,0,0),Quaternion.identity);
        //Cube.GetComponent<SpriteRenderer>().color = new Color((float)((float)Random.Range(0, 100)/100), (float)((float)Random.Range(0, 100) / 100), (float)((float)Random.Range(0, 100) / 100), 1);
    }

    void CreateCube()
    {
        ListCube.Add(Instantiate(Cube, new Vector3(-8, 0, 0), Quaternion.identity));
        photonView.RPC("CreateCubeSync", RpcTarget.All,ListCube[ListCube.Count - 1].GetPhotonView().ViewID);
        
    }

    [PunRPC]
    public void CreateCubeSync(int ID)
    {
        Debug.Log("Voici le View ID : " + ID);
        GameObject cube = Instantiate(Cube, new Vector3(-8, 0, 0), Quaternion.identity);
        cube.GetPhotonView().ViewID = ID;
        ListCube.Add(cube);
    }

}
