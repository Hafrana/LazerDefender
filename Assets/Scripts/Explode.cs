using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour 
{
    public ParticleSystem explosion;
 
    public void Explodes( Vector3 position ) 
    {
       Instantiate(explosion, transform.position, Quaternion.identity );
    }
}
