using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace WackyRotations
{
    public class Patches : MonoBehaviour
    {
        /**
         * Retrieve the rigidbody of DB
         */
        public static void DBOverride()
        {
            OWRigidbody dbbody = GameObject.Find("DarkBramble_Body").GetComponent<OWRigidbody>();

            WackyRotations.dbcontainer = new PlanetContainer(dbbody, PlanetContainer.dbTimeToChange, PlanetContainer.dbMaxSpeed);
        }
    }
}
