using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    bool hasPackage = false;
    float destroyDeley = 0.5f; 

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    void OnCollisionEnter2D() {
        Debug.Log("Ouch");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Packege picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDeley);
        }
        if (other.tag == "Custemer" && hasPackage)
        {
            Debug.Log("Packege delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;

        }
    }
}
