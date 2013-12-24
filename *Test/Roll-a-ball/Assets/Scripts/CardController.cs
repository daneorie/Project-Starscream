using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {

	void OnMouseDrag() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			transform.position = new Vector3(hit.point.x, 0.25f, hit.point.z);
		}
	}

	void OnCollisionEnter(Collision collision) {
		GameObject obj = collision.gameObject;
		Transform target = obj.transform;
		Vector3 a = transform.rotation.eulerAngles;
		Vector3 b = target.rotation.eulerAngles;
		bool sameObject = tag == obj.tag;
		bool flat = a.x < 10 && b.x < 10;
		bool nearby = Vector3.Distance(a,b) < 500;
		print(Vector3.Distance(a,b));
		if (sameObject && flat && nearby) {
			if (transform.position.y > target.position.y) {
				transform.position = new Vector3(
					target.position.x,
					target.position.y + 0.06f,
					target.position.z
				);
				transform.rotation = target.rotation;
			}
		}
	}

}