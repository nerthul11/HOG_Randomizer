﻿using HallOfGodsRandomizer.Manager;
using HallOfGodsRandomizer.Menu;
using IL.InControl.NativeDeviceProfiles;
using MenuChanger;
using MenuChanger.Extensions;
using MenuChanger.MenuElements;
using MenuChanger.MenuPanels;
using Modding;
using RandomizerMod;
using RandomizerMod.Menu;
using RandomizerMod.Settings;
using System.Linq;
using UnityEngine;

namespace HallOfGodsRandomizer.Menu
{
    public class ConnectionMenu 
    {
        private const int VSPACE_SMALL = 50;
        private const int VSPACE_MED = 200;
        private const int VSPACE_LARGE = 350;
        private const int HSPACE_LARGE = 300;
        private const int HSPACE_XLARGE = 450;
        private const int HSPACE_XXLARGE = 750;

        private SmallButton pageRootButton;
        private MenuPage randomizerPage;
        private ToggleButton enabledControl;
        private MenuEnum<StatueAccessMode> accessControl;
        private MenuEnum<TierLimitMode> tierControl;
        private MenuElementFactory<HOG_RandomizationSettings> toplevelMEF;
        internal static ConnectionMenu Instance { get; private set; }

        public static void Hook()
        {
            RandomizerMenuAPI.AddMenuPage(ConstructMenu, HandleButton);
            MenuChangerMod.OnExitMainMenu += () => Instance = null;
        }

        private static bool HandleButton(MenuPage landingPage, out SmallButton button)
        {
            button = Instance.pageRootButton;
            button.Text.color = HOG_Interop.Settings.Enabled ? Colors.TRUE_COLOR : Colors.DEFAULT_COLOR;
            return true;
        }

        private static void ConstructMenu(MenuPage connectionPage)
        {
            Instance = new(connectionPage);
        }

        private ConnectionMenu(MenuPage connectionPage)
        {
            /// Define connection page
            randomizerPage = new MenuPage(Localization.Localize("randomizerPage"), connectionPage);
            VerticalItemPanel toplevelVip = new(randomizerPage, new Vector2(0, 400), VSPACE_LARGE, true);
            MenuLabel headingLabel = new(randomizerPage, "Hall of Gods Randomizer");
            toplevelMEF = new(connectionPage, HOG_Interop.Settings);
            
            /// Define parameters
            enabledControl = (ToggleButton)toplevelMEF.ElementLookup[nameof(HOG_RandomizationSettings.Enabled)];
            enabledControl.SelfChanged += EnableSwitch;
            accessControl = (MenuEnum<StatueAccessMode>)toplevelMEF.ElementLookup[nameof(HOG_RandomizationSettings.RandomizeStatueAccess)];
            tierControl = (MenuEnum<TierLimitMode>)toplevelMEF.ElementLookup[nameof(HOG_RandomizationSettings.RandomizeTiers)];

            /// Define hierarchies
            VerticalItemPanel toplevelSettingHolder = new(randomizerPage, Vector2.zero, VSPACE_SMALL, false, toplevelMEF.Elements);
            toplevelSettingHolder.Insert(0, headingLabel);
            toplevelVip.Add(toplevelSettingHolder);
            Localization.Localize(headingLabel);
            Localization.Localize(toplevelMEF);
            toplevelVip.ResetNavigation();
            toplevelVip.SymSetNeighbor(Neighbor.Down, randomizerPage.backButton);

            /// Define top level button
            pageRootButton = new SmallButton(connectionPage, "HOG Randomizer");
            pageRootButton.AddHideAndShowEvent(connectionPage, randomizerPage);
        }
        /// Define parameter changes
        private void EnableSwitch(IValueElement obj)
        {
            pageRootButton.Text.color = HOG_Interop.Settings.Enabled ? Colors.TRUE_COLOR : Colors.DEFAULT_COLOR;
        }
    }
}