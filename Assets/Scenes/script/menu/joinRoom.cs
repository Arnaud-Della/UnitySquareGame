using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class joinRoom : MonoBehaviour
{
    public Network network;
    public TMP_InputField name;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        network.Connection(name.text);
    }

}