using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour{
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start(){
        //Encontrar la referencia del ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Obtener el texto del GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        //Poner el contador en 0
        scoreGT.text = "0";
    }

    void Update(){
        //Saber la posicion del mouse actual
        Vector3 mousePos2D = Input.mousePosition;
        //Que tan lejos alejar el mouse en z
        mousePos2D.z = -Camera.main.transform.position.z;
        //Buscar luego que es Screen To World Point
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll){
        //Descubre que golpea la canasta
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);
            //Contar las manzanas
            int score = int.Parse(scoreGT.text);
            score += 100;
            //Convertir el Score en String para mostrar
            scoreGT.text = score.ToString();
            //Enviar el nuevo High Score
            if (score > HighScore.score) {
                HighScore.score = score;
            }
        } else if(collidedWith.tag == "Bomb"){
            Destroy(collidedWith);

        }
    }
}
