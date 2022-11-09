// Project:         Daggerfall Unity
// Copyright:       Copyright (C) 2009-2022 Daggerfall Workshop
// Web Site:        http://www.dfworkshop.net
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Source Code:     https://github.com/Interkarma/daggerfall-unity
// Original Author: Gavin Clayton (interkarma@dfworkshop.net)
// Contributors:    
// 
// Notes:
//

using DaggerfallConnect;
using DaggerfallConnect.Arena2;

namespace DaggerfallWorkshop.Game.MagicAndEffects.MagicEffects
{
    /// <summary>
    /// Transfer - Personality
    /// </summary>
    public class TransferPersonality : TransferEffect
    {
        public static readonly string EffectKey = "Transfer-Personality";

        public override void SetProperties()
        {
            properties.Key = EffectKey;
            properties.ClassicKey = MakeClassicKey(11, 5);
            properties.SupportMagnitude = true;
            properties.ShowSpellIcon = false;
            properties.AllowedTargets = EntityEffectBroker.TargetFlags_Other;
            properties.AllowedElements = EntityEffectBroker.ElementFlags_MagicOnly;
            properties.AllowedCraftingStations = MagicCraftingStations.SpellMaker;
            properties.MagicSkill = DFCareer.MagicSkills.Destruction;
            properties.MagnitudeCosts = MakeEffectCosts(60, 100, 40);
            drainStat = DFCareer.Stats.Personality;
        }

        public override string GroupName => TextManager.Instance.GetLocalizedText("transfer");
        public override string SubGroupName => TextManager.Instance.GetLocalizedText("personality");
        public override TextFile.Token[] SpellMakerDescription => DaggerfallUnity.Instance.TextProvider.GetRSCTokens(1555);
        public override TextFile.Token[] SpellBookDescription => DaggerfallUnity.Instance.TextProvider.GetRSCTokens(1255);
    }
}
