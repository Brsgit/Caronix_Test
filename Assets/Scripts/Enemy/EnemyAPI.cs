using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyAPI
{
    private string _json;

    public IEnumerator FetchEnemyDataCoroutine(Action<EnemyData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://randomuser.me/api/"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                _json = www.downloadHandler.text;
                RootObject root = JsonConvert.DeserializeObject<RootObject>(_json);

                EnemyData enemyData = new EnemyData
                {
                    Name = root.Results[0].Name.First + " " + root.Results[0].Name.Last,
                    PictureUrl = root.Results[0].Picture.Large
                };

                callback?.Invoke(enemyData);
            }
            else
            {
                Debug.Log("Error: " + www.error);
                callback?.Invoke(null);
            }
        }
    }

    public IEnumerator GetEnemyImage(string url, Action<Sprite> callback)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                callback?.Invoke(sprite);
            }
            else
            {
                Debug.Log("Failed to load image: " + www.error);
                callback?.Invoke(null);
            }
        }
    }

    public class RootObject
    {
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public Name Name { get; set; }
        public Picture Picture { get; set; }
    }

    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Picture
    {
        public string Large { get; set; }
    }
}



[Serializable]
public class EnemyData
{
    public string Name { get; set; }
    public string PictureUrl { get; set; }
    public Sprite Picture { get; set; }
}

