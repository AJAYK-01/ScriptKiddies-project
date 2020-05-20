    using UnityEngine;
    using System.Collections;
     
     
    public class NewBehaviourScript: MonoBehaviour {
     
        public float enginePower = 150.0f;
		public float gearfactor = 250.0f;
        public float power = 0.0f;
        public float brake = 0.0f;
        public float steer = 0.0f;
        public float maxSteer = 25.0f;
        public WheelCollider Wheel_LF;
        public WheelCollider Wheel_RF;
        public WheelCollider Wheel_LR;
        public WheelCollider Wheel_RR;
     
        void Start()
        {
            GetComponent<Rigidbody>().centerOfMass=new Vector3(0f,-0.5f,0.3f);
        }

		void Gear()
		{
			
		}
     
        void Update ()
        {
			if(GetKey("Alpha1")) {
				 gearfactor = 250.0f;
			}
			if(GetKey("Alpha2")){
				gearfactor = 0.0f;
			} 
			if(Input.GetAxis("Vertical"))
			{ 
                 power=200 * enginePower ;
			}
            steer=Input.GetAxis("Horizontal") * maxSteer;
            brake=Input.GetKey("space") ? GetComponent<Rigidbody>().mass * 0.5f: 0.0f;

       
            Wheel_LF.steerAngle=steer;
            Wheel_RF.steerAngle=steer;
       
            if(brake > 0.0)
            {
                Wheel_LF.brakeTorque=brake;
                Wheel_RF.brakeTorque=brake;
                Wheel_LR.brakeTorque=brake;
                Wheel_RR.brakeTorque=brake;
                Wheel_LR.motorTorque=0.0f;
                Wheel_RR.motorTorque=0.0f;
            }
            else
            {
                Wheel_LF.brakeTorque=0;
                Wheel_RF.brakeTorque=0;
                Wheel_LR.brakeTorque=0;
                Wheel_RR.brakeTorque=0;
                Wheel_LR.motorTorque=power;
                Wheel_RR.motorTorque=power;
            }
        }
    }
