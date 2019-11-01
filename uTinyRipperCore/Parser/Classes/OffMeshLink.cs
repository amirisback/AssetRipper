﻿using System.Collections.Generic;
using uTinyRipper.Converters;
using uTinyRipper.YAML;

namespace uTinyRipper.Classes
{
	public sealed class OffMeshLink : Behaviour
	{
		public OffMeshLink(AssetInfo assetInfo):
			base(assetInfo)
		{
		}

		/// <summary>
		/// 4.0.0 and greater
		/// </summary>
		public static bool IsReadAreaIndex(Version version)
		{
			return version.IsGreaterEqual(4);
		}
		/// <summary>
		/// 5.6.0 and greater
		/// </summary>
		public static bool IsReadAgentTypeID(Version version)
		{
			return version.IsGreaterEqual(5, 6);
		}
		/// <summary>
		/// Less than 5.0.0
		/// </summary>
		public static bool IsReadDtPolyRef(Version version)
		{
			return version.IsLess(5);
		}
		/// <summary>
		/// 4.3.0 and greater
		/// </summary>
		public static bool IsReadAutoUpdatePositions(Version version)
		{
			return version.IsGreaterEqual(4, 3);
		}

		private static int GetSerializedVersion(Version version)
		{
			// m_NavMeshLayer has been renamed to m_AreaIndex
			if (version.IsGreaterEqual(5))
			{
				return 3;
			}
			if (version.IsGreaterEqual(4))
			{
				return 2;
			}
			return 1;
		}

		public override void Read(AssetReader reader)
		{
			base.Read(reader);

			if (IsReadAreaIndex(reader.Version))
			{
				AreaIndex = reader.ReadUInt32();
			}
			if (IsReadAgentTypeID(reader.Version))
			{
				AgentTypeID = reader.ReadInt32();
			}
			Start.Read(reader);
			End.Read(reader);
			if (IsReadDtPolyRef(reader.Version))
			{
				DtPolyRef = reader.ReadUInt32();
			}
			CostOverride = reader.ReadSingle();
			reader.AlignStream();
			
			BiDirectional = reader.ReadBoolean();
			Activated = reader.ReadBoolean();
			if (IsReadAutoUpdatePositions(reader.Version))
			{
				AutoUpdatePositions = reader.ReadBoolean();
			}
		}

		public override IEnumerable<PPtr<Object>> FetchDependencies(DependencyContext context)
		{
			foreach (PPtr<Object> asset in base.FetchDependencies(context))
			{
				yield return asset;
			}

			yield return context.FetchDependency(Start, StartName);
			yield return context.FetchDependency(End, EndName);
		}

		protected override YAMLMappingNode ExportYAMLRoot(IExportContainer container)
		{
			YAMLMappingNode node = base.ExportYAMLRoot(container);
			node.AddSerializedVersion(GetSerializedVersion(container.ExportVersion));
			node.Add(AreaIndexName, AreaIndex);
			node.Add(AgentTypeIDName, AgentTypeID);
			node.Add(StartName, Start.ExportYAML(container));
			node.Add(EndName, End.ExportYAML(container));
			node.Add(CostOverrideName, CostOverride);
			node.Add(BiDirectionalName, BiDirectional);
			node.Add(ActivatedName, Activated);
			node.Add(AutoUpdatePositionsName, AutoUpdatePositions);
			return node;
		}

		/// <summary>
		/// NavMeshLayer previously
		/// </summary>
		public uint AreaIndex { get; private set; }
		public int AgentTypeID { get; private set; }
		public uint DtPolyRef { get; private set; }
		public float CostOverride { get; private set; }
		public bool BiDirectional { get; private set; }
		public bool Activated { get; private set; }
		public bool AutoUpdatePositions { get; private set; }

		public const string NavMeshLayerName = "m_NavMeshLayer";
		public const string AreaIndexName = "m_AreaIndex";
		public const string AgentTypeIDName = "m_AgentTypeID";
		public const string StartName = "m_Start";
		public const string EndName = "m_End";
		public const string DtPolyRefName = "m_DtPolyRef";
		public const string CostOverrideName = "m_CostOverride";
		public const string BiDirectionalName = "m_BiDirectional";
		public const string ActivatedName = "m_Activated";
		public const string AutoUpdatePositionsName = "m_AutoUpdatePositions";

		public PPtr<Transform> Start;
		public PPtr<Transform> End;
	}
}
