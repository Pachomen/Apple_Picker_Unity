using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour{
    [Header("Set in inspector")]
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start(){
        basketList = new List<GameObject>();

        for (int i = 0; i < numBasket; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed() {
        //Destruye las manzanas en caida
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGO in tAppleArray){
            Destroy(tGO);
        }
        GameObject[] tBombArray = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject tGO in tBombArray){
            Destroy(tGO);
        }
        //Toma el numero de la ultima Canasta
        int basketIndex = basketList.Count - 1;
        //Toma la referencia de las canastas
        GameObject tBasketGO = basketList[basketIndex];
        //Elimina la Cansta de la lista y la destruye
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        //Cuando no tenga mas canastas
        if (basketList.Count == 0) {
            SceneManager.LoadScene("_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
