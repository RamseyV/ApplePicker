using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public static float bottomY = -20f;

    // Use this for initialization
    void Start () {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++){
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }


	}
	
    public void AppleDestroyed(){

        string[] tags = { "Apple", "GreenApple", "YellowApple" };
        foreach (string t in tags)
        {
            GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag(t);

            foreach (GameObject tGO in tAppleArray)
            {
                if (tGO.transform.position.y < bottomY)
                {
                    Destroy(tGO);
                    int basketIndex = basketList.Count - 1;
                    GameObject tBasketGO = basketList[basketIndex];
                    basketList.RemoveAt(basketIndex);
                    Destroy(tBasketGO);

                    if (basketList.Count == 0)
                    {
                        SceneManager.LoadScene("_end_scene");
                    }
                }
            }
        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}
