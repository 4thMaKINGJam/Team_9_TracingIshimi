using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public float startEventTime = 103f;
    public float startCloudTime = 60f;
    private bool isIshimi = false;
    public List<GameObject> obstaclePrefabs;
    public GameObject cloudPrefabs;
    public float spawnInterval = 1f; //리스폰 되는 간격 = range로 랜덤값 부여할 예정
    public float spawnDuration = 6f; // 삭제되기까지의 시간
    private float timeSinceLastSpew = 4f;//리스폰 되고 나서 얼마나 흘렀는지
    private Vector3 spawnPostion;
    private GameObject spawnedPrefabs;
    public GameObject Ishimi;

    public float spentTime = 0f;
    private bool isTimetoRespawn = true;
    private void Update()
    {
        timeSinceLastSpew += Time.deltaTime;
        spentTime += Time.deltaTime;
        if (isTimetoRespawn)
        {
            isTimetoRespawn = false;
            //obstacle initiaite하는 함수 
            if (spentTime > startCloudTime && spentTime < startEventTime)
            {
                spawnCloud();
            }
            else
                spawnObstacle();
            timeSinceLastSpew = 0f;
        }
        else if (timeSinceLastSpew >= spawnInterval && !isIshimi)
        {
            isTimetoRespawn = true;
        }

        if (!isIshimi && spentTime > startEventTime)
        {
            isIshimi = true;
            spawnIshimi();
        }
    }
    void spawnCloud()
    {
        spawnInterval = 1.6f;
        int randomIndex = Random.Range(0, 5);
        switch (randomIndex)
        {
            case 0:
                spawnPostion = new Vector3(10, 2f, 0);
                break;
            case 1:
            case 2:
                spawnPostion = new Vector3(10, -0.5f, 0);
                break;
            case 3:
            case 4:
                spawnPostion = new Vector3(10, -2f, 0);
                break;
        }
        spawnedPrefabs = Instantiate(cloudPrefabs, spawnPostion, Quaternion.identity);
    }
    void spawnIshimi()
    {
        Ishimi.gameObject.SetActive(true);
    }

    void spawnObstacle()
    {
        spawnInterval = Random.Range(1f, 2.1f);
        int randomIndex = Random.Range(0, obstaclePrefabs.Count);
        spawnPostion = (randomIndex == 1) ? new Vector3(12, -3, 0) : new Vector3(12, -2, 0);
        spawnedPrefabs = Instantiate(obstaclePrefabs[randomIndex], spawnPostion, Quaternion.identity);
    }
}