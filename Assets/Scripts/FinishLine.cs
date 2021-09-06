using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
        GameObject spawner;
        GameObject player;
 [SerializeField]   LevelManager levelManager;
 public ParticleSystem confitti;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        player = GameObject.FindGameObjectWithTag("Player");
        confitti = GetComponentInChildren<ParticleSystem>();
        levelManager.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().FinishLine();
            confitti.Play();
            
            Destroy(spawner);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
            StartCoroutine("LoadLevelAfterDelay");
        }

        if (other.gameObject.tag == "Enemy")
        {
            player.GetComponent<PlayerMovement>().Fall();


        }


    }
    IEnumerator LoadLevelAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        levelManager.LevelLoad();
    }
}
