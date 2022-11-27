using UnityEngine;

public class InterlacedModel: MonoBehaviour
{
    [SerializeField] Animator animator;

    void Update()
    {
        var currAnim = animator.GetCurrentAnimatorStateInfo(0);
        
        if (animator.GetBool("dance"))
        {
            animator.SetBool("dance", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Get ray from mouse pos
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit; // this is set by Physics.Raycast()

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "punk")
                {
                    animator.SetBool("dance", true);
                }
            }
        }
    }
}
