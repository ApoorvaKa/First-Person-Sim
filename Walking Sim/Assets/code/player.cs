using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Text scoreOut;
    int score = 0;
    public AudioClip coinSnd;
    public AudioClip bulletSnd;
    AudioSource _audioSource;
    public GameObject bulletPrefab;
    public Transform spawnPos;
    int bulletForce = 800;
    public LayerMask targetLayer;
    void Start(){
        _audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        if (Input.GetButtonDown("Fire1")){
            
            _audioSource.PlayOneShot(bulletSnd);
            // Raycast Version of the Shooting
            // RaycastHit hit;
            // if (Physics.Raycast(spawnPos.position, spawnPos.transform.forward, out hit, Mathf.Infinity, targetLayer)){
            //     if(hit.collider.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb)){
            //         rb.AddForce(spawnPos.transform.forward * bulletForce);
            //     }
            // }
            

            // Instantiation version of the shooting
            GameObject newBullet = Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPos.transform.forward * bulletForce);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Coin")){
            score++;
            scoreOut.text = score.ToString();
            _audioSource.PlayOneShot(coinSnd);
            Destroy(other.gameObject);
        }
    }
}
