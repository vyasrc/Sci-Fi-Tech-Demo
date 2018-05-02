using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {

	[SerializeField]
	private AudioClip _weaponPickup;
	private UIManager _uiManager;

	// Use this for initialization
	void Start () {
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	private void OnTriggerStay(Collider other){
		if (other.tag == "Player"){
			if (Input.GetKeyDown(KeyCode.E)){
				Player player = other.GetComponent<Player>();
				if (player != null){
					if (player.hasCoin == true){
						player.hasCoin = false;
						_uiManager.HideCoin();
						AudioSource.PlayClipAtPoint(_weaponPickup,
							Camera.main.transform.position, 1f);
						player.EnableWeapons();
					}
					else{
						Debug.Log("Get Out Of Here!!");
					}
				}
			}	
		}	
	}

}
