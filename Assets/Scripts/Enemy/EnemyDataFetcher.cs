using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataFetcher : MonoBehaviour
{
    private EnemyData _enemyData;

    private EnemyAPI _enemyAPI;

    public event Action<bool> OnEnemyFetchingActive;

    public event Action<EnemyData> OnEnemyDataFetched;


    public void GetNewEnemy()
    {
        _enemyAPI = new EnemyAPI();
        StartCoroutine(FetchEnemyData());
    }

    public IEnumerator FetchEnemyData()
    {
        OnEnemyFetchingActive?.Invoke(true);

        yield return StartCoroutine(_enemyAPI.FetchEnemyDataCoroutine((enemyData) =>
        {
            if (enemyData != null)
            {
                _enemyData = enemyData;
                StartCoroutine(GetEnemyImage(_enemyData.PictureUrl));
            }
            else
            {
                Debug.Log("Failed to fetch enemy data");
            }
        }));
    }

    public IEnumerator GetEnemyImage(string url)
    {
        yield return StartCoroutine(_enemyAPI.GetEnemyImage(url, (enemyImage) =>
        {
            if (enemyImage != null)
            {
                _enemyData.Picture = enemyImage;
                OnEnemyDataFetched?.Invoke(_enemyData);
            }
            else
            {
                Debug.Log("Failed to fetch enemy data");
            }
        }));

        OnEnemyFetchingActive?.Invoke(false);
    }
}
