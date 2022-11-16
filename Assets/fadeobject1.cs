using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeobject1 : MonoBehaviour
{
    [SerializeField] private Material EnemyMaterial;
    public static bool Fadein;
    public static bool FadeOut;
    public float FadeInAmount;
    public float FadeoutAmount;

    // Start is called before the first frame update
    void Start()
    {
        //Set the alpha of the material to 0 on start, so it doesn't show on the radar when it has not been tracked yet
        Color color = EnemyMaterial.color;
        color.a = 0;
        EnemyMaterial.color = color;

    }

    // Update is called once per frame
    void Update()
    {


            if (Fadein)
            {
                Debug.Log("Faded in");
                Color color = EnemyMaterial.color;
            // Alpha increases with 1 every frame
            color.a += (FadeInAmount * Time.deltaTime);
            EnemyMaterial.color = color;
              
            //If the alpha is opaque then fadein is completed
            if (color.a >= 1)
            {
                Fadein = false;
                StartCoroutine(Fadeout());
            }

        }

    }

    IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(2f);
        if (!Fadein)
        {
            Color color = EnemyMaterial.color;
            color.a = 0;
            EnemyMaterial.color = color;
            if (color.a <= 0)
            {
                FadeOut = false;
            }
        }


    }


}
