using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarSpawner : MonoBehaviour
{
    [SerializeField]
    private float starSpawnTime = 8.0f;

    [SerializeField]
    private ParticleSystem shootingStar;

    [SerializeField]
    private float spawnDistance = 1000;

    [SerializeField]
    private float doubleShootingStarChange = 0.1f;

    [SerializeField]
    private float timeBeforeDoubleStar = 0.5f;

    [Header("Space on Camera")]
    [SerializeField]
    private float minYHeight = 300;

    [SerializeField]
    private float maxYHeaight = 1000;

    [SerializeField]
    private float minSpaceOnCamera = 0.2f;

    [SerializeField]
    private float maxSpaceOnCamera = 0.8f;

    private void Awake()
    {
        StartCoroutine(SpawnStarRoutine());
    }

    private IEnumerator SpawnStarRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(starSpawnTime);
            SpawnShootingStar();

            if(Random.value <= doubleShootingStarChange)
            {
                yield return new WaitForSeconds(timeBeforeDoubleStar);
                SpawnShootingStar();
            }
        }
    }

    private void SpawnShootingStar()
    {
        var pos = new Vector3(Mathf.Clamp(Random.value, minSpaceOnCamera, maxSpaceOnCamera), Mathf.Clamp(Random.value, minSpaceOnCamera, maxSpaceOnCamera), spawnDistance);
        pos = Camera.main.ViewportToWorldPoint(pos);
        pos.y = Mathf.Clamp(pos.y, minYHeight, maxYHeaight);
        shootingStar.transform.position = pos;
        shootingStar.transform.rotation = Quaternion.Euler(new Vector3(Random.value * 360, -90, Random.value * 360));
        shootingStar.Play();
    }
}
