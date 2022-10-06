using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bouge : MonoBehaviour
{
    // Start is called before the first frame update
    private PhotonView photonView;
    void Start()
    {
        photonView = PhotonView.Get(this);
        if (this.photonView != null && !this.photonView.IsMine)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position = new Vector2(transform.position.x + 1 * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector2(transform.position.x - 1 * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position = new Vector2(transform.position.x , transform.position.y + 10 * Time.deltaTime);
        }

    }
}
