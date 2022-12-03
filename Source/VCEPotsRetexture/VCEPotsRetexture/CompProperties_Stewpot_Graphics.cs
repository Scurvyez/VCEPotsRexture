using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace VCEPotsRetexture
{
    public class CompProperties_Stewpot_Graphics : CompProperties
    {
        public List<GraphicDataLayered> graphicLayersEmpty;
        public List<GraphicDataLayered> graphicLayersFueled;
        public List<GraphicDataLayered> graphicLayersFullAndFueled;

        public GraphicData graphicSoupSimple;
        public GraphicData graphicSoupFine;
        public GraphicData graphicSoupLavish;
        public GraphicData graphicSoupGourmet;

        public CompProperties_Stewpot_Graphics()
        {
            compClass = typeof(Comp_Stewpot_Graphics);
        }

        public override IEnumerable<string> ConfigErrors(ThingDef parentDef)
        {
            foreach (string error in base.ConfigErrors(parentDef))
            {
                yield return error;
            }
            if (graphicLayersEmpty == null ||  graphicLayersFullAndFueled == null)
            {
                yield return "[VCEPotsRetexture]Oops! We couldn't find a textures for <graphicLayersEmpty> or <graphicLayersFullAndFueled>, please provide at least one.";
            }
        }
    }
}
