using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    public float magnetForce = 100f; //Сила влияния
    public float attractionRadius = 5f; //Радиус влияния
    public bool isActive = false;
    
    void Update()
    {
        if (isActive)
        {
            AttractScrews();
        }
    }
    
    private void AttractScrews()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius); //Здесь находятся все коллайдеры взаимодействующие с полем
        
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Screw")) //Если в поле попадает болт, притягиваем его
            {
                Rigidbody screwRb = collider.GetComponent<Rigidbody>();
                if (screwRb != null)
                {
                    Vector3 direction = (transform.position - collider.transform.position).normalized; //Вектор между болтом и соленоидом
                    screwRb.AddForce(direction * magnetForce * Time.deltaTime); //С помощью вектора и силы задаём эффект притяжения
                }
            }
        }
    }
    
    public void ToggleMagneticField()
    {
        isActive = !isActive;
    }
    
    void OnDrawGizmos() //Чтобы лучше было видно поле при редактировании
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);
    }
}
