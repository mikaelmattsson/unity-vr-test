using UnityEngine;
using System.Collections;

public class VillagerController : MonoBehaviour
{

    public VillagerModelManager.PossibleModel[] possibleModels;

    VillagerModelManager modelManager;

    // Use this for initialization
    void Start()
    {
        setUpRandomModel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setUpRandomModel()
    {
        VillagerModelManager.PossibleModel selectedModel = possibleModels[Random.Range(0, possibleModels.Length)];

        modelManager = new VillagerModelManager(selectedModel, transform);

        
    }
}
