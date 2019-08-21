using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour
{

    public Rigidbody prefabBomb;
    public float forwardForce = -350;
    public float destroyAfter = 4f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instanceBullet = Instantiate(prefabBomb, transform.position, transform.rotation) as Rigidbody;
            //Rigidbody instanceBullet = Instantiate(prefabBomb) as Rigidbody;
            
            //ignore the collision with the firing object
            //Physics.IgnoreCollision(instanceBullet.collider, instanceBullet.GetComponentInParent(typeof(Collider)).collider);

            instanceBullet.GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);

            Destroy(instanceBullet.gameObject, destroyAfter);
        }
    }
}
