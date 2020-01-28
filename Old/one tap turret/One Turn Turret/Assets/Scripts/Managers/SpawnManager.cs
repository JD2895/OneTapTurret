using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using JD.Utils;

namespace JD.OTT
{
    public class SpawnManager : MonoBehaviour
    {
        public float spawnPositionZ = -0.1f;
        public Transform player;

        public GameObject basicEnemyPrefab;
        public GameObject spiralEnemyPrefab;

        public List<TextAsset> levelDataList;
        private String levelData;

        private List<GameObject> currentEnemiesList = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            EnemySequence firstSequence = LoadEnemySequence(levelDataList[0]);
            StartCoroutine(PlayLevelSequence(firstSequence));
        }
        
        private GameObject SpawnAnEnemy(ScreenSection sectionToSpawn, GameObject enemyToSpawn)
        {
            // Get position based on 'sectionToSpawn'
            Vector2 screenPos = SpecMath.GetScreenEdgePosition(sectionToSpawn, UnityEngine.Random.Range(-1f, 1f));
            Vector3 worldPos = new Vector3(screenPos.x, screenPos.y, 0);
            worldPos = Camera.main.ScreenToWorldPoint(worldPos);
            worldPos.z = spawnPositionZ;

            // Move the position slightly offscreen
            worldPos += (worldPos - player.position) * 0.1f;

            // Spawn enemy
            GameObject newEnemy = Instantiate(enemyToSpawn, worldPos, Quaternion.identity);
            return newEnemy;
        }

        public EnemySequence LoadEnemySequence(TextAsset levelDataToLoad)
        {
            levelData = levelDataToLoad.ToString();
            return JsonUtility.FromJson<EnemySequence>(levelData);
        }

        IEnumerator PlayLevelSequence(EnemySequence levelSequence)
        {
            for (int nodeNumber = 0; nodeNumber < levelSequence.nodeList.Length; nodeNumber++)
            {
                EnemySequenceNode toSpawn = levelSequence.nodeList[nodeNumber];
                yield return new WaitForSeconds(toSpawn.delayTillSpawn);
                GameObject newEnemy = null;
                switch (toSpawn.enemyType)
                {
                    case EnemyType.spiral:
                        newEnemy = SpawnAnEnemy(toSpawn.allowableSpawnArea[UnityEngine.Random.Range(0, toSpawn.allowableSpawnArea.Count)], spiralEnemyPrefab);
                        break;
                    default:
                    case EnemyType.basic:
                        newEnemy = SpawnAnEnemy(toSpawn.allowableSpawnArea[UnityEngine.Random.Range(0, toSpawn.allowableSpawnArea.Count)], basicEnemyPrefab);
                        break;
                }
                newEnemy.GetComponent<BaseEnemyBehaviour>().InitializeEnemy(player.position, this);
                newEnemy.GetComponent<BaseEnemyBehaviour>().StartEnemyBehaviour();
                AddEnemyToCurrentList(newEnemy);
            }
            yield return null;
        }

        public void AddEnemyToCurrentList(GameObject toAdd)
        {
            if(toAdd != null)
                currentEnemiesList.Add(toAdd);
        }

        public void RemoveEnemy(GameObject toRemove)
        {
            currentEnemiesList.Remove(toRemove);
            Destroy(toRemove);
        }

        public void RemoveAllEnemies()
        {
            foreach(GameObject curEnemy in currentEnemiesList)
            {
                currentEnemiesList.Remove(curEnemy);
                Destroy(curEnemy);
            }
        }

        private void OnDestroy()
        {
            RemoveAllEnemies();
        }
    }

    [Serializable]
    public class EnemySequence
    {
        public EnemySequenceNode[] nodeList;
    }

    [Serializable]
    public class EnemySequenceNode
    {
        public EnemyType enemyType;
        public List<ScreenSection> allowableSpawnArea;
        public float delayTillSpawn;
    }
}