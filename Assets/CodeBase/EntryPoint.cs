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
        [SerializeField] private CharacterAnimator _characterAnimator;

        private PlayerDataSo _playerSo;
        private PlayerStats _playerStats;
        private StatsViewModel _statsViewModel;
        private ButtonsViewModel _buttonsViewModel;
        private StaticDataLoader _staticDataLoader;

        private void Start()
        {
            _staticDataLoader = new StaticDataLoader();

            LoadDataFromStaticDataLoader();
            InitializePlayerStats(_playerSo);

            _statsViewModel = new StatsViewModel(_playerStats, _characterAnimator);
            _buttonsViewModel = new ButtonsViewModel(_statsViewModel);

            _statsView.Construct(_statsViewModel);
            _buttonsView.Construct(_statsViewModel, _buttonsViewModel);

            _statsView.Initialize();
            _buttonsView.Initialize();
        }

        private void LoadDataFromStaticDataLoader() => 
            _playerSo = _staticDataLoader.Load<PlayerDataSo>(DataPath.PlaerStaticDataPath);

        private void InitializePlayerStats(PlayerDataSo playerData)
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
