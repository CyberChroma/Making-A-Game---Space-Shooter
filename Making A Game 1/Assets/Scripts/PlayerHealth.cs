using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float respawnTime;
    public bool active = true;

    private GameObject playerObject;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;
    private GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = transform.Find("Player Ship").gameObject;
        playerMove = GetComponent<PlayerMove>();
        playerShoot = GetComponent<PlayerShoot>();
        shield = transform.Find("Shield").gameObject;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Enemy Shot"))
        {
            if (shield.activeInHierarchy)
            {
                shield.SetActive(false);
                Destroy(other.gameObject);
            }
            else if (active)
            {
                playerObject.SetActive(false);
                playerMove.enabled = false;
                playerShoot.enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                Destroy(other.gameObject);
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
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
