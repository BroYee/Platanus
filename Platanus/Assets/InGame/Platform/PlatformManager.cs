using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    public List<GameObject> platforms;
    public List<int> platformNum;
    public List<int> spawnChance;
    private List<List<GameObject>> platformList;

    public static PlatformManager instance;

    public Transform playerTrans;

    private Vector3 lastPlatformsPos;
    private int lastPlatformsXIndex;
    private int lastPlatformsYIndex;
    public float spaceBtnPlatforms;

    private float xMoveSpeed;
    private float yMoveSpeed;

    private float gravityScale;

    

	// Use this for initialization
	void Start () {
    
        platformList = new List<List<GameObject>>();

        for (int i = 0; i < platforms.Capacity; i++)
        {
            platformList.Add(new List<GameObject>());
            for (int j = 0; j < platformNum[i]; j++)
            {
                GameObject temp = (GameObject)Instantiate(platforms[i]);
                temp.name += j + 1;
                temp.transform.parent = this.transform;
                temp.SetActive(false);
                platformList[i].Add(temp);
            }
        }

        for (int i = 0; i < 5; i++)
        {
            int platformIndex = RandomPlatformIndex();
            platformList[platformIndex][i].transform.position = new Vector3(RandomPlatformXPos(), 5 - (i * spaceBtnPlatforms), 0);
            platformList[platformIndex][i].SetActive(true);
        }

        xMoveSpeed = 0.0f;
        yMoveSpeed = 0.0f;

        gravityScale = -5.0f;

        lastPlatformsPos = new Vector3(0, 0, 0);

        lastPlatformsXIndex = 0;
        lastPlatformsYIndex = 0;

        StartCoroutine(Wind());
	}

    // Update is called once per frame
    void Update()
    {

        Vector3 tempVec3 = Camera.main.WorldToScreenPoint(platformList[lastPlatformsXIndex][lastPlatformsYIndex].transform.position);

        if (tempVec3.y <= 2000)
        {
            int platformIndex = RandomPlatformIndex();

            for (int i = 0; i < platformNum[platformIndex]; i++)
            {
                if (platformList[platformIndex][i].activeSelf == false)
                {
                    platformList[platformIndex][i].transform.position = new Vector3(RandomPlatformXPos(), platformList[lastPlatformsXIndex][lastPlatformsYIndex].transform.position.y + spaceBtnPlatforms, 0);
                    platformList[platformIndex][i].SetActive(true);

                    lastPlatformsXIndex = platformIndex;
                    lastPlatformsYIndex = i;
                    break;
                }
            }

        }

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().idle == false)
        {
            for (int i = 0; i < platforms.Capacity; i++)
            {
                for (int j = 0; j < platformNum[i]; j++)
                {
                    if (platformList[i][j].activeSelf == true)
                    {
                        platformList[i][j].transform.Translate(xMoveSpeed * Time.deltaTime, (yMoveSpeed + gravityScale) * Time.deltaTime, 0);
                    }
                }
            }
        }

    }

    int RandomPlatformIndex()
    {
        int rand = Random.Range(0, 100);
        int index = 0;
        int spawnChanceAcc = 0; 

        while (true)
        {
            if (index == 0)
            {
                if (rand < spawnChance[0])
                    return 0;
                spawnChanceAcc += spawnChance[0];
                index++;
                continue;
            }
            else if (index == platforms.Capacity - 1) return index;
            
            if (rand - spawnChanceAcc < spawnChance[index]) return index;
            index++;
            spawnChanceAcc += spawnChance[index];
        }


    }

    float RandomPlatformXPos()
    {
        return Random.Range(-2.5f, 2.5f);
    }

    IEnumerator Wind()
    {
        yield return new WaitForSeconds(Random.Range(20.0f, 30.0f));

        Debug.Log("Wind");

        xMoveSpeed = Random.Range(-3.0f, 3.0f);
        yMoveSpeed = Random.Range(-1.0f, 1.0f);

        yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
        WindBack();

        StartCoroutine(Wind());
    }

    void WindBack()
    {
        xMoveSpeed = 0.0f;
        yMoveSpeed = 0.0f;
    }
    
}
