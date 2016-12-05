using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public Transform target;

    float speed = 2.5f;

    // Use this for initialization
    void Start()
    {
        Vector3 dir = (target.localPosition - transform.localPosition).normalized;

        transform.rotation = Quaternion.LookRotation(dir);

        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
