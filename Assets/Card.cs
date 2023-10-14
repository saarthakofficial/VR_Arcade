using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] TMP_Text creditsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        creditsText.text = PlayerData.instance.remainingCredits + " C";
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("takraya");
        if (other.gameObject.tag == "Recharger"){
            PlayerData.instance.remainingCredits = 500;
        }
    }
}
