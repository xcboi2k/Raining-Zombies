using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	private Rigidbody2D myBody;
	private Animator anim;

	public float moveForce = 20f, maxVelocity = 4f;
	private bool grounded;
	public bool isAlive;
	public int playerScore;

	public AudioSource playerAudioSource;
    public AudioClip machineGunClip;

	public GameObject bulletPrefab;
	public GameObject bulletHolder;

	public Text finalScoreText;

	void Awake() {
		InitializeVariables();
		isAlive = true;
		playerScore = 0;
	}

	void FixedUpdate () {
		if(isAlive == true){
			PlayerWalkKeyboard();
			fireMachineGun();
		}
		
	}

	void InitializeVariables() {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}


	void PlayerWalkKeyboard() {

		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {

			if (vel < maxVelocity) {
				if(grounded) {
					forceX = moveForce;
				} else {
					forceX = moveForce * 1.1f;
				}
			}

			Vector3 scale = transform.localScale;
			scale.x = 0.6f;
			transform.localScale = scale;

			anim.SetBool ("Walk", true);

		} else if (h < 0) {

			if (vel < maxVelocity) {
				if(grounded) {
					forceX = -moveForce;
				} else {
					forceX = -moveForce * 1.1f;
				}
			}
			
			Vector3 scale = transform.localScale;
			scale.x = -0.6f;
			transform.localScale = scale;
			
			anim.SetBool ("Walk", true);

		} else if (h == 0) {
			anim.SetBool ("Walk", false);
		}

		myBody.AddForce (new Vector2(forceX, forceY));
		Debug.Log("PLAYER MOVING");
	}

	private void fireMachineGun(){
		Vector2 shootingDirection = new Vector2(0,5);

        if(Input.GetButtonDown("Jump")){ //Fire1, Jump
            GameObject bullet = Instantiate(bulletPrefab, bulletHolder.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * 10.0f;
			playerAudioSource.PlayOneShot(machineGunClip);

            Destroy(bullet, 2.0f);
            Debug.Log("MACHINE GUN FIRING");
        }
	}

	void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Enemy"){
            //playerAudioSource.PlayOneShot(hitClip);
            Debug.Log("HIT BY AN ENEMY");

            finalScoreText.text = "" + playerScore;
            
            Destroy(target.gameObject);
            SelfDestruct();

            //GameObject.Find("Gameplay Controller").GetComponent<AudioScript>().isAlive = false;
            GameObject.Find("Gameplay Controller").GetComponent<GameOverPanelScript>().gameOverPanel.SetActive(true);
        }    
    }

    private void SelfDestruct(){
        //playerAnim.SetTrigger("Dead");
        //playerAudioSource.PlayOneShot(explodeClip);
        isAlive = false;
        GameObject.Find("Spawn Generator").GetComponent<SpawnControllerScript>().spawnAllowed = false;
		Destroy(gameObject);
    }
}
