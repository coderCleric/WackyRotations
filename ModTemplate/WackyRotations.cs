using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace WackyRotations
{
    public class ModTemplate : ModBehaviour
    {
        private float changeTimer;
        private float startTime;
        private float wantedX;
        private float wantedY;
        private float wantedZ;
        private float maxSpeed = 0.3f;

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

            //Set the timer's initial time
            this.startTime = 5;
            this.changeTimer = startTime;

            //Set the initial x, y, and z
            this.wantedX = 0;
            this.wantedY = 0;
            this.wantedZ = 0;
        }

        /**
         * Every frame, tick down the timer, change the velocity
         */
        private void Update()
        {
            //Check to make sure we have an initial motion
            if (Patches.DBBody == null)
                return;

            //Reduce the timer
            this.changeTimer -= Time.deltaTime;

            //Randomize the velocity when the timer goes off
            if (this.changeTimer <= 0)
            {
                //Randomly set the new motion targets
                //Get a random number from 0-1
                this.wantedX = Random.Range(0f, 1f);
                this.wantedY = Random.Range(0f, 1f);
                this.wantedZ = Random.Range(0f, 1f);

                //Add them and convert each to a percentage, then to a speed target
                float sum = this.wantedX + this.wantedY + this.wantedZ;
                this.wantedX = (this.wantedX / sum) * this.maxSpeed;
                this.wantedY = (this.wantedY / sum) * this.maxSpeed;
                this.wantedZ = (this.wantedZ / sum) * this.maxSpeed;

                //Randomly reverse the speed targets
                if (Random.Range(0f, 1f) < 0.5)
                    this.wantedX *= -1;
                if (Random.Range(0f, 1f) < 0.5)
                    this.wantedY *= -1;
                if (Random.Range(0f, 1f) < 0.5)
                    this.wantedZ *= -1;

                //Reset the timer
                this.changeTimer += startTime;
            }

            //Move to the desired axis
            this.ChangeAxis();
        }

        /**
         * Gradually moves the rotation axis to the new one
         */
        private void ChangeAxis()
        {
            //Figure out how far to move per second
            float maxRate = this.maxSpeed / 3;
            //Calculate how much to change the x
            float xSpeed = Patches.DBBody.GetAngularVelocity().x;
            float xChange;
            if (this.wantedX > xSpeed)
            {
                xChange = Mathf.Min(Mathf.Abs(this.wantedX - xSpeed), maxRate);
                xChange *= Time.deltaTime;
            }
            else
            {
                xChange = Mathf.Min(Mathf.Abs(this.wantedX - xSpeed), maxRate) * -1;
                xChange *= Time.deltaTime;
            }

            //Then the y
            float ySpeed = Patches.DBBody.GetAngularVelocity().y;
            float yChange;
            if (this.wantedY > ySpeed)
            {
                yChange = Mathf.Min(Mathf.Abs(this.wantedY - ySpeed), maxRate);
                yChange *= Time.deltaTime;
            }
            else
            {
                yChange = Mathf.Min(Mathf.Abs(this.wantedY - ySpeed), maxRate) * -1;
                yChange *= Time.deltaTime;
            }

            //and the z
            float zSpeed = Patches.DBBody.GetAngularVelocity().z;
            float zChange;
            if (this.wantedZ > zSpeed)
            {
                zChange = Mathf.Min(Mathf.Abs(this.wantedZ - zSpeed), maxRate);
                zChange *= Time.deltaTime;
            }
            else
            {
                zChange = Mathf.Min(Mathf.Abs(this.wantedZ - zSpeed), maxRate) * -1;
                zChange *= Time.deltaTime;
            }

            //Apply the motions
            Patches.DBBody.AddAngularVelocityChange(new Vector3(xChange, yChange, zChange));
        }

        /**
         * Applies the effects of the config file
         */
        public override void Configure(IModConfig config)
        {
            this.maxSpeed = config.GetSettingsValue<float>("maxSpeed");
            this.startTime = config.GetSettingsValue<float>("timeToChange");
        }
    }
}
