using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class generateSandwish : MonoBehaviour
{
    public string[] sandwich = new string[6] { "Amuse-bouche panaire", "Encas croustillant", "Subtilité boulangère", "Mie en croute fendue", "Duo de bruschetta refermées", "Mi-cuit de panini" };
    public string[] saucisse = new string[6] { " de charcutaille", " à la cochonaille", " au fromage de cochon", " de magnus sapidum farciminis", " de délicatesse carnassière", " de chaloupe fermière" };    
    public string[] qualificatif = new string[6] { " incroyable", " d'extase", " de magnificence", " à la perfection inégalée", " par les dieux touché", "d'une valeur inéluctable" };

    public string[] article = new string[216];

    public GameObject prefab;
    public GameObject shop;


    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 6; k++)
                {

                    article[k + j * 6 + i * 36] = sandwich[Random.Range(0, 5)] + saucisse[Random.Range(0, 5)] + qualificatif[Random.Range(0, 5)];
                    
                    GameObject item = Instantiate(prefab, new Vector3(0, 0, 0), GetComponentInParent<Transform>().rotation, shop.transform);
                    item.GetComponent<RectTransform>().localPosition = new Vector3(item.GetComponent<RectTransform>().localPosition.x, item.GetComponent<RectTransform>().localPosition.y, 0);

                    item.GetComponentInChildren<TextMeshProUGUI>().SetText(article[k + j * 6 + i * 36]);
                    GameObject m_Object = item.transform.FindChild("Price").gameObject;
                    m_Object.GetComponent<TextMeshProUGUI>().SetText(Random.Range(100, 15000)+ "€");

                    if (i==5 && j == 5 && k == 5)
                    {
                        item.GetComponentInChildren<TextMeshProUGUI>().SetText("Touillette");
                        m_Object = item.transform.FindChild("Price").gameObject;
                        m_Object.GetComponent<TextMeshProUGUI>().SetText("Gratuit €");
                    }
                }
            }
        }
        article[215] = "Touilette";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
