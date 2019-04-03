/*==================*\
|*   Unity Usings   *|
\*==================*/

using UnityEngine;

/*================*\
|*   ROS Usings   *|
\*================*/

using RosSharp.RosBridgeClient.Messages.Geometry;

/*==================*\
|*   Local Usings   *|
\*==================*/

using RosVector3    = RosSharp.RosBridgeClient.Messages.Geometry.Vector3;
using RosQuaternion = RosSharp.RosBridgeClient.Messages.Geometry.Quaternion;

using UnityVector3    = UnityEngine.Vector3;
using UnityQuaternion = UnityEngine.Quaternion;

/*=========================*\
|*   CLASS: RosConverter   *|
\*=========================*/

public class RosConverter : Converter
{
    /*=============================*\
    |*   Public Static Functions   *|
    \*=============================*/

        /*================*\
        |*   UnityToROS   *|
        \*================*/

        public static void Vector3ToPoint(Point dataOut, ref UnityVector3 dataIn) 
        { Unity2Ros(dataOut, ref dataIn); }     
        public static void Vector3ToVector3(RosVector3 dataOut, ref UnityVector3 dataIn)             
        { Unity2Ros(dataOut, ref dataIn); }
        public static void QuaternionToQuaternion(RosQuaternion dataOut, ref UnityQuaternion dataIn) 
        { Unity2Ros(dataOut, ref dataIn); }
        
        public static void Vector3ToPoint(Point[] dataOut, UnityVector3[] dataIn)
        {
            // Early exit
            // ----------
            if (dataOut is null)                    { Debug.LogError("The output Point[] array is null; Missing Initialization!");  return; } 
            if (dataIn is null)                     { Debug.LogError("The input Vector3[] array is null; Missing Initialization!"); return; }
            if (dataOut.Length != dataIn.Length)    { Debug.LogError("Input and output array need to have the same length!"); return; }

            // Transform each item in input array
            // ----------------------------------
            for (int i = 0; i < dataIn.Length; i++) Vector3ToPoint(dataOut[i], ref dataIn[i]);
        }

        /*================*\
        |*   ROSToUnity   *|
        \*================*/

        public static void Vector3ToVector3(ref UnityVector3 dataOut, RosVector3 dataIn) 
        { Ros2Unity(ref dataOut, dataIn); }
        public static void PointToVector3(ref UnityVector3 dataOut, Point dataIn)
        { Ros2Unity(ref dataOut, dataIn); }
        public static void QuaternionToQuaternion(ref UnityQuaternion dataOut, RosQuaternion dataIn)
        { Ros2Unity(ref dataOut, dataIn); }

        /*================================*\
        |*   Coordinate system adaption   *|
        \*================================*/

        // The coordinate system adaption is necessary since Unity and
        // Ros use different coordinate system styles
        // 
        // Unity is a left hand system meaning the coordinate system 
        // is created by the left hand rule where the thumb points 
        // in z-direction the index-finger points in x-direction and the 
        // middle-finger points in y-direction
        //
        // However Ros uses a right hand system meaning the coordinate 
        // system is created by teh right hand rule where the thumb points
        // in x-direction the index-finger point in y-direction and the 
        // middle-finger points in z-direction
        //
        // ================================================================
        // 
        // In short:
        // ---------
        // LeftHandSystem:
        // Thumb            = z-axis
        // Index-Finger     = x-axis
        // Middle-Finger    = y-axis
        //
        // RightHandSystem:
        // Thumb            = x-axis
        // Index-Finger     = y-axis
        // Middle-Finger    = z-axis
        //
        // ================================================================

        public static void Unity2Ros(Point dataOut, ref UnityVector3 dataIn)
        {
            dataOut.x =  dataIn.z; 
            dataOut.y = -dataIn.x;
            dataOut.z =  dataIn.y;
        }
        public static void Unity2Ros(RosVector3 dataOut, ref UnityVector3 dataIn)
        {
            dataOut.x =  dataIn.z; 
            dataOut.y = -dataIn.x;
            dataOut.z =  dataIn.y;
        }
        public static void Unity2Ros(RosQuaternion dataOut, ref UnityQuaternion dataIn)
        {
            dataOut.x = -dataIn.z; 
            dataOut.y =  dataIn.x;
            dataOut.z = -dataIn.y;
            dataOut.w =  dataIn.w;
        }
        
        public static void Ros2Unity(ref UnityVector3 dataOut, Point dataIn)
        {
            dataOut.x = -dataIn.y;
            dataOut.y =  dataIn.z; 
            dataOut.z =  dataIn.x;
        }
        public static void Ros2Unity(ref UnityVector3 dataOut, RosVector3 dataIn)
        {
            dataOut.x = -dataIn.y;
            dataOut.y =  dataIn.z; 
            dataOut.z =  dataIn.x;
        }
        public static void Ros2Unity(ref UnityQuaternion dataOut, RosQuaternion dataIn)
        {
            dataOut.x =  dataIn.y;
            dataOut.y = -dataIn.z; 
            dataOut.z = -dataIn.x;
            dataOut.w =  dataIn.w;
        }
}