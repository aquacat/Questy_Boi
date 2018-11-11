using UnityEngine;





public class HitMarker : MonoBehaviour

{



    private Rigidbody rb;

    private object other;



    void Start()

    {

        rb = GetComponent<Rigidbody>();

    }



    public void OnCollisionEnter(Collision other)

    {

        if (other.gameObject.CompareTag("Dummie 1"))

        {

            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("Dummie 2"))

        {

            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("Dummie 3"))

        {

            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("Dummie 4"))

        {

            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("Dummie 5"))

        {

            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("Dummie 6"))

        {

            other.gameObject.SetActive(false);

        }

    }

}