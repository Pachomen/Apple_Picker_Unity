using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour{
    public static float bottomY = -20;

    void Update(){
        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);

            //Obtener refrenecia del RecogeManzanas
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Llamar al Destructor de manzanas en apScript
            apScript.AppleDestroyed();
        }
    }
}
