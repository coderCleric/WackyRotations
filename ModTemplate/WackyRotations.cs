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
        }

        /**
         * Every frame, tick down the timer, change the velocity
         */
        private void FixedUpdate()
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
         * Applies the effects of the config file. Max speeds are multiplied by two to convert from rotations/sec to radians/sec
         */
        public override void Configure(IModConfig config)
        {
            //Ash twin
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.ASH, config.GetSettingsValue<bool>("ashUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.ASH, 2 * config.GetSettingsValue<float>("ashMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.ASH, config.GetSettingsValue<float>("ashTTC"));

            //Ember twin
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.EMBER, config.GetSettingsValue<bool>("emberUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.EMBER, 2 * config.GetSettingsValue<float>("emberMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.EMBER, config.GetSettingsValue<float>("emberTTC"));

            //Timber Hearth
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.TIMBER, config.GetSettingsValue<bool>("timberUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.TIMBER, 2 * config.GetSettingsValue<float>("timberMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.TIMBER, config.GetSettingsValue<float>("timberTTC"));

            //Attelrock
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.ATTELROCK, config.GetSettingsValue<bool>("attlUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.ATTELROCK, 2 * config.GetSettingsValue<float>("attlMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.ATTELROCK, config.GetSettingsValue<float>("attlTTC"));

            //Brittle Hollow
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.BRITTLE, config.GetSettingsValue<bool>("brittleUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.BRITTLE, 2 * config.GetSettingsValue<float>("brittleMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.BRITTLE, config.GetSettingsValue<float>("brittleTTC"));

            //Hollow's Lantern
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.LANTERN, config.GetSettingsValue<bool>("lanternUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.LANTERN, 2 * config.GetSettingsValue<float>("lanternMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.LANTERN, config.GetSettingsValue<float>("lanternTTC"));

            //Giant's Deep
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.DEEP, config.GetSettingsValue<bool>("deepUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.DEEP, 2 * config.GetSettingsValue<float>("deepMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.DEEP, config.GetSettingsValue<float>("deepTTC"));

            //Dark Bramble
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.BRAMBLE, config.GetSettingsValue<bool>("brambleUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.BRAMBLE, 2 * config.GetSettingsValue<float>("brambleMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.BRAMBLE, config.GetSettingsValue<float>("brambleTTC"));

            //Interloper
            ConfigData.UpdateUsesGeneralSettings(PlanetNames.INTERLOPER, config.GetSettingsValue<bool>("interloperUseGeneral"));
            ConfigData.UpdateMaxSpeed(PlanetNames.INTERLOPER, 2 * config.GetSettingsValue<float>("interloperMaxSpeed"));
            ConfigData.UpdateTimeToChange(PlanetNames.INTERLOPER, config.GetSettingsValue<float>("interloperTTC"));

            //General
            ConfigData.UpdateGeneralMaxSpeed(config.GetSettingsValue<float>("generalMaxSpeed"));
            ConfigData.UpdateGeneralTTC(config.GetSettingsValue<float>("generalTTC"));
        }
    }
}
