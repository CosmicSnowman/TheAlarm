using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject TimeHolder;
    public List<GameObject> Times;


    int Counter = 0;
    bool enumIsRunning = false;

    private void Start()
    {
        GetTimeGO();
    }

    private void Update()
    {
        if(!enumIsRunning)
        {
            StartCoroutine(TICK());
        }
    }


    void GetTimeGO()
    {
        for (int i = 0; i < TimeHolder.transform.childCount; i++)
        {
            Times.Add(TimeHolder.transform.GetChild(i).gameObject);
        }
    }


    IEnumerator TICK()
    {
        enumIsRunning = true;
        yield return new WaitForSeconds(45f);
        Counter += 1;

        Times[Counter].SetActive(true);
        Times[Counter-1].SetActive(false);

        enumIsRunning = false;



    }
}
