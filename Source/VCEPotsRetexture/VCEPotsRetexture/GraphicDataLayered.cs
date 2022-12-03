using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;
using RimWorld;
using UnityEngine;

namespace VCEPotsRetexture
{
	public class GraphicDataLayered : GraphicData
	{
		public int layer = 0;

		public Vector3? OriginalDrawOffset { get; private set; }

		public GraphicDataLayered() : base()
		{
		}

		public virtual void CopyFrom(GraphicDataLayered graphicData)
		{
			base.CopyFrom(graphicData);
			layer = graphicData.layer;
		}

		public virtual void PreInit()
		{
			OriginalDrawOffset = drawOffset;
			drawOffset = OriginalDrawOffset.Value;
			drawOffset.y += layer * (Altitudes.AltInc / Enum.GetNames(typeof(AltitudeLayer)).EnumerableCount());
		}
	}
}
