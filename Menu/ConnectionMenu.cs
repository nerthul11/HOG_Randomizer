﻿using HallOfGodsRandomizer.Manager;
using MenuChanger;
using MenuChanger.Extensions;
using MenuChanger.MenuElements;
using MenuChanger.MenuPanels;
using RandomizerMod.Menu;
using UnityEngine;

namespace HallOfGodsRandomizer.Menu
{
    public class ConnectionMenu 
    {
        // Top-level definitions
        internal static ConnectionMenu Instance { get; private set; }
        private readonly SmallButton pageRootButton;

        // Menu page and elements
        private readonly MenuPage hogPage;
        private MenuElementFactory<HallOfGodsRandomizationSettings> elementFactory;

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
            // Define connection page
            hogPage = new MenuPage("hogPage", connectionPage);
            elementFactory = new(hogPage, HOG_Interop.Settings);
            VerticalItemPanel topLevelPanel = new(hogPage, new Vector2(0, 400), 350, true);
            
            // Define parameters
            MenuLabel headingLabel = new(hogPage, "Hall of Gods Randomizer");
            elementFactory.ElementLookup["Enabled"].SelfChanged += EnableSwitch;

            // Define hierarchies
            VerticalItemPanel settingHolder = new(hogPage, Vector2.zero, 100, false, [
                elementFactory.ElementLookup["Enabled"],
                elementFactory.ElementLookup["RandomizeTiers"],
                elementFactory.ElementLookup["RandomizeStatueAccess"]
            ]);
            settingHolder.Insert(0, headingLabel);
            topLevelPanel.Add(settingHolder);
            topLevelPanel.ResetNavigation();
            topLevelPanel.SymSetNeighbor(Neighbor.Down, hogPage.backButton);

            // Define top level button
            pageRootButton = new SmallButton(connectionPage, "HOG Randomizer");
            pageRootButton.AddHideAndShowEvent(connectionPage, hogPage);
        }
        // Define parameter changes
        private void EnableSwitch(IValueElement obj)
        {
            pageRootButton.Text.color = HOG_Interop.Settings.Enabled ? Colors.TRUE_COLOR : Colors.DEFAULT_COLOR;
        }
    }
}