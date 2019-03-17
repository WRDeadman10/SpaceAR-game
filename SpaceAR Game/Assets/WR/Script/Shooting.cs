using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private RaycastHit hit;
    private DeclarationManager DM;
    // Start is called before the first frame update
    void Start()
    {
        DM = DeclarationManager.isn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Perform Muzzle Flash
            DORayCast();
        }
    }

    void DORayCast()
    {
        if( Physics.Raycast(DM.CrossHair_tra.transform.position, DM.CrossHair_tra.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            //var main =HitParticleEffect.main;
            GameObject go = Instantiate(DM.HitParticleEffect.gameObject);
            go.transform.position = hit.point;
            //Deal Damage To Object 
        }
    }
}
