using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private bool m_IsOnGround;
    private float distToGround;
 
     public bool IsOnGround
     {
         get
         {
             if (m_IsOnGround)
             {
                 m_IsOnGround = false;
                 return true;
             }
             else
             {
                 return false;
             }
         }
     }
     void OnCollisionStay()
     {
         //If it touch things, then it's on ground, that's my rule
         m_IsOnGround = true;
     }
}
