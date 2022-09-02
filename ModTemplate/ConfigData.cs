using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WackyRotations
{
    public static class ConfigData
    {
        public static float[] maxSpeeds = new float[System.Enum.GetValues(typeof(PlanetNames)).Length];
        public static float[] timesToChange = new float[System.Enum.GetValues(typeof(PlanetNames)).Length];

        /**
         * Updates the max speed of the given planet with the given value
         */
        public static void UpdateMaxSpeed(PlanetNames planet, float maxSpeed)
        {
            maxSpeeds[((int)planet)] = maxSpeed;
            if (WackyRotations.planetContainers[(int)planet] != null)
                WackyRotations.planetContainers[(int)planet].SetMaxSpeed(maxSpeed);
        }

        /**
         * Updates the time to change of the given planet with the given value
         */
        public static void UpdateTimeToChange(PlanetNames planet, float timeToChange)
        {
            timesToChange[((int)planet)] = timeToChange;
            if (WackyRotations.planetContainers[(int)planet] != null)
                WackyRotations.planetContainers[(int)planet].SetTimeToChange(timeToChange);
        }
    }
}
