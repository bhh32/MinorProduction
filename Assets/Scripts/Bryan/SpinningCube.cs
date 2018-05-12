/** Written to keep the folder from being empty so that github would 
 *  accept it. Deleteable after production starts. **/

using UnityEngine;

public class SpinningCube : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;

	 void Update ()
    {
        var rotX = speedX * Time.deltaTime;
        var rotY = speedY * Time.deltaTime;
        var rotZ = speedZ * Time.deltaTime;

        transform.Rotate(rotX, rotY, rotZ);
	}
}
