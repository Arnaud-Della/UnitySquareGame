using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SendGame : MonoBehaviour
{
    // Start is called before the first frame update
    private Network network;
    void Start()
    {
        network = FindObjectOfType<Network>();
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        network.photonView.RPC("startGame", Photon.Pun.RpcTarget.All);
    }
}
