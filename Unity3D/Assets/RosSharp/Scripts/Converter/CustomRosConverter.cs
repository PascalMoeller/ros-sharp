/*==================*\
|*   Local Usings   *|
\*==================*/

using RosPose2D = RosSharp.RosBridgeClient.Messages.Geometry.Pose2D;

/*===============================*\
|*   CLASS: CustomRosConverter   *|
\*===============================*/

public class CustomRosConverter : RosConverter
{
    /*================*\
    |*   Custom2ROS   *|
    \*================*/

    public static void Pose2DToPose2D(Pose2D dataOut, RosPose2D dataIn)
    {
        // Set fields
        // ----------
        dataOut.z       =  dataIn.x;
        dataOut.x       = -dataIn.y;
        dataOut.theta   = -dataIn.theta;
    }

    /*================*\
    |*   ROS2Custom   *|
    \*================*/

    public static void Pose2DToPose2D(RosPose2D dataOut, Pose2D dataIn)
    {
        // Set fields
        // ----------
        dataOut.x       =  dataIn.z;
        dataOut.y       = -dataIn.x;
        dataOut.theta   = -dataIn.theta;
    }
}