using UnityEngine;

namespace Extension
{
   public static class AnimationFrame
   {
      public static void SetRandomFrame(this Animator animator)
      {
         animator.SetFrame(Random.Range(0.0f, 1.0f));
      }

      public static void SetFrame(this Animator animator, float length)
      {
         // Animation range must be between 0 and 1
         if (length > 1) length = 1;
         if (length < 0) length = 0;

         AnimatorClipInfo[] currentClipInfo = animator.GetCurrentAnimatorClipInfo(0);

         animator.Play(currentClipInfo[0].clip.name, -1, length);
      }
   }
}