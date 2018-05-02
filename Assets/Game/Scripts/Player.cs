using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private CharacterController _controller;
	[SerializeField]
	private float _speed = 3.5f;
	private float _gravity = 9.81f;
	[SerializeField]
	private GameObject _muzzleFlash;
	[SerializeField]
	private GameObject _hitMarkerPreFab;
	[SerializeField]
	private AudioSource _weaponAudio;
	[SerializeField]
	private int currentAmmo;
	private int maxAmmo = 50;
	private bool _isReloading = false;
	private UIManager _uiManager;
	public bool hasCoin = false;
	[SerializeField]
	private GameObject _weapons;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		_controller = GetComponent<CharacterController>();
		currentAmmo = maxAmmo;
		_weapons.SetActive(false);
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && currentAmmo >0){
			Shoot();
		}
		else{
			_muzzleFlash.SetActive(false);
			_weaponAudio.Stop();
			
		}

		if (Input.GetKeyDown(KeyCode.R) && _isReloading == false){
			_isReloading = true;
			StartCoroutine(GunReloadRoutine());
		}	
		if (Input.GetKeyDown(KeyCode.Escape)){
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		CalculateMovement();
	}

	public IEnumerator GunReloadRoutine(){		
		yield return new WaitForSeconds(1.5f);	
		currentAmmo = maxAmmo;	
		_isReloading = false;
		_uiManager.UpdateAmmo(currentAmmo);
	}


	void Shoot(){
		_muzzleFlash.SetActive(true);
			currentAmmo--;
			_uiManager.UpdateAmmo(currentAmmo);
			if (_weaponAudio.isPlaying == false){
				_weaponAudio.Play();
			}
			Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hitInfo;

			if (Physics.Raycast(rayOrigin, out hitInfo)){
				Debug.Log("Hit : " + hitInfo.transform.name);
				GameObject hitMarker = Instantiate(_hitMarkerPreFab, hitInfo.point,
					Quaternion.LookRotation(hitInfo.normal));
				Destroy(hitMarker, 1f);

				Destructible Crate = hitInfo.transform.GetComponent<Destructible>();
				if (Crate != null){
					Crate.DestroyCrate();
				}	

			}
	}
	void CalculateMovement(){
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
		Vector3 velocity = direction * _speed;
		velocity.y -= _gravity;

		velocity = transform.transform.TransformDirection(velocity);
		_controller.Move(velocity * Time.deltaTime);
	}

	public void EnableWeapons(){
		_weapons.SetActive(true);
	}
}
