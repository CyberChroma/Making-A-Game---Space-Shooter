using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float respawnTime;
    public bool active = true;
    public GameObject playerExplosion;

    private GameObject playerObject;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;
    private GameObject shield;
    private Transform explosionsParent;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = transform.Find("Player Ship").gameObject;
        playerMove = GetComponent<PlayerMove>();
        playerShoot = GetComponent<PlayerShoot>();
        shield = transform.Find("Shield").gameObject;
        shield.SetActive(false);
        explosionsParent = GameObject.Find("Particle Systems").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Enemy Shot"))
        {
            if (shield.activeInHierarchy)
            {
                shield.SetActive(false);
            }
            else if (active)
            {
                playerObject.SetActive(false);
                playerMove.enabled = false;
                playerShoot.enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                Instantiate(playerExplosion, transform.position, transform.rotation, explosionsParent);
                StartCoroutine(WaitToRestart());
            }
        } else if (other.CompareTag("Shield Pickup"))
        {
            shield.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    IEnumerator WaitToRestart ()
    {
        FindObjectOfType<GameManager>().isFading = false;
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
