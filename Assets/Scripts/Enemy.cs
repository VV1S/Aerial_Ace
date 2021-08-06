using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject death;
    [SerializeField] Transform parent;
    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx=Instantiate(death, transform.position,Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
        
    }
}
