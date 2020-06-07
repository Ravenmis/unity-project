using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSapwnController : MonoBehaviour
{
    public float BonusSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBonus());
    }

    private IEnumerator SpawnBonus()
    {
        yield return new WaitForSecondsRealtime(BonusSpawnTime);
        var next = Random.Range(0, transform.childCount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
