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
    

	void Start () {
    
        // Generate the platforms which is going to appear at first
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
        // Widen the spaces between each platform by spaceBtnPlatforms
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
    
    void Update()
    {
        // Get position of the platform generated at the last
        Vector3 tempVec3 = Camera.main.WorldToScreenPoint(platformList[lastPlatformsXIndex][lastPlatformsYIndex].transform.position);

        if (tempVec3.y <= 2000) // if the platform appears in the screen
        {
            int platformIndex = RandomPlatformIndex();

            for (int i = 0; i < platformNum[platformIndex]; i++)
            {
                if (platformList[platformIndex][i].activeSelf == false)
                {
                    // Ramdomized x position and adjusted y position to spaceBtnPlatforms
                    platformList[platformIndex][i].transform.position = new Vector3(RandomPlatformXPos(), platformList[lastPlatformsXIndex][lastPlatformsYIndex].transform.position.y + spaceBtnPlatforms, 0);
                    platformList[platformIndex][i].SetActive(true);

                    lastPlatformsXIndex = platformIndex;
                    lastPlatformsYIndex = i;
                    break;
                }
            }

        }

        // Make all platforms fall while player is not idle
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
        int spawnChanceAcc = 0;  // Store previous spawn chance rates

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
