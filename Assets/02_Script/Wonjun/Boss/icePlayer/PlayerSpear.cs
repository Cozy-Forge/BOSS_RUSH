using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpear : MonoBehaviour
{
    public float Damage = 150f;


    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            HitObject pHit = collision.GetComponent<HitObject>();
            if(pHit != null)
            {
                Debug.Log("�� �ƴ�");
                if (pHit.hp <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    pHit.TakeDamage(Damage);
                }
            }
            else
            {
                Debug.Log("��");
                Destroy(gameObject);
            }
            
        }
        
    }
}
