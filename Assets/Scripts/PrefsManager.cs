using Gamelogic.Extensions;
using SPStudios.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : Singleton
{
   public void SaveGame() {

        GameObject[] arrayToSave = GameObject.FindGameObjectsWithTag("asset");

        GLPlayerPrefs.SetInt("numberOfObjects", "numberOfObjects", arrayToSave.Length);

        for(int i = 0;i < arrayToSave.Length;i++) {
            GLPlayerPrefs.SetFloatArray("position",i.ToString() ,new float[] { arrayToSave[i].transform.position.x, arrayToSave[i].transform.position.y, arrayToSave[i].transform.position.z });
            GLPlayerPrefs.SetFloatArray("rotation", i.ToString(), new float[] { arrayToSave[i].transform.rotation.x, arrayToSave[i].transform.rotation.y, arrayToSave[i].transform.rotation.z });
            GLPlayerPrefs.SetFloatArray("scale", i.ToString(), new float[] { arrayToSave[i].transform.localScale.x, arrayToSave[i].transform.localScale.y, arrayToSave[i].transform.localScale.z });
        }

        GLPlayerPrefs.Save();

    }

    public void LoadGame(CreationManager manager) {

        if (!GLPlayerPrefs.HasKey("numberOfObjects", "numberOfObjects")) return;

        int numberOfOjects = GLPlayerPrefs.GetInt("numberOfObjects", "numberOfObjects");

        for (int i = 0; i < numberOfOjects; i++) {
            float[] position = GLPlayerPrefs.GetFloatArray("position", i.ToString());
            float[] rotation = GLPlayerPrefs.GetFloatArray("rotation", i.ToString());
            float[] scale = GLPlayerPrefs.GetFloatArray("scale", i.ToString());

            Vector3 posVec = new Vector3(position[0], position[1], position[2]);
            Quaternion rot = new Quaternion(rotation[0], rotation[1], rotation[2], 0);
            Vector3 scaleVec = new Vector3(scale[0], scale[1], scale[2]);

            manager.CreateObjectWithAttributes(posVec, rot, scaleVec);
        }

        GLPlayerPrefs.DeleteAll();

    }
}
