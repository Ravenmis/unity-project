using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSapwnController : MonoBehaviour
{
    private static BonusSapwnController _instance;
    public static BonusSapwnController Intance
    {
        get 
        {
            if (!_instance)
                _instance = GameObject.FindGameObjectWithTag("BonusSpawnController")
                    .GetComponent<BonusSapwnController>();
            return _instance;
        }
    }


    public List<Transform> UsedPoints = new List<Transform>();

    public float BonusSpawnTime = 60;
    public BonusContainer[] Bonuses;

    // Start is called before the first frame update
    void Start()
    {
        UsedPoints.Clear();
        StartCoroutine(SpawnBonus());
    }

    private IEnumerator SpawnBonus()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(BonusSpawnTime);
            var next = Random.Range(0, transform.childCount);
            var nextPoint = transform.GetChild(next);
            if (!UsedPoints.Contains(nextPoint))
            {
                var nextBonus = Random.Range(0, Bonuses.Length);
                var bonus = Instantiate(Bonuses[nextBonus],
                    nextPoint.position,
                    Quaternion.identity);
                bonus.UsedPoint = nextPoint;
                UsedPoints.Add(nextPoint);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
