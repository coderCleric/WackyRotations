﻿using UnityEngine;

namespace WackyRotations
{
    public class Patches : MonoBehaviour
    {
        /**
         * Add the planet to it's container when the astro object is created
         */
        public static void GrabPlanet(AstroObject __instance)
        {
            switch(__instance._name)
            {
                case AstroObject.Name.TowerTwin: //Ash twin
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.ASH)])
                        WackyRotations.planetContainers[(int)PlanetNames.ASH] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.ASH] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.ASH], ConfigData.timesToChange[(int)PlanetNames.ASH]);
                    break;

                case AstroObject.Name.CaveTwin: //Ember twin
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.EMBER)])
                        WackyRotations.planetContainers[(int)PlanetNames.EMBER] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.EMBER] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.EMBER], ConfigData.timesToChange[(int)PlanetNames.EMBER]);
                    break;

                case AstroObject.Name.TimberHearth: //Timber Hearth
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.TIMBER)])
                        WackyRotations.planetContainers[(int)PlanetNames.TIMBER] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.TIMBER] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.TIMBER], ConfigData.timesToChange[(int)PlanetNames.TIMBER]);
                    break;

                case AstroObject.Name.TimberMoon: //Attelrock
                    __instance.gameObject.GetComponent<AlignWithTargetBody>().enabled = false; //Need to disable the sun synchronous orbit
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.ATTELROCK)])
                        WackyRotations.planetContainers[(int)PlanetNames.ATTELROCK] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.ATTELROCK] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.ATTELROCK], ConfigData.timesToChange[(int)PlanetNames.ATTELROCK]);
                    break;

                case AstroObject.Name.BrittleHollow: //Brittle Hollow
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.BRITTLE)])
                        WackyRotations.planetContainers[(int)PlanetNames.BRITTLE] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.BRITTLE] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.BRITTLE], ConfigData.timesToChange[(int)PlanetNames.BRITTLE]);
                    break;

                case AstroObject.Name.VolcanicMoon: //Hollow's Lantern
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.LANTERN)])
                        WackyRotations.planetContainers[(int)PlanetNames.LANTERN] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.LANTERN] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.LANTERN], ConfigData.timesToChange[(int)PlanetNames.LANTERN]);
                    break;

                case AstroObject.Name.GiantsDeep: //Giant's Deep
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.DEEP)])
                        WackyRotations.planetContainers[(int)PlanetNames.DEEP] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.DEEP] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.DEEP], ConfigData.timesToChange[(int)PlanetNames.DEEP]);
                    break;

                case AstroObject.Name.DarkBramble: //Dark Bramble
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.BRAMBLE)])
                        WackyRotations.planetContainers[(int)PlanetNames.BRAMBLE] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.BRAMBLE] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.BRAMBLE], ConfigData.timesToChange[(int)PlanetNames.BRAMBLE]);
                    break;

                case AstroObject.Name.Comet: //Interloper
                    __instance.gameObject.GetComponent<AlignWithTargetBody>().enabled = false; //Need to disable the sun synchronous orbit
                    if (ConfigData.generalSettingUseList[((int)PlanetNames.INTERLOPER)])
                        WackyRotations.planetContainers[(int)PlanetNames.INTERLOPER] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.generalMaxSpeed, ConfigData.generalTTC);
                    else
                        WackyRotations.planetContainers[(int)PlanetNames.INTERLOPER] =
                            new PlanetContainer(__instance.gameObject.GetComponent<OWRigidbody>(), ConfigData.maxSpeeds[(int)PlanetNames.INTERLOPER], ConfigData.timesToChange[(int)PlanetNames.INTERLOPER]);
                    break;
            }
        }
    }
}
