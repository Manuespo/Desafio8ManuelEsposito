using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    bool escala = false;
    float cooldown = 2f;
    float time = 2f;
    float aux = 0;
    int i = 0;
    [SerializeField] Transform localizacion1;
    [SerializeField] Transform localizacion2;
    [SerializeField] Transform localizacion3;
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.gameObject.CompareTag("Portal") && time >= cooldown)
        {
            if (escala)
            {
                transform.localScale *= 2;
                escala = false;
            }
            else
            {
                transform.localScale /= 2;
                escala = true;
            }
            time = 0f;
        }
    }
    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if ((time - aux) >= 2f)
            {
                switch (i)
                {
                    case 0:
                        {
                            transform.position = localizacion1.position;
                            i++;
                        }
                        break;
                    case 1:
                        {
                            transform.position = localizacion2.position;
                            i++;
                        }
                        break;
                    case 2:
                        {
                            transform.position = localizacion3.position;
                            i=0;
                        }
                        break;
                }

            }
        }
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
            aux = time;
        Debug.Log(other.gameObject);
        Debug.Log(other.gameObject.transform);
    }
    private void Update()
    {
        time += Time.deltaTime;
    }

}
