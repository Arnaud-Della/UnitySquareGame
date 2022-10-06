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
        int ID = CreateCube();
        photonView = PhotonView.Get(this);
        photonView.RPC("CreateCubeSync", RpcTarget.Others,ID);
    }

    private int CreateCube(int ID=0)
    {
        if (ID > 0)
        {
            GameObject myCube = Instantiate(Cube, new Vector3(-8, 0, 0), Quaternion.identity);
            PhotonView myCubePhotonView = myCube.GetComponent<PhotonView>();
            myCubePhotonView.ViewID = ID;
        }
        else
        {
            GameObject myCube = Instantiate(Cube, new Vector3(-8, 0, 0), Quaternion.identity);
            PhotonView myCubePhotonView = myCube.GetComponent<PhotonView>();
            PhotonNetwork.AllocateViewID(myCubePhotonView);
            ID = myCubePhotonView.ViewID;

        }
        return ID;
    }

    [PunRPC]
    protected virtual void CreateCubeSync(int ID)
    {
        CreateCube(ID);
    }

}
