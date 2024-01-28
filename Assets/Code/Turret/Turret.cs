
using System.Collections.Generic;
using UnityEngine;

namespace com.vintagerockets.untitledtowerdefense.towers
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> targets;
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private Transform launchPoint;
        
        public float fireRate = 0.5f;
        public float nextFireTime = 5f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy")))
            {
                targets.Add(other.gameObject);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            Vector3 directionToTarget = targets[0].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = rotation;
            if (Time.time > nextFireTime)
            {
                Destroy(this.gameObject);
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
            
            
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy")))
            {
                targets.Remove(other.gameObject);
            }
        }
        private void Shoot()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, 1 << 6))
            {
                
                if (!hit.collider) return;
                Debug.Log("Bien pegado");
                Destroy(hit.transform.gameObject);
                targets.Remove(hit.transform.root.gameObject);
            }
        }
    }
}
