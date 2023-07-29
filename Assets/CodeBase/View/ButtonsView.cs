using Assets.CodeBase.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.View
{
    public class ButtonsView : MonoBehaviour, IView
    {
        private StatsViewModel _statsViewModel;
        private ButtonsViewModel _buttonsViewModel;

        [SerializeField] private Button _increaseStrengthButton;
        [SerializeField] private Button _increaseStaminaButton;
        [SerializeField] private Button _increaseDefenseButton;
        [SerializeField] private Button _increaseLuckButton;
        [SerializeField] private Button _increaseManaButton;
        [SerializeField] private Button _increaseIntelligenceButton;

        [SerializeField] private Button _decreaseStrengthButton;
        [SerializeField] private Button _decreaseStaminaButton;
        [SerializeField] private Button _decreaseDefenseButton;
        [SerializeField] private Button _decreaseLuckButton;
        [SerializeField] private Button _decreaseManaButton;
        [SerializeField] private Button _decreaseIntelligenceButton;

        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _resetButton;

        public void Construct(StatsViewModel statsViewModel, ButtonsViewModel buttonsViewModel)
        {
            _statsViewModel = statsViewModel;
            _buttonsViewModel = buttonsViewModel;
        }

        public void Initialize()
        {
            AddListenersToButtons();
            SubscribeOnButtonsEnableChanges();
        }

        private void OnDestroy()
        {
            _statsViewModel.Dispose();
            _buttonsViewModel.Dispose();
            Dispose();
        }

        private void SubscribeOnButtonsEnableChanges()
        {
            _buttonsViewModel.IncreaseStrengthButtonEnabled.OnValueChanged += OnIncreaseStrengthButtonEnabled;
            _buttonsViewModel.IncreaseStaminaButtonEnabled.OnValueChanged += OnIncreaseStaminaButtonEnabled;
            _buttonsViewModel.IncreaseDefenseButtonEnabled.OnValueChanged += OnIncreaseDefenseButtonEnabled;
            _buttonsViewModel.IncreaseLuckButtonEnabled.OnValueChanged += OnIncreaseLuckButtonClicked;
            _buttonsViewModel.IncreaseManaButtonEnabled.OnValueChanged += OnIncreaseManaButtonEnabled;
            _buttonsViewModel.IncreaseIntelligenceButtonEnabled.OnValueChanged += OnIncreaseIntelligenceButtonEnabled;


            _buttonsViewModel.DecreaseStrengthButtonEnabled.OnValueChanged += OnDecreaseStrengthButtonEnabled;
            _buttonsViewModel.DecreaseStaminaButtonEnabled.OnValueChanged += OnDecreaseStaminaButtonEnabled;
            _buttonsViewModel.DecreaseDefenseButtonEnabled.OnValueChanged += OnDecreaseDefenseButtonEnabled;
            _buttonsViewModel.DecreaseLuckButtonEnabled.OnValueChanged += OnDecreaseLuckButtonEnabled;
            _buttonsViewModel.DecreaseManaButtonEnabled.OnValueChanged += OnDecreaseManaButtonEnabled;
            _buttonsViewModel.DecreaseIntelligenceButtonEnabled.OnValueChanged += OnDecreaseIntelligenceButtonEnabled;
        }

        private void AddListenersToButtons()
        {
            _increaseStrengthButton.onClick.AddListener(_statsViewModel.IncreaseStrength);
            _increaseStaminaButton.onClick.AddListener(_statsViewModel.IncreaseStamina);
            _increaseDefenseButton.onClick.AddListener(_statsViewModel.IncreaseDefense);
            _increaseLuckButton.onClick.AddListener(_statsViewModel.IncreaseLuck);
            _increaseManaButton.onClick.AddListener(_statsViewModel.IncreaseMana);
            _increaseIntelligenceButton.onClick.AddListener(_statsViewModel.IncreaseIntelligence);

            _decreaseStrengthButton.onClick.AddListener(_statsViewModel.DecreaseStrength);
            _decreaseStaminaButton.onClick.AddListener(_statsViewModel.DecreaseStamina);
            _decreaseDefenseButton.onClick.AddListener(_statsViewModel.DecreaseDefense);
            _decreaseLuckButton.onClick.AddListener(_statsViewModel.DecreaseLuck);
            _decreaseManaButton.onClick.AddListener(_statsViewModel.DecreaseMana);
            _decreaseIntelligenceButton.onClick.AddListener(_statsViewModel.DecreaseIntelligence);

            _resetButton.onClick.AddListener(_buttonsViewModel.OnResetButton);
            _confirmButton.onClick.AddListener(_statsViewModel.OnConfirmButton);
        }

        private void OnIncreaseStrengthButtonEnabled(bool value) =>
            OnButtonEnabled(_increaseStrengthButton, value);

        private void OnIncreaseStaminaButtonEnabled(bool value) =>
            OnButtonEnabled(_increaseStaminaButton, value);

        private void OnIncreaseDefenseButtonEnabled(bool value) =>
            OnButtonEnabled(_increaseDefenseButton, value);

        private void OnIncreaseLuckButtonClicked(bool value) =>
            OnButtonEnabled(_increaseLuckButton, value);

        private void OnIncreaseManaButtonEnabled(bool value) =>
            OnButtonEnabled(_increaseManaButton, value);

        private void OnIncreaseIntelligenceButtonEnabled(bool value) =>
            OnButtonEnabled(_increaseIntelligenceButton, value);

        private void OnDecreaseStrengthButtonEnabled(bool value) =>
            OnButtonEnabled(_decreaseStrengthButton, value);

        private void OnDecreaseStaminaButtonEnabled(bool value) =>
            OnButtonEnabled(_decreaseStaminaButton, value);

        private void OnDecreaseDefenseButtonEnabled(bool value) =>
            OnButtonEnabled(_decreaseDefenseButton, value);

        private void OnDecreaseLuckButtonEnabled(bool value) =>
            OnButtonEnabled(_decreaseLuckButton, value);

        private void OnDecreaseManaButtonEnabled(bool value) =>
            OnButtonEnabled(_decreaseManaButton, value);

        private void OnDecreaseIntelligenceButtonEnabled(bool value) =>
            OnButtonEnabled(_decreaseIntelligenceButton, value);

        private void OnButtonEnabled(Button button, bool value)
        {
            button.enabled = value;
            button.interactable = value;
        }

        private void Dispose()
        {
            _buttonsViewModel.IncreaseStrengthButtonEnabled.OnValueChanged -= OnIncreaseStrengthButtonEnabled;
            _buttonsViewModel.IncreaseStaminaButtonEnabled.OnValueChanged -= OnIncreaseStaminaButtonEnabled;
            _buttonsViewModel.IncreaseDefenseButtonEnabled.OnValueChanged -= OnIncreaseDefenseButtonEnabled;
            _buttonsViewModel.IncreaseLuckButtonEnabled.OnValueChanged -= OnIncreaseLuckButtonClicked;
            _buttonsViewModel.IncreaseManaButtonEnabled.OnValueChanged -= OnIncreaseManaButtonEnabled;
            _buttonsViewModel.IncreaseIntelligenceButtonEnabled.OnValueChanged -= OnIncreaseIntelligenceButtonEnabled;


            _buttonsViewModel.DecreaseStrengthButtonEnabled.OnValueChanged -= OnDecreaseStrengthButtonEnabled;
            _buttonsViewModel.DecreaseStaminaButtonEnabled.OnValueChanged -= OnDecreaseStaminaButtonEnabled;
            _buttonsViewModel.DecreaseDefenseButtonEnabled.OnValueChanged -= OnDecreaseDefenseButtonEnabled;
            _buttonsViewModel.DecreaseLuckButtonEnabled.OnValueChanged -= OnDecreaseLuckButtonEnabled;
            _buttonsViewModel.DecreaseManaButtonEnabled.OnValueChanged -= OnDecreaseManaButtonEnabled;
            _buttonsViewModel.DecreaseIntelligenceButtonEnabled.OnValueChanged -= OnDecreaseIntelligenceButtonEnabled;
        }
    }
}