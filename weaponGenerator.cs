using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponGenerator : MonoBehaviour
{
    
    public List<GameObject> bodyParts;
    public List<GameObject> barrelParts;
    public List<GameObject> stockParts;
    public List<GameObject> scopeParts;
    public List<GameObject> magazineParts;
    public List<GameObject> gripParts;
    
    GameObject prevWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateWeapon();
        }
    }

    void GenerateWeapon()
    {
        if (prevWeapon != null)
        {
            Destroy(prevWeapon);
        }

        GameObject randomBody = GetRandomPart(bodyParts);
        GameObject insBody = Instantiate(randomBody, transform.position, Quaternion.identity);
        weaponBody wpnBody = insBody.GetComponent<weaponBody>();

        SpawnWeaponPart(barrelParts, wpnBody.barrelSocket);
        SpawnWeaponPart(scopeParts, wpnBody.scopeSocket);
        SpawnWeaponPart(magazineParts, wpnBody.magazineSocket);
        SpawnWeaponPart(gripParts, wpnBody.gripSocket);
        SpawnWeaponPart(stockParts, wpnBody.stockSocket);
        
        prevWeapon = insBody;
    }

    void SpawnWeaponPart(List<GameObject> parts, Transform socket)
    {
        GameObject randomPart = GetRandomPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
    }


    GameObject GetRandomPart(List<GameObject> partList)
    {
        int randomNumber = Random.Range(0, partList.Count);
        return partList[randomNumber];
    }
}
