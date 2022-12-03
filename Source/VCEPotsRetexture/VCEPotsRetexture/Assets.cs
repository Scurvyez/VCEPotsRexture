using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;
using UnityEngine;

namespace VCEPotsRetexture
{
	[StaticConstructorOnStartup]
	public static class Assets
	{
		public static readonly Material PotAndRack =
			MaterialPool.MatFrom("Stewpot/Stewpot_potandrack_south", ShaderDatabase.Transparent);
	}
}
