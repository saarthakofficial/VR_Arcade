using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] MolesManager molesManager;
    public enum State{
        hittable,
        unhittable
    }
    public State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.unhittable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (currentState == State.hittable && other.gameObject.tag == "Hammer"){
            currentState = State.unhittable;
            StartCoroutine(molesManager.PopDownMole(this.transform));
            scoreManager.currentScore++;
        }
    }
}
