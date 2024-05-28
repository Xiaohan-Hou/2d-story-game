using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet flying speed
    private float bulletSpeed = 20.0f;

    //Script communication
    private AppleSoundManager appleSoundManager;

    //Set up particles
    public ParticleSystem orangeParticle;
    public ParticleSystem brownParticle;

    // Start is called before the first frame update
    void Start()
    {
        //Script communication
        appleSoundManager = GameObject.Find("SFXManager").GetComponent<AppleSoundManager>();
    }

    void Update()
    {
        BulletFlying();
        DestoryBulletOutOfBound();
    }

    //Move bullet
    void BulletFlying()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    //Destory the enemies when the bullet is colliding with them
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            //Particle effects
            if(other.name == "Caterpillar_1(Clone)")
            {
                Instantiate(orangeParticle, transform.position, Quaternion.identity);
            }else if(other.name == "Caterpillar_2(Clone)")
            {
                Instantiate(brownParticle, transform.position, Quaternion.identity);
            }

            //Play sound
            appleSoundManager.PlayBulletCollisionSFX();

            //Destroy both the bullet and the target
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    //Destory bullet out of bound
    void DestoryBulletOutOfBound()
    {
        if(transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}
