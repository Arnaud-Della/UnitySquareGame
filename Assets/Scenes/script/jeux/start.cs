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
        photonView.RPC("CreateCubeSync", RpcTarget.Others);
    }

    private void CreateCube()
    {
        GameObject myCube = Instantiate(Cube, new Vector3(-8, 0, 0), Quaternion.identity);
        PhotonView myCubePhotonView = myCube.GetComponent<PhotonView>();
        PhotonNetwork.AllocateViewID(myCubePhotonView);
    }

    [PunRPC]
    protected virtual void CreateCubeSync()
    {
        CreateCube();
    }

}
