using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour{

    [Header("Set in inspector")]
    //Realiza la instancia de las manzanas
    public GameObject applePrefab;
    public GameObject bombPrefab;
    public float chanceToChangeDrop = 0.1f;
    public bool bomDrop = false;
    //Velocidad a la que se mueve el arbol
    public float speed = 1f;
    //Distancia limite del arbol
    public float leftAndRightEdge = 10f;
    //Probabilidad con la cual cambiara de direccion
    public float chanceToChangeDirections = 0.1f;
    //Velocidad en que las manzanas se crean a partir de la instancia
    public float secondsBetweenAppleDrops = 1f;

    void Start(){
        Invoke("DropApple", 2f);
    }

    void Update(){
        //Movimiento Basico
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Cambio de Direccion
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);//Se mueve a la derecha
        }
        else if(pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);//Se mueve a la izquierda
        }
    }

    void FixedUpdate(){
        //Cambio de direccion aleatorio
        if (Random.value < chanceToChangeDirections){
            speed *= -1;
        }
        if (Random.value < chanceToChangeDrop) {
            bomDrop = true;
        }
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        if (bomDrop) {
            Invoke("DropBomb", secondsBetweenAppleDrops);
        }
        else {
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
    }

    void DropBomb() {
        GameObject bomb = Instantiate<GameObject>(bombPrefab);
        bomb.transform.position = transform.position;
        bomDrop = false;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
