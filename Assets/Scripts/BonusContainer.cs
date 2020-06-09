using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BonusType 
{
    HealUp,
    SpeedUp,
    Immunity,
    WatterIgnore
}

public class BonusContainer : MonoBehaviour
{
    public BonusType Type;
    public float SelfDestroyTime = 20f;
    [Space]
    public int HealthUpCount = 1;
    public float ImmunityTime = 10f;
    public float SpeedUpMultiplier = 1.5f;
    public float WatterIgnoreTime = 10f;

    public Transform UsedPoint;

    private void Start()
    {
        Destroy(gameObject, SelfDestroyTime);
    }

    private IEnumerator DelaySelfDestroy()
    {
        yield return new WaitForSecondsRealtime(SelfDestroyTime);
        BonusSapwnController.Intance.UsedPoints.Remove(UsedPoint);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Player"))
        {
            var player = coll.gameObject.GetComponent<PlayerControl>();
            if (GetBonus(player))
            {
                Destroy(gameObject);
            }
        }
    }

    private bool GetBonus(PlayerControl player)
    {
        switch (Type)
        {
            case BonusType.HealUp:
                return player.HealUp(HealthUpCount);
            case BonusType.SpeedUp:
                return player.SpeedUp(SpeedUpMultiplier);
            case BonusType.Immunity:
                return player.Immunity(ImmunityTime);
            case BonusType.WatterIgnore:
                return player.WatterIgnore(WatterIgnoreTime);
            default:
                return false;
        }
    }
}
