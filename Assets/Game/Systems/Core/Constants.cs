using UnityEngine;

public static class Constants
{
    public static class Tags
    {
        public const string Player = "Player";
    }

    public static class Animation
    {
        public static class Booleans
        {
            public static readonly int IsWalking = Animator.StringToHash("IsWalking");
            public static readonly int IsHitting = Animator.StringToHash("IsHitting");
        }

        public static class Floats
        {
            public static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        }
    }
    

}