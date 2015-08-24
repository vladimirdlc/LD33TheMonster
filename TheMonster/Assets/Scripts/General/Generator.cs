using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
    public GameObject prefab;
    public float timer;
    public float minGenerationTime;
    public float MaxGenerationTime;
    public float timeVariationOverTie;
    public float currentTimeForGenerate;

    public const float MINTIME = 0.1f; //Minimum generation time ever

    // Use this for initialization
    void Start()
    {
        timer = 0;
        calcularTiempoParaGenerar();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > currentTimeForGenerate)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            calcularTiempoParaGenerar();
            minGenerationTime = Mathf.Max(MINTIME, minGenerationTime + timeVariationOverTie);
            timer = 0;
        }


        timer += Time.deltaTime;
    }

    void calcularTiempoParaGenerar()
    {
        currentTimeForGenerate =
            Random.Range(minGenerationTime, MaxGenerationTime);
    }
}
