using UnityEngine;
using System.Collections;

public class VillagerModelManager
{
    [System.Serializable]
    public struct PossibleModel
    {
        public GameObject prefab;
        public Material[] materials;
    }

    GameObject prefab;
    Animation animation;

    public VillagerModelManager(PossibleModel selectedModel, Transform villager)
    {
        prefab = GameObject.Instantiate(selectedModel.prefab, villager.position, villager.rotation) as GameObject;
        prefab.transform.SetParent(villager);

        Transform head = prefab.transform.GetChild(Random.Range(0, 5));
        head.gameObject.SetActive(true);

        Material material = selectedModel.materials[Random.Range(0, selectedModel.materials.Length)];
        head.GetComponent<Renderer>().material = material;

        Transform body = prefab.transform.FindChild("_body");
        body.GetComponent<Renderer>().material = material;
        animation = prefab.GetComponent<Animation>();

        Walk();
    }

    void Walk()
    {
        animation.Play();
        animation.playAutomatically = true;
        animation.CrossFade("walk-01");
    }

}
