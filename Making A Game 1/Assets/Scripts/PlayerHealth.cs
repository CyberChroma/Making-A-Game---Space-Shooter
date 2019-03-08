using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float respawnTime;

    private GameObject playerObject;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = transform.Find("Player Object").gameObject;
        playerMove = GetComponent<PlayerMove>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            playerObject.SetActive(false);
            playerMove.enabled = false;
            playerShoot.enabled = false;
            Destroy(other.gameObject);
            StartCoroutine(WaitToRestart());
        }
    }

    IEnumerator WaitToRestart ()
    {
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
