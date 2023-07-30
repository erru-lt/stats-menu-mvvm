using Assets.CodeBase.Model;
using System;

namespace Assets.CodeBase.ViewModel
{
    public class StatsViewModel
    {
        public event Action OnPointsToSpendValueChanged;

        public ReactiveProperty<int> StrengthView = new();
        public ReactiveProperty<int> StaminaView = new();
        public ReactiveProperty<int> DefenseView = new();
        public ReactiveProperty<int> LuckView = new();
        public ReactiveProperty<int> ManaView = new();
        public ReactiveProperty<int> IntelligenceView = new();
        public ReactiveProperty<int> PointsToSpendView = new();

        private readonly PlayerStats _playerStats;
        private readonly CharacterAnimator _characterAnimator;

        public StatsViewModel(PlayerStats playerStats, CharacterAnimator characterAnimator)
        {
            _playerStats = playerStats;
            _characterAnimator = characterAnimator;

            DefinePropertiesValue();
            SubscribeOnStatsChanges();
        }

        public void IncreaseStrength()
        {
            _characterAnimator.PlayAttackAnimation();
            IncreaseStatValue(StrengthView);
        }

        public void IncreaseStamina()
        {
            _characterAnimator.PlayRunningAnimation();
            IncreaseStatValue(StaminaView);
        }

        public void IncreaseDefense()
        {
            _characterAnimator.PlayDefenseAnimation();
            IncreaseStatValue(DefenseView);
        }

        public void IncreaseLuck()
        {
            _characterAnimator.PlayCrouchAnimation();
            IncreaseStatValue(LuckView);
        }

        public void IncreaseMana()
        {
            _characterAnimator.PlaySpellAnimation();
            IncreaseStatValue(ManaView);
        }

        public void IncreaseIntelligence()
        {
            _characterAnimator.PlaySpellAnimation();
            IncreaseStatValue(IntelligenceView);
        }

        public void DecreaseStrength() =>
            DecreaseStatValue(StrengthView);

        public void DecreaseStamina() =>
            DecreaseStatValue(StaminaView);

        public void DecreaseDefense() =>
            DecreaseStatValue(DefenseView);

        public void DecreaseLuck() =>
            DecreaseStatValue(LuckView);

        public void DecreaseMana() =>
            DecreaseStatValue(ManaView);

        public void DecreaseIntelligence() =>
            DecreaseStatValue(IntelligenceView);

        public void OnResetButton() =>
            DefinePropertiesValue();

        public void OnConfirmButton()
        {
            _playerStats.Strength.Value = StrengthView.Value;
            _playerStats.Stamina.Value = StaminaView.Value;
            _playerStats.Defense.Value = DefenseView.Value;
            _playerStats.Luck.Value = LuckView.Value;
            _playerStats.Mana.Value = ManaView.Value;
            _playerStats.Intelligence.Value = IntelligenceView.Value;
            _playerStats.PointsToSpend.Value = PointsToSpendView.Value;
        }

        public void Dispose()
        {
            _playerStats.Strength.OnValueChanged -= StrengthValueChanged;
            _playerStats.Stamina.OnValueChanged -= StaminaValueChanged;
            _playerStats.Defense.OnValueChanged -= DefenseValueChanged;
            _playerStats.Luck.OnValueChanged -= LuckValueChanged;
            _playerStats.Mana.OnValueChanged -= ManaValueChanged;
            _playerStats.Intelligence.OnValueChanged -= IntelligenceValueChanged;
            PointsToSpendView.OnValueChanged -= PointsToSpendValueChanged;
        }

        private void StrengthValueChanged(int value) =>
            StrengthView.Value = value;

        private void StaminaValueChanged(int value) =>
            StaminaView.Value = value;

        private void DefenseValueChanged(int value) =>
            DefenseView.Value = value;

        private void LuckValueChanged(int value) =>
            LuckView.Value = value;

        private void ManaValueChanged(int value) =>
            ManaView.Value = value;

        private void IntelligenceValueChanged(int value) =>
            IntelligenceView.Value = value;

        private void PointsToSpendValueChanged(int value) =>
            OnPointsToSpendValueChanged?.Invoke();

        private void DefinePropertiesValue()
        {
            StrengthView.Value = _playerStats.Strength.Value;
            StaminaView.Value = _playerStats.Stamina.Value;
            DefenseView.Value = _playerStats.Defense.Value;
            LuckView.Value = _playerStats.Luck.Value;
            ManaView.Value = _playerStats.Mana.Value;
            IntelligenceView.Value = _playerStats.Intelligence.Value;
            PointsToSpendView.Value = _playerStats.PointsToSpend.Value;
        }

        private void SubscribeOnStatsChanges()
        {
            _playerStats.Strength.OnValueChanged += StrengthValueChanged;
            _playerStats.Stamina.OnValueChanged += StaminaValueChanged;
            _playerStats.Defense.OnValueChanged += DefenseValueChanged;
            _playerStats.Luck.OnValueChanged += LuckValueChanged;
            _playerStats.Mana.OnValueChanged += ManaValueChanged;
            _playerStats.Intelligence.OnValueChanged += IntelligenceValueChanged;
            PointsToSpendView.OnValueChanged += PointsToSpendValueChanged;
        }

        private void IncreaseStatValue(ReactiveProperty<int> property)
        {
            property.Value += 1;
            PointsToSpendView.Value -= 1;
        }

        private void DecreaseStatValue(ReactiveProperty<int> property)
        {
            property.Value -= 1;
            PointsToSpendView.Value += 1;
        }
    }
}