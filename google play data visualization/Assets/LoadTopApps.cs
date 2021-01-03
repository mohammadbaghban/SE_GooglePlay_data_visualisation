using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Application = DefaultNamespace.Application;
using Random = UnityEngine.Random;

public class LoadTopApps : MonoBehaviour
{
    private const int APPS_COUNT = 5;
    public Dictionary<CategoriesEnum, Color> categoryToColor;

    public GameObject cube;
    public GameObject appPanel; 
    public Text appText;
    public Text appDownloadNumber;
    public Text rating;
    public Text category;
    public Application[] applications;
    public GameObject cubePrefab;


    
    // Start is called before the first frame update
    void Start()
    {
        MakeCategoriesDictionary();
        StartCoroutine(GetRequest("https://mehranehjafari.ir/api/get_by_download?number=" + APPS_COUNT + "&format=json"));
    }
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                var response = webRequest.downloadHandler.text;
                //Debug.Log(pages[page] + ":\nReceived: " + response);
                Apps apps = JsonUtility.FromJson<Apps>(response);
                applications = new Application[apps.apps.Length];

                for (int i = 0; i < apps.apps.Length; i++)
                {
                    //Debug.Log(apps.apps[i].Price);
                    applications[i] = new Application();
                    applications[i].Name = apps.apps[i].ApplicationName;
                    applications[i].Category = StringToCategory(apps.apps[i].Category);
                    applications[i].Rating = GetFloat(apps.apps[i].OverallUserRating);
                    applications[i].Reviews = GetInt(apps.apps[i].NumberOfUsersReviews);
                    applications[i].Installs = GetInt(apps.apps[i].NumberOfUserDownloads);
                    applications[i].Size = GetFloat(apps.apps[i].Size);
                    applications[i].Price = GetFloat(apps.apps[i].Price);
                    Debug.Log(applications[i].Name + " Installs " + applications[i].Installs + " Price " + applications[i].Price + " Rating " + 
                              applications[i].Rating + " Reviews " + applications[i].Reviews + " Size " + applications[i].Size);
                }
                GenerateShapes(applications);
                Debug.Log("Here ");
            }
        }
    }
    
    private void GenerateShapes(Application[] apps)
    {
        for (int i = 0; i < apps.Length; i++)
        {
            
            // float y = (float) Math.Log(Math.Max(apps[i].Price, 1), 10) * 4;
            // float z = (float) Math.Log(apps[i].Reviews * apps[i].Rating, 10);
            // float x = (float) Math.Log(apps[i].Installs, 10);

            float yScale = (float) Math.Log(apps[i].Rating * apps[i].Reviews);
            float x = -22 + (11 * i);
            float z = 20;
            float y = -14 + (yScale / 2);

            GameObject s1 = Instantiate(cubePrefab);
            s1.GetComponent<AppClick>().application = apps[i];
            s1.GetComponent<AppClick>().appPanel = appPanel;
            s1.GetComponent<AppClick>().appText = appText;
            s1.GetComponent<AppClick>().appDownloadNumber = appDownloadNumber;
            s1.GetComponent<AppClick>().appRating = rating;
            s1.GetComponent<AppClick>().appCategory = category;

            s1.transform.position = new Vector3(x, y, z);
            s1.GetComponent<MeshRenderer>().material.color = categoryToColor[apps[i].Category];
            s1.transform.localScale = new Vector3(8, yScale, 1);
        }
        Debug.Log("H2");
    }
    private static int GetInt(string input)
    {
        int number = 0;
        Int32.TryParse(new string(input.Where(c => char.IsDigit(c) || c == '.').ToArray()), out number);
        return number;
    }
    
    private static float GetFloat(string input)
    {
        float number = 0;
        // var stripped = Regex.Replace(input, "[^0-9].", "");
        float.TryParse(new string(input.Where(c => (char.IsDigit(c) || c.Equals('.'))).ToArray()), out number);
        Debug.Log(number);

        return number;
    }
    
    CategoriesEnum StringToCategory(String categoryString)
    {
        switch (categoryString)
        {
            case "FAMILY":
                return CategoriesEnum.FAMILY;
            case "GAME":
                return CategoriesEnum.GAME;
            case "ART_AND_DESIGN":
                return CategoriesEnum.ART_AND_DESIGN;
            case "AUTO_AND_VEHICLES":
                return CategoriesEnum.AUTO_AND_VEHICLES;
            case "BEAUTY":
                return CategoriesEnum.BEAUTY;
            case "BOOKS_AND_REFERENCE":
                return CategoriesEnum.BOOKS_AND_REFERENCE;
            case "BUSINESS":
                return CategoriesEnum.BUSINESS;
            case "COMICS":
                return CategoriesEnum.COMICS;
            case "COMMUNICATION":
                return CategoriesEnum.COMMUNICATION;
            case "EDUCATION":
                return CategoriesEnum.EDUCATION;
            default:
                return CategoriesEnum.OTHER;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey ("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }

    void MakeCategoriesDictionary()
    {
        categoryToColor = new Dictionary<CategoriesEnum, Color>();
        categoryToColor.Add(CategoriesEnum.GAME, Color.yellow);
        categoryToColor.Add(CategoriesEnum.BEAUTY, Color.magenta);
        categoryToColor.Add(CategoriesEnum.COMICS, Color.red);
        categoryToColor.Add(CategoriesEnum.ART_AND_DESIGN, Color.green);
        categoryToColor.Add(CategoriesEnum.BUSINESS, Color.blue);
        categoryToColor.Add(CategoriesEnum.EDUCATION, Color.black);
        categoryToColor.Add(CategoriesEnum.COMMUNICATION, Color.white);
        categoryToColor.Add(CategoriesEnum.AUTO_AND_VEHICLES, new Color(0.6f, 0.7f, 1));
        categoryToColor.Add(CategoriesEnum.BOOKS_AND_REFERENCE, Color.cyan);
        categoryToColor.Add(CategoriesEnum.FAMILY, new Color(1, 0.40f, 0));
        categoryToColor.Add(CategoriesEnum.OTHER, Color.gray);
    }
}
