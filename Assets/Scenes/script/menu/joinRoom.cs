using Photon.Pun;
using Photon.Realtime;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class joinRoom : MonoBehaviour
{
    public Network network;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        network.Connection();
    }

}