using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{

    public GameObject ball;
    public GameObject playground;
    public void SpawnPlayground()
    {
        StartCoroutine(ExampleCoroutine());
	}

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        playground.transform.parent = gameObject.transform;
		var playgroundRot = new Vector3(AngleCorrection(playground.transform.localRotation.eulerAngles.x), playground.transform.localRotation.eulerAngles.y, AngleCorrection(playground.transform.localRotation.eulerAngles.z));
		playground.transform.localRotation = Quaternion.Euler(playgroundRot);
		yield return new WaitForSeconds(0.5f);
		ball.GetComponent<Rigidbody>().useGravity = true;
	}

    private float AngleCorrection(float rot)
    {
		if ((rot >= -45f && rot < 45f) || (rot < -315f && rot >= 315f))
		{
			//right
			rot = 0;
			//rot = -180;
		}
		else if ((rot >= 45 && rot < 135) || (rot < -225f && rot >= -315f))
		{
			//up
			rot = 90;
		}
		else if ((rot >= 135 && rot < 225) || (rot < -135 && rot >= -225))
		{
			//left
			rot = 180;
			//rot = 0;
		}
		else if ((rot >= 225 && rot < 315) || (rot < -45 && rot >= -135))
		{
			//down
			rot = -90;
		}
		return rot;
	}
}
