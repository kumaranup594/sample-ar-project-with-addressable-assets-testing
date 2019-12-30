using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
public class loadAddressable : MonoBehaviour
{
    
    public AssetReference localObj;

    private List<IResourceLocation> remoteNos;
    public AssetLabelReference remoteBundleLabel;

    // Start is called before the first frame update
    void Start()
    {
         this.DisplayObjs();
        //Addressables.LoadResourceLocationsAsync(remoteBundleLabel.labelString).Completed += LocationLoaded;
    }

    public void DisplayObjs() {
        var randSpot = new Vector3(0,0,0);
         localObj.InstantiateAsync(randSpot, Quaternion.identity);
    }

    private void LocationLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj) {
        remoteNos = new List<IResourceLocation>(obj.Result);
        StartCoroutine(SpawnRemoteNos());
     }

    private IEnumerator SpawnRemoteNos() {
        yield return new WaitForSeconds(1f);
        float xOff = -4.0f;
        for(int i = 0; i < remoteNos.Count; i++) {
            Vector3 spawmpostion = new Vector3(xOff, 0, 0);
            Addressables.InstantiateAsync(remoteNos[i], spawmpostion, Quaternion.identity);
            xOff = xOff + 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
