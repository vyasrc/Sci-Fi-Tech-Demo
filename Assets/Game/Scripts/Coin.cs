﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	[SerializeField]
	private AudioClip _coinPickup;
	private UIManager _uiManager;

	void Start(){
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	private void OnTriggerStay(Collider other){
		if (other.tag == "Player"){
			if (Input.GetKeyDown(KeyCode.E)){
				Player player = other.GetComponent<Player>();
				if (player != null){
					player.hasCoin = true;
					_uiManager.ShowCoin();
					AudioSource.PlayClipAtPoint(_coinPickup, Camera.main.transform.position, 1f);
					Destroy(this.gameObject);
				}
			}	
		}	
	}
}
