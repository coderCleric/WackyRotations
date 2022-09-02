using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace WackyRotations
{
    public class Patches : MonoBehaviour
    {
        public static OWRigidbody DBBody = null;

        /**
         * Retrieve the rigidbody of DB
         */
        public static void DBOverride()
        {
            //Find the initial motions
            InitialMotion[] motions = FindObjectsOfType<InitialMotion>();

            //Check each to see if it's DB
            foreach (InitialMotion i in motions)
            {
                if (i.gameObject.name.Equals("DarkBramble_Body"))
                {
                    DBBody = i.gameObject.GetComponent<OWRigidbody>();
                    return;
                }
            }
        }
    }
}
