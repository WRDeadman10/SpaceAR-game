using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private RaycastHit hit1;
    private bool Toggle;
    private List<DetectedPlane> m_AllPlanes = new List<DetectedPlane>();

    // Start is called before the first frame update
    void Start()
    {
    }

    public void InsPlanes(TrackableHit hit)
    {
        // Choose the Andy model for the Trackable that got hit.
        for (int i = 0; i < 4; i++)
        {
            GameObject prefab;
            prefab = DeclarationManager.isn.EnemyPlane;

            // Instantiate Andy model at the hit pose.
            var EnemyPlane = Instantiate(prefab, DeclarationManager.isn.Enemypos[i].position, Quaternion.identity);

            // Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
            EnemyPlane.transform.Rotate(0, 180, 0, Space.Self);

            // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
            // world evolves.
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

            // Make Andy model a child of the anchor.
            EnemyPlane.transform.parent = anchor.transform;
        }


        // Update is called once per frame

        if (Input.GetMouseButtonDown(0) && !Toggle)
        {
            // Perform Muzzle Flash
            DORayCast();
        }
        if (Toggle)
        {
            DORayCast();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Toggle = !Toggle;
        }

    }
   
    void DORayCast()
    {
        if (Physics.Raycast(DeclarationManager.isn.CrossHair_tra.transform.position, DeclarationManager.isn.CrossHair_tra.TransformDirection(Vector3.forward), out hit1, Mathf.Infinity))
        {
            //var main =HitParticleEffect.main;
            GameObject go = Instantiate(DeclarationManager.isn.HitParticleEffect.gameObject);
            go.transform.position = hit1.point;
            //Deal Damage To Object 
        }
    }
}
