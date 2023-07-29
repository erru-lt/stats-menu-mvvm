namespace Assets.CodeBase.ViewModel
{
    public class ButtonsViewModel
    {
        private readonly StatsViewModel _statsViewModel;

        public ReactiveProperty<bool> IncreaseStrengthButtonEnabled = new();
        public ReactiveProperty<bool> IncreaseStaminaButtonEnabled = new();
        public ReactiveProperty<bool> IncreaseDefenseButtonEnabled = new();
        public ReactiveProperty<bool> IncreaseLuckButtonEnabled = new();
        public ReactiveProperty<bool> IncreaseManaButtonEnabled = new();
        public ReactiveProperty<bool> IncreaseIntelligenceButtonEnabled = new();

        public ReactiveProperty<bool> DecreaseStrengthButtonEnabled = new();
        public ReactiveProperty<bool> DecreaseStaminaButtonEnabled = new();
        public ReactiveProperty<bool> DecreaseDefenseButtonEnabled = new();
        public ReactiveProperty<bool> DecreaseLuckButtonEnabled = new();
        public ReactiveProperty<bool> DecreaseManaButtonEnabled = new();
        public ReactiveProperty<bool> DecreaseIntelligenceButtonEnabled = new();

        public ButtonsViewModel(StatsViewModel statsViewModel)
        {
            _statsViewModel = statsViewModel;
            _statsViewModel.OnPointsToSpendValueChanged += DefineButtonsState;
        }

        public void DefineButtonsState()
        {
            IncreaseButtonsState();
            DecreaseButtonsState();
        }

        public void OnResetButton()
        {
            _statsViewModel.OnResetButton();
            DecreaseButtonsState();
            IncreaseButtonsState();
        }

        public void Dispose() =>
            _statsViewModel.OnPointsToSpendValueChanged -= DefineButtonsState;

        private void DecreaseButtonsState()
        {
            DecreaseStrengthButtonEnabled.Value = _statsViewModel.StrengthView.Value > 0;
            DecreaseStaminaButtonEnabled.Value = _statsViewModel.StaminaView.Value > 0;
            DecreaseDefenseButtonEnabled.Value = _statsViewModel.DefenseView.Value > 0;
            DecreaseLuckButtonEnabled.Value = _statsViewModel.LuckView.Value > 0;
            DecreaseManaButtonEnabled.Value = _statsViewModel.ManaView.Value > 0;
            DecreaseIntelligenceButtonEnabled.Value = _statsViewModel.IntelligenceView.Value > 0;
        }

        private void IncreaseButtonsState()
        {
            IncreaseStrengthButtonEnabled.Value = _statsViewModel.PointsToSpendView.Value > 0;
            IncreaseStaminaButtonEnabled.Value = _statsViewModel.PointsToSpendView.Value > 0;
            IncreaseDefenseButtonEnabled.Value = _statsViewModel.PointsToSpendView.Value > 0;
            IncreaseLuckButtonEnabled.Value = _statsViewModel.PointsToSpendView.Value > 0;
            IncreaseManaButtonEnabled.Value = _statsViewModel.PointsToSpendView.Value > 0;
            IncreaseIntelligenceButtonEnabled.Value = _statsViewModel.PointsToSpendView.Value > 0;
        }
    }
}