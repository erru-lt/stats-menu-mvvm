using UnityEngine;

namespace Assets.CodeBase
{
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int DefenseHash = Animator.StringToHash("Defense");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int RunningHash = Animator.StringToHash("Running");
        private static readonly int CrouchHash = Animator.StringToHash("Crouch");
        private static readonly int SpellHash = Animator.StringToHash("Spell");

        [SerializeField] private Animator _animator;

        public void PlayDefenseAnimation() =>
            _animator.SetTrigger(DefenseHash);

        public void PlayAttackAnimation() =>
            _animator.SetTrigger(AttackHash);

        public void PlayRunningAnimation() =>
            _animator.SetTrigger(RunningHash);

        public void PlayCrouchAnimation() =>
            _animator.SetTrigger(CrouchHash);

        public void PlaySpellAnimation() =>
            _animator.SetTrigger(SpellHash);

    }
}
