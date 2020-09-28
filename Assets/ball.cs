using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class ball : MonoBehaviour, IPunObservable {

     Vector3 syncPos = Vector3.zero;
    Quaternion syncRot = Quaternion.identity;
    Rigidbody2D rb;
	Vector2 vel;
	private PhotonView photonView;
	private float pos = 6f;
	private float rot = 0.3f;
	
	 void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		photonView = GetComponent<PhotonView>();
		
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
			stream.SendNext(rb.velocity);
            
        }
        else
        {
            syncPos = (Vector3)stream.ReceiveNext();
            syncRot = (Quaternion)stream.ReceiveNext();
			vel = (Vector2)stream.ReceiveNext();
           float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.timestamp));
			rb.position +=rb.velocity * lag;

            
        }
    }

      public void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
         //  transform.position = Vector3.MoveTowards(transform.position, syncPos, pos * Time.deltaTime);
		   transform.localPosition = Vector3.Lerp(transform.position, syncPos, 0.2f);
			transform.localRotation = Quaternion.Lerp(transform.rotation, syncRot, rot); 
			rb.velocity = vel;
        }
    }
}
