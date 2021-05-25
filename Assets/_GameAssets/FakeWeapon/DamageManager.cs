using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int damage;
    public GameObject prefabImpacto;

    private void OnCollisionEnter(Collision other) {
        if (IsEnemy(other.gameObject)){
            other.gameObject.GetComponentInParent<Enemy>().ReceiveDamage(
                damage,
                other.GetContact(0).point,
                other.GetContact(0).normal);
        } else {
            GameObject psDamage = Instantiate(
                prefabImpacto,
                other.GetContact(0).point,
                Quaternion.LookRotation(other.GetContact(0).normal));
            psDamage.transform.SetParent(other.gameObject.transform);
        }
        Destroy(gameObject);
    }
    private bool IsEnemy(GameObject candidate){
        return (candidate.CompareTag("Enemy"));
    }
}