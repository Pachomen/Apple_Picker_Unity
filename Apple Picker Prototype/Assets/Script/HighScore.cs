using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour{
    static public int score = 1000;

    void Awake(){
        //Si ya existe un PlayerPrf lo lee
        if (PlayerPrefs.HasKey("HighScore")) {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //Asigna el HighScore de PlayerPref al HighScore
        PlayerPrefs.SetInt("HighScore", score);
    }

    void Update(){
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        //Actualiza el PlayerPref HighScore si es necesario
        if (score > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
