using UnityEngine;

namespace Assets.CodeBase.Model
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName =("ScriptableObjects/PlayerStaticData"))]
    public class PlayerDataSo : ScriptableObject
    {
        public int Strength;
        public int Stamina;
        public int Defense;
        public int Luck;
        public int Mana;
        public int Intelligence;
        public int PointsToSpend;
    }
}
