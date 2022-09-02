using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace WackyRotations
{
    public class WackyRotations : ModBehaviour
    {
        public static PlanetContainer dbcontainer = null;
        public static WackyRotations instance;

        /**
         * On start, patch a method and set the timer up
         */

        private void Start()
        {
            // Starting here, you'll have access to OWML's mod helper.
            ModHelper.Console.WriteLine($"In Wacky Rotations", MessageType.Success);

            //Find DB when it wakes up
            ModHelper.HarmonyHelper.AddPostfix<InitialMotion>(
                "Awake",
                typeof(Patches),
                nameof(Patches.DBOverride));

            instance = this;
        }

        /**
         * Every frame, tick down the timer, change the velocity
         */
        private void Update()
        {
            //Double check that the planet exists
            if (dbcontainer != null)
            {
                //Updates db's rotation
                dbcontainer.UpdateRotationChange();

                //Move to the desired axis
                dbcontainer.ChangeRotation();
            }
        }

        /**
         * Applies the effects of the config file
         */
        public override void Configure(IModConfig config)
        {
            //Dark Bramble
            PlanetContainer.dbMaxSpeed = config.GetSettingsValue<float>("maxSpeed");
            PlanetContainer.dbTimeToChange = config.GetSettingsValue<float>("timeToChange");
            if(dbcontainer != null)
            {
                dbcontainer.SetMaxSpeed(PlanetContainer.dbMaxSpeed);
                dbcontainer.SetTimeToChange(PlanetContainer.dbTimeToChange);
            }
        }

        public static void debugPrint(string s)
        {
            instance.ModHelper.Console.WriteLine(s);
        }
    }
}
