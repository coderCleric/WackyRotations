using UnityEngine;

namespace WackyRotations
{
    public class PlanetContainer
    {
        //Setting stuff
        private float maxTimeToChange;
        private float maxSpeed;

        //Sim stuff
        private OWRigidbody body;
        private float changeTimer;
        private Vector3 oldRotation;
        private Vector3 wantedRotation;

        /**
         * Make a new planet container with the given planet
         */
        public PlanetContainer(OWRigidbody body, float maxSpeed, float timeToChange)
        {
            //Set provided things
            this.body = body;
            this.maxTimeToChange = timeToChange;
            this.maxSpeed = maxSpeed;

            //Set other variables
            this.changeTimer = timeToChange;
            this.oldRotation = new Vector3(0, 0, 0);
            this.wantedRotation = new Vector3(0, 0, 0);
        }

        /**
         * Sets the maximum speed, auto-recalculating the target rotation afterward
         */
        public void SetMaxSpeed(float maxSpeed)
        {
            //Do nothing if the new value is what we already have
            if (this.maxSpeed == maxSpeed)
                return;

            //Set the max speed
            this.maxSpeed = maxSpeed;

            //Calculate the new rotation
            this.changeTimer = this.maxTimeToChange;
            this.oldRotation = this.body.GetAngularVelocity();
            this.wantedRotation = this.MakeNewRotationTarget();
        }

        /**
         * Sets the max time to change rotation targets. Automatically sets the timer to the new max without changing the rotation target
         */
        public void SetTimeToChange(float timeToChange)
        {
            //Do nothing if the new value is what we already have
            if (this.maxTimeToChange == timeToChange)
                return;

            this.maxTimeToChange = timeToChange;
            this.changeTimer = this.maxTimeToChange;
        }

        /**
         * Ticks the rotation timer, updates the targeted rotation if need be
         */
        public void UpdateRotationChange()
        {
            //Reduce the timer
            this.changeTimer -= Time.deltaTime;

            //Randomize the velocity when the timer goes off
            if (this.changeTimer <= 0)
            {
                //Save the old motion
                this.oldRotation = this.body.GetAngularVelocity();

                //Set the new target
                this.wantedRotation = this.MakeNewRotationTarget();

                //Reset the timer
                this.changeTimer += this.maxTimeToChange;
            }
        }

        /**
         * Makes a new rotation target
         */
        public Vector3 MakeNewRotationTarget()
        {
            //In case the max speed is 0
            if (this.maxSpeed == 0)
            {
                return new Vector3(0, 0, 0);
            }

            //Max speed is not 0, want random rotation
            else
            {
                //Randomly pick a direction
                //Get a random number from 0-1 for each component
                float wantedX = Random.Range(0f, 1f);
                float wantedY = Random.Range(0f, 1f);
                float wantedZ = Random.Range(0f, 1f);

                //Randomly reverse the components
                if (Random.Range(0f, 1f) < 0.5)
                    wantedX *= -1;
                if (Random.Range(0f, 1f) < 0.5)
                    wantedY *= -1;
                if (Random.Range(0f, 1f) < 0.5)
                    wantedZ *= -1;

                //Actually make the target vector, good direction but bad speed
                Vector3 rot = new Vector3(wantedX, wantedY, wantedZ);

                //Fix the vector so it goes at the max speed
                //Ensure the magnitude is not 0
                if (rot.magnitude == 0) //Set it to a hardcoded spin if it is
                    rot = new Vector3(this.maxSpeed, 0, 0);
                else //Otherwise, adjust it
                    rot = rot * (this.maxSpeed / rot.magnitude);

                return rot;
            }
        }

        /**
         * Changes the rotation, moving it towards the target
         */
        public void ChangeRotation()
        {
            float maxAccel;
            if (this.maxSpeed == 0)
                maxAccel = 0.3f;
            else
                maxAccel = this.maxSpeed;

            //Figure out the vector to move on to go right there
            Vector3 snapVector = this.wantedRotation - this.body.GetAngularVelocity();

            //Make the vector for the changed motion (accel = max speed)
            //Set the direction up
            Vector3 changeVector = (this.wantedRotation - this.oldRotation);
            //Correct the magnitude
            if(changeVector.magnitude != 0)
                changeVector = changeVector * (maxAccel / changeVector.magnitude) * Time.deltaTime;

            //Check if the change vector is greater than the snap
            if (snapVector.magnitude < changeVector.magnitude) //Override it if it is
                changeVector = snapVector;

            //Apply the motion
            this.body.SetAngularVelocity(this.body.GetAngularVelocity() + changeVector);
        }
    }
}
