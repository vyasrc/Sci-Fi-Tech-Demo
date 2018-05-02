using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]
	private Text _ammoText;
	[SerializeField]
	private Image _coin;

	void Start(){
		HideCoin();
	}

	public void UpdateAmmo(int count){
		_ammoText.text = "Ammo :" + count;
	}

	public void HideCoin(){
		_coin.enabled =false;
	}

	public void ShowCoin(){
		_coin.enabled = true ;
	}
}


