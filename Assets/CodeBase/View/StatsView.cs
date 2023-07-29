using Assets.CodeBase.ViewModel;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.View
{
    public class StatsView : MonoBehaviour, IView
    {
        private StatsViewModel _statsViewModel;

        [SerializeField] private TMP_Text _strengthStatText;
        [SerializeField] private TMP_Text _staminaStatText;
        [SerializeField] private TMP_Text _defenseStatText;
        [SerializeField] private TMP_Text _luckStatText;
        [SerializeField] private TMP_Text _manaStatText;
        [SerializeField] private TMP_Text _intelligenceStatText;
        [SerializeField] private TMP_Text _pointsToSpendText;

        public void Construct(StatsViewModel statsViewModel) =>
            _statsViewModel = statsViewModel;

        public void Initialize()
        {
            DisplayStatsText();
            SubscribeOnStatsChanges();
        }

        private void OnDestroy() =>
            Dispose();

        private void SubscribeOnStatsChanges()
        {
            _statsViewModel.StrengthView.OnValueChanged += DisplayStrengthText;
            _statsViewModel.StaminaView.OnValueChanged += DisplayStaminaText;
            _statsViewModel.DefenseView.OnValueChanged += DisplayDefenseText;
            _statsViewModel.LuckView.OnValueChanged += DisplaytLuckText;
            _statsViewModel.ManaView.OnValueChanged += DisplayManaText;
            _statsViewModel.IntelligenceView.OnValueChanged += DisplayIntelligenceText;
            _statsViewModel.PointsToSpendView.OnValueChanged += DisplayPointsToSpendView;
        }

        private void DisplayStatsText()
        {
            _strengthStatText.text = _statsViewModel.StrengthView.Value.ToString();
            _staminaStatText.text = _statsViewModel.StaminaView.Value.ToString();
            _defenseStatText.text = _statsViewModel.DefenseView.Value.ToString();
            _luckStatText.text = _statsViewModel.LuckView.Value.ToString();
            _manaStatText.text = _statsViewModel.ManaView.Value.ToString();
            _intelligenceStatText.text = _statsViewModel.IntelligenceView.Value.ToString();
            _pointsToSpendText.text = _statsViewModel.PointsToSpendView.Value.ToString();
        }

        private void DisplayStrengthText(int value) =>
            _strengthStatText.text = value.ToString();

        private void DisplayStaminaText(int value) =>
            _staminaStatText.text = value.ToString();

        private void DisplayDefenseText(int value) =>
            _defenseStatText.text = value.ToString();

        private void DisplaytLuckText(int value) =>
            _luckStatText.text = value.ToString();

        private void DisplayManaText(int value) =>
            _manaStatText.text = value.ToString();

        private void DisplayIntelligenceText(int value) =>
            _intelligenceStatText.text = value.ToString();

        private void DisplayPointsToSpendView(int value) =>
            _pointsToSpendText.text = value.ToString();

        private void Dispose()
        {
            _statsViewModel.StrengthView.OnValueChanged -= DisplayStrengthText;
            _statsViewModel.StaminaView.OnValueChanged -= DisplayStaminaText;
            _statsViewModel.DefenseView.OnValueChanged -= DisplayDefenseText;
            _statsViewModel.LuckView.OnValueChanged -= DisplaytLuckText;
            _statsViewModel.ManaView.OnValueChanged -= DisplayManaText;
            _statsViewModel.IntelligenceView.OnValueChanged -= DisplayIntelligenceText;
            _statsViewModel.PointsToSpendView.OnValueChanged -= DisplayPointsToSpendView;
        }
    }
}