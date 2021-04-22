using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LleetLlamaTools {
    public class BoneDaddy : MonoBehaviour {
        /// <summary>
        /// pass in prefab SMR and a rigged "target" mesh.
        /// script will merge bones and mesh "root" with target SMR
        /// </summary>
        /// <param name="target_mesh"></param>
        /// <param name="new_mesh_prefab"></param>
        /// <param name="slotIndex"></param>
        /// <returns> returns a reference to the new, merged mesh </returns>
        public SkinnedMeshRenderer FuseBones(SkinnedMeshRenderer target_mesh, SkinnedMeshRenderer new_mesh_prefab) {

            SkinnedMeshRenderer spawnedMesh = Instantiate<SkinnedMeshRenderer>(new_mesh_prefab);
            spawnedMesh.transform.parent = target_mesh.transform;
            spawnedMesh.bones = target_mesh.bones;
            spawnedMesh.rootBone = target_mesh.rootBone;

            return spawnedMesh;
        }

        // TODO - Lets look at taking in an array of bones.
        // Looking at profiler leads me to believe we can optimize
        // this by storing references to the bone names.
    }
}
