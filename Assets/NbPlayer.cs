using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class NbPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Network network;
    void Start()
    {
        network = FindObjectOfType<Network>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = network.GetNbPlayer().ToString();
    }
}
