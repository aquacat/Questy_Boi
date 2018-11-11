using UnityEngine;

using System.Collections;



public class BulletScript : MonoBehaviour

{

    SimpleGameManager GM;

    void Awake()

    {

        GM = SimpleGameManager.Instance;

    }



    [Tooltip("Furthest distance bullet will look for target")]

    public float maxDistance = 1000000;

    RaycastHit hit;

    [Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]

    public GameObject decalHitWall;

    [Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]

    public float floatInfrontOfWall;

    [Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]

    public GameObject bloodEffect;

    [Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]

    public LayerMask ignoreLayer;

    public GameObject player;



    /*

	* Uppon bullet creation with this script attatched,

	* bullet creates a raycast which searches for corresponding tags.

	* If raycast finds somethig it will create a decal of corresponding tag.

	*/

    void Update()

    {



        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))

        {

            if (decalHitWall)

            {

                if ((hit.transform.tag == "LevelPart") || (hit.transform.tag == "EndWall"))

                {

                    Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));

                    Destroy(gameObject);

                }

                if ((hit.transform.tag == "Dummie 1") || (hit.transform.tag == "Dummie 2") || 
					(hit.transform.tag == "Dummie 3") || (hit.transform.tag == "Dummie 4") || 
					(hit.transform.tag == "Dummie 5") || (hit.transform.tag == "Dummie 6"))

                {

                    DestroyTarget(hit);

                }

            }

            Destroy(gameObject);

        }

        Destroy(gameObject, 0.1f);

    }

    void DestroyTarget(RaycastHit hit)

    {
        GM.FinishQuest(hit.transform.tag);

        Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(hit.collider.gameObject);

    }

}