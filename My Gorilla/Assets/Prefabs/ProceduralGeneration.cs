using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] int repeatNum; 
    [SerializeField] GameObject Dirt, Grass;
    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    
    void Generation()
    {
        int repeatValue = 0;
        for (int x = 0; x < width; x++) 
        {
            if(repeatValue == 0)
            {
                height = Random.Range(minHeight, maxHeight);
                GenerateFlatPlatform(x);
                repeatValue = repeatNum;
            }
            else
                GenerateFlatPlatform(x);
                repeatValue--;
        }
    }

    void GenerateFlatPlatform(int x)
    {
        for (int y = 0; y < height; y++)
        {
            spawnObj(Dirt, x, y);
        }
        spawnObj(Grass, x, height);
    }
    void spawnObj( GameObject obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
