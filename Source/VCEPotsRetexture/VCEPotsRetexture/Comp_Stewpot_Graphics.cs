using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;
using UnityEngine;
using VFECore;
using VFEM;

namespace VCEPotsRetexture
{
    public class Comp_Stewpot_Graphics : ThingComp
    {
        public CompProperties_Stewpot_Graphics PotProps => (CompProperties_Stewpot_Graphics)props;

        /// <summary>
        /// Renders additional graphics on a parent thing.
        /// XML, drawerType = RealtimeOnly || MapMeshAndRealTime.
        /// </summary>
        public override void PostDraw()
        {
            base.PostDraw();
            CompRefuelable fuel = parent.GetComp<CompRefuelable>();
            ItemProcessor.Building_ItemProcessor processor = parent as ItemProcessor.Building_ItemProcessor;

            if (!fuel.HasFuel)
            {
                for (int i = 0; i < PotProps.graphicLayersEmpty.Count; i++)
                {
                    PotProps.graphicLayersEmpty[i].Graphic.Draw(parent.DrawPos, parent.Rotation, parent);
                }
            }
            else
            {
                if (processor.processorStage == ItemProcessor.ProcessorStage.Working)
                {
                    for (int j = 0; j < PotProps.graphicLayersFullAndFueled.Count; j++)
                    {
                        PotProps.graphicLayersFullAndFueled[j].Graphic.Draw(parent.DrawPos, parent.Rotation, parent);
                    }

                    if (processor.productToTurnInto == "VCE_CookedSoupSimple" ||
                        processor.productsToTurnInto.Any().ToString() == "VCE_CookedSoupSimple")
                    {
                        PotProps.graphicSoupSimple.Graphic.Draw(parent.DrawPos, parent.Rotation, parent);
                    }
                    
                    else if (processor.productToTurnInto == "VCE_CookedSoupFine" ||
                        processor.productsToTurnInto.Any().ToString() == "VCE_CookedSoupFine")
                    {
                        PotProps.graphicSoupFine.Graphic.Draw(parent.DrawPos, parent.Rotation, parent);
                    }

                    else if (processor.productToTurnInto == "VCE_CookedSoupLavish" ||
                        processor.productsToTurnInto.Any().ToString() == "VCE_CookedSoupLavish")
                    {
                        PotProps.graphicSoupLavish.Graphic.Draw(parent.DrawPos, parent.Rotation, parent);
                    }

                    else
                    {
                        PotProps.graphicSoupGourmet.Graphic.Draw(parent.DrawPos, parent.Rotation, parent);
                    }
                }

                else
                {
                    for (int k = 0; k < PotProps.graphicLayersFueled.Count; k++)
                    {
                        PotProps.graphicLayersFueled[k].Graphic.Draw(parent.DrawPos, parent.Rotation, parent);
                    }
                }
            }
            parent.DefaultGraphic.Draw(parent.DrawPos, parent.Rotation, parent);
        }

        public override void Initialize(CompProperties props)
        {
            base.Initialize(props);
        }
    }
}
