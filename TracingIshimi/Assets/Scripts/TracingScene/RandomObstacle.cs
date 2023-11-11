using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    public List<GameObject> spritePrefabs; // 5가지의 프리팹을 리스트에 추가
    public float destroyTime = 30f; // 삭제되는 시간
    public float length = 0f; // 나중에 수정.
    private bool isRespawnTime = true;
    private GameObject spawnedPrefab;
    private GameObject ground;

    private Vector3 spawnPosition = new Vector3(20, -4.5f, 0);
    private void Start()
    {
        ground = spritePrefabs.Find(x => x.name == "Ground");
        length = ground.transform.lossyScale.x;
        Debug.Log(length);
    }
    private void Update()
    {
        if (isRespawnTime)
        {
            RespawnObstacle();
        }
        if (spawnedPrefab.transform.position.x <= spawnPosition.x - length + 0.3f)
        {
            isRespawnTime = true;
        }
    }

    void RespawnObstacle()
    {
        isRespawnTime = false;
        // 랜덤으로 프리팹 선택
        int randomIndex = Random.Range(0, spritePrefabs.Count);
        GameObject prefabToSpawn = spritePrefabs[randomIndex];


        // 리스폰 위치에 프리팹 생성
        spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // 일정 시간이 지난 후에 프리팹 삭제
        Destroy(spawnedPrefab, destroyTime);

    }
}