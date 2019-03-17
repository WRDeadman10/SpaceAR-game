using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclarationManager : MonoBehaviour
{
    public static DeclarationManager isn { set; get; }
    public Transform CrossHair_tra;
    public ParticleSystem HitParticleEffect;
    public GameObject EnemyPlane;
    public List<Transform> Enemypos;
    // Start is called before the first frame update
    void Awake()
    {
        isn = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
