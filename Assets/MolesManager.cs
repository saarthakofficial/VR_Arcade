using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolesManager : MonoBehaviour
{
    [SerializeField] List<Transform> moles;
    [SerializeField] float popUpSpeed;
    [SerializeField] float maxPopHeight;
    float intervalMultiplier;
    Transform currentMole;
    float startingHeight = 4.94f;

    // Start is called before the first frame update
    void Start()
    {
        intervalMultiplier = 1f;
        StartCoroutine(SpawnMole());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMole()
    {
        while (true)
        {
            float interval = Random.Range(1f, 2f) / intervalMultiplier;
            Debug.LogError(interval);
            yield return new WaitForSeconds(interval);

            currentMole = moles[Random.Range(0, moles.Count)];
            moles.Remove(currentMole);
            StartCoroutine(PopUpMole(currentMole));
            
        }
    }

    IEnumerator PopUpMole(Transform mole)
    {
        float elapsedTime = 0f;

        while (elapsedTime < popUpSpeed)
        {
            float newY = Mathf.Lerp(startingHeight, maxPopHeight, elapsedTime / popUpSpeed);
            mole.localPosition = new Vector3(mole.localPosition.x, newY, mole.localPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (intervalMultiplier<2f){
                intervalMultiplier += 0.02f;
        }
        mole.localPosition = new Vector3(mole.localPosition.x, maxPopHeight, mole.localPosition.z);
        mole.GetComponent<Mole>().currentState = Mole.State.hittable;
        yield return new WaitForSeconds(2f);
        mole.GetComponent<Mole>().currentState = Mole.State.unhittable;
        StartCoroutine(PopDownMole(mole));
    }

    public IEnumerator PopDownMole(Transform mole)
    {
        float elapsedTime = 0f;

        while (elapsedTime < popUpSpeed)
        {
            float newY = Mathf.Lerp(maxPopHeight, startingHeight, elapsedTime / popUpSpeed);
            mole.localPosition = new Vector3(mole.localPosition.x, newY, mole.localPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        moles.Add(mole);
        mole.localPosition = new Vector3(mole.localPosition.x, startingHeight, mole.localPosition.z);
    }
}
