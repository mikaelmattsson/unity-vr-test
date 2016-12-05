using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    float speed = 3f;
    float mapSize = 5f;
    float targetChangeInterval = 1f;
    float shootTimeout = 2f;
    float shootTimer = 2f;

    Vector3 targetDirection;
    ModelTurner turner;
    Transform model;

    public GameObject bulletPrefab;

    void Start()
    {
        model = transform.GetChild(0);

        //Light myLight = GameObject.FindObjectOfType<Light> ();

        //myLight.color = new Color (255f, 0f, 0f);

        turner = new ModelTurner(model);

        ChangeTarget();
        Invoke("ChangeTarget", targetChangeInterval);
    }

    void Update()
    {
        float distThisFrame = speed * Time.deltaTime;

        transform.Translate(targetDirection * distThisFrame);

        turner.TurnTowards(targetDirection, 5f);

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            shootTimer = shootTimeout;
            Shoot();
        }

    }

    void ChangeTarget()
    {
        targetDirection = (getRandomPosition() - transform.localPosition).normalized;
        Invoke("ChangeTarget", targetChangeInterval);
    }

    Vector3 getRandomPosition()
    {
        return new Vector3(Random.Range(-mapSize, mapSize), 0f, Random.Range(-mapSize, mapSize));
    }

    void Shoot()
    {
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().target = player.transform;
    }

}
