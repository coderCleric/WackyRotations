namespace WackyRotations
{
    public static class ConfigData
    {
        public static float[] maxSpeeds = new float[System.Enum.GetValues(typeof(PlanetNames)).Length];
        public static float[] timesToChange = new float[System.Enum.GetValues(typeof(PlanetNames)).Length];
        public static bool[] generalSettingUseList = new bool[System.Enum.GetValues(typeof(PlanetNames)).Length];
        public static float generalMaxSpeed = 0;
        public static float generalTTC = 0;

        /**
         * Updates the max speed of the given planet with the given value
         */
        public static void UpdateMaxSpeed(PlanetNames planet, float maxSpeed)
        {
            maxSpeeds[((int)planet)] = maxSpeed;
            if (WackyRotations.planetContainers[(int)planet] != null && !generalSettingUseList[((int)planet)])
                WackyRotations.planetContainers[(int)planet].SetMaxSpeed(maxSpeed);
        }

        /**
         * Updates the time to change of the given planet with the given value
         */
        public static void UpdateTimeToChange(PlanetNames planet, float timeToChange)
        {
            timesToChange[((int)planet)] = timeToChange;
            if (WackyRotations.planetContainers[(int)planet] != null && !generalSettingUseList[((int)planet)])
                WackyRotations.planetContainers[(int)planet].SetTimeToChange(timeToChange);
        }

        /**
         * Updates whether or not the planet uses the general settings
         */
        public static void UpdateUsesGeneralSettings(PlanetNames planet, bool usesGeneralSettings)
        {
            generalSettingUseList[((int)planet)] = usesGeneralSettings;
        }

        /**
         * Updates the general max speed
         */
        public static void UpdateGeneralMaxSpeed(float maxSpeed)
        {
            generalMaxSpeed = maxSpeed;
            if (WackyRotations.planetContainers[0] != null)
            {
                for (int i = 0; i < WackyRotations.planetContainers.Length; i++)
                {
                    if (generalSettingUseList[i])
                        WackyRotations.planetContainers[i].SetMaxSpeed(maxSpeed);
                }
            }
        }

        /**
         * Updates the general TTC
         */
        public static void UpdateGeneralTTC(float TTC)
        {
            generalTTC = TTC;
            if (WackyRotations.planetContainers[0] != null)
            {
                for (int i = 0; i < WackyRotations.planetContainers.Length; i++)
                {
                    if (generalSettingUseList[i])
                        WackyRotations.planetContainers[i].SetTimeToChange(TTC);
                }
            }
        }
    }
}
