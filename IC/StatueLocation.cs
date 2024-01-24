using HutongGames.PlayMaker;
using ItemChanger;
using ItemChanger.Extensions;
using ItemChanger.FsmStateActions;
using ItemChanger.Locations;
using ItemChanger.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HallOfGodsRandomizer.IC 
{
    /// <summary>
    /// Each location should add an item when completing a tier for the first time.
    /// The method for setting statueState completion boolean values should be overriden.
    /// </summary>
    public class VoidIdolAggregatorModule : Module
    {
        private Dictionary<int, List<VoidIdolLocation>> statuePlacements = new();
        private ParametricFsmEditBuilder<int>? statueEditBuilder;

        public override void Initialize()
        {
            statueEditBuilder = new(GenerateStatueEdit);
            for (int i = 0; i < 3; i++)
            {
                string goFullPath = $"/GG_Statue_Knight/Base/Statue/Knight_v0{i + 1}/Interact";
                Events.AddFsmEdit(SceneNames.GG_Workshop, new(goFullPath, "Conversation Control"), statueEditBuilder.GetOrAddEdit(i));
            }
        }

        public override void Unload()
        {
            for (int i = 0; i < 3; i++)
            {
                string goFullPath = $"/GG_Statue_Knight/Base/Statue/Knight_v0{i + 1}/Interact";
                Events.RemoveFsmEdit(SceneNames.GG_Workshop, new(goFullPath, "Conversation Control"), statueEditBuilder![i]);
            }
        }

        private bool AreAllStatuePlacementsCleared(int statueTier)
        {
            if (statuePlacements.TryGetValue(statueTier, out List<VoidIdolLocation> locs))
            {
                return locs.All(x => x.Placement.AllObtained());
            }
            // if there's no placement... well of course the entire statue is cleared, there's no items here.
            return true;
        }

        private void ChainGiveAllPlacementsAsync(int statueTier, Transform t, Action callback)
        {
            if (!statuePlacements.TryGetValue(statueTier, out List<VoidIdolLocation> locs))
            {
                callback?.Invoke();
            }

            Action aggregated = () => callback?.Invoke();
            foreach (VoidIdolLocation loc in locs)
            {
                aggregated = ConcatGiveAll(aggregated, t, loc);
            }
            aggregated?.Invoke();

            static Action ConcatGiveAll(Action aggregated, Transform t, VoidIdolLocation loc)
            {
                return () => loc.GiveAllAsync(t)(aggregated);
            }
        }

        private Action<PlayMakerFSM> GenerateStatueEdit(int statueTier)
        {
            return (self) =>
            {
                FsmState journal = self.GetState("Journal");
                journal.Actions = new FsmStateAction[]
                {
                    new DelegateBoolTest(() => AreAllStatuePlacementsCleared(statueTier), "FINISHED", null),
                    new AsyncLambda((callback) => ChainGiveAllPlacementsAsync(statueTier, self.gameObject.transform, callback))
                };
            };
        }

        public void PlaceItemsAtStatue(int statueTier, VoidIdolLocation loc)
        {
            if (!statuePlacements.ContainsKey(statueTier))
            {
                statuePlacements[statueTier] = new List<VoidIdolLocation>();
            }
            if (!statuePlacements[statueTier].Contains(loc))
            {
                statuePlacements[statueTier].Add(loc);
            }
        }

        public void RemoveItemsFromStatue(int statueTier, VoidIdolLocation loc)
        {
            if (statuePlacements.TryGetValue(statueTier, out List<VoidIdolLocation> locs))
            {
                locs.Remove(loc);
            }
        }
    }
    
    
    public class StatueLocation : AutoLocation
    {
        public enum Tier
        {
            Unlock,
            Attuned,
            Ascended,
            Radiant
        }
        public string statueStateName { get; set; }
        public Tier statueTier { get; set; }
        public string statueName { get; set; }

        protected override void OnUnload()
        {
        }

        protected override void OnLoad()
        {
        }
    }
}