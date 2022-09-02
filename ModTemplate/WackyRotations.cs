using OWML.Common;
using OWML.ModHelper;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WackyRotations
{
    public class WackyRotations : ModBehaviour
    {
        public static PlanetContainer[] planetContainers = new PlanetContainer[System.Enum.GetValues(typeof(PlanetNames)).Length];
        public static WackyRotations instance;

        /**
         * On start, patch a method and set the timer up
         */

        private void Start()
        {
            // Starting here, you'll have access to OWML's mod helper.
            ModHelper.Console.WriteLine($"In Wacky Rotations", MessageType.Success);

            //Find the planets as they are woken up
            ModHelper.HarmonyHelper.AddPostfix<AstroObject>(
                "Awake",
                typeof(Patches),
                nameof(Patches.GrabPlanet));

            instance = this;
        }

        /**
         * Every frame, tick down the timer, change the velocity
         */
        private void Update()
        {
            //Loop through each planet container
            foreach(PlanetContainer i in planetContainers)
            {
                //Only do stuff if the planet exists
                if(i != null)
                {
                    //Update the rotation
                    i.UpdateRotationChange();

                    //Move to the desired rotation
                    i.ChangeRotation();
                }
            }
        }

        /**
         * Applies the effects of the config file
         */
        public override void Configure(IModConfig config)
        {
            //Ash twin
            ConfigData.UpdateMaxSpeed(PlanetNames.ASH, config.GetSettingsValue<float>("ashMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.ASH, config.GetSettingsValue<float>("ashTTC"));

            //Ember twin
            ConfigData.UpdateMaxSpeed(PlanetNames.EMBER, config.GetSettingsValue<float>("emberMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.EMBER, config.GetSettingsValue<float>("emberTTC"));

            //Timber Hearth
            ConfigData.UpdateMaxSpeed(PlanetNames.TIMBER, config.GetSettingsValue<float>("timberMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.TIMBER, config.GetSettingsValue<float>("timberTTC"));

            //Attelrock
            ConfigData.UpdateMaxSpeed(PlanetNames.ATTELROCK, config.GetSettingsValue<float>("attlMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.ATTELROCK, config.GetSettingsValue<float>("attlTTC"));

            //Brittle Hollow
            ConfigData.UpdateMaxSpeed(PlanetNames.BRITTLE, config.GetSettingsValue<float>("brittleMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.BRITTLE, config.GetSettingsValue<float>("brittleTTC"));

            //Hollow's Lantern
            ConfigData.UpdateMaxSpeed(PlanetNames.LANTERN, config.GetSettingsValue<float>("lanternMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.LANTERN, config.GetSettingsValue<float>("lanternTTC"));

            //Giant's Deep
            ConfigData.UpdateMaxSpeed(PlanetNames.DEEP, config.GetSettingsValue<float>("deepMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.DEEP, config.GetSettingsValue<float>("deepTTC"));

            //Dark Bramble
            ConfigData.UpdateMaxSpeed(PlanetNames.BRAMBLE, config.GetSettingsValue<float>("brambleMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.BRAMBLE, config.GetSettingsValue<float>("brambleTTC"));

            //Interloper
            ConfigData.UpdateMaxSpeed(PlanetNames.INTERLOPER, config.GetSettingsValue<float>("interloperMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.INTERLOPER, config.GetSettingsValue<float>("interloperTTC"));
        }

        public static void debugPrint(string s)
        {
            instance.ModHelper.Console.WriteLine(s);
        }
    }
}
