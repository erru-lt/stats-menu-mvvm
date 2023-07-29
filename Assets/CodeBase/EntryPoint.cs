using Assets.CodeBase.Model;
using Assets.CodeBase.Services;
using Assets.CodeBase.View;
using Assets.CodeBase.ViewModel;
using Assets.Data;
using UnityEngine;

namespace Assets.CodeBase
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private StatsView _statsView;
        [SerializeField] private ButtonsView _buttonsView;

        private Player _playerData;
        private PlayerStats _playerStats;
        private StatsViewModel _statsViewModel;
        private ButtonsViewModel _buttonsViewModel;
        private JSONDataLoader _jsonDataLoader;
        
        private void Start()
        {
            _jsonDataLoader = new JSONDataLoader();

            LoadDataFromJson();
            InitializePlayerStats(_playerData);

            _statsViewModel = new StatsViewModel(_playerStats);
            _buttonsViewModel = new ButtonsViewModel(_statsViewModel);

            _statsView.Construct(_statsViewModel);
            _buttonsView.Construct(_statsViewModel, _buttonsViewModel);

            _statsView.Initialize();
            _buttonsView.Initialize();
        }

        private void LoadDataFromJson() => 
            _playerData = _jsonDataLoader.Load<Player>(Application.dataPath + DataPath.JSONPlayerDataPath);

        private void InitializePlayerStats(Player playerData)
        {
            _playerStats = new PlayerStats(
                playerData.Strength,
                playerData.Stamina,
                playerData.Defense,
                playerData.Luck,
                playerData.Mana,
                playerData.Intelligence,
                playerData.PointsToSpend);
        }
    }
}
