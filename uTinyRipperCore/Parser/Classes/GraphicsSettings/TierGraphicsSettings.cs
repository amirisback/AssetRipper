﻿using uTinyRipper.Classes.Cameras;
using uTinyRipper.Converters;
using uTinyRipper.YAML;

namespace uTinyRipper.Classes.GraphicsSettingss
{
	public struct TierGraphicsSettings : IAssetReadable, IYAMLExportable
	{
		/// <summary>
		/// 5.6.0 and greater
		/// </summary>
		public static bool IsReadHdrMode(Version version)
		{
			return version.IsGreaterEqual(5, 6);
		}
		/// <summary>
		/// 2017.1 and greater
		/// </summary>
		public static bool IsReadPrefer32BitShadowMaps(Version version)
		{
			return version.IsGreaterEqual(2017);
		}
		/// <summary>
		/// 5.6.3 and greater
		/// </summary>
		public static bool IsReadEnableLPPV(Version version)
		{
			return version.IsGreaterEqual(5, 6, 3);
		}
		/// <summary>
		/// 5.6.0 and greater
		/// </summary>
		public static bool IsReadUseHDR(Version version)
		{
			return version.IsGreaterEqual(5, 6);
		}

		public void Read(AssetReader reader)
		{
			RenderingPath = (RenderingPath)reader.ReadInt32();
			if (IsReadHdrMode(reader.Version))
			{
				HdrMode = (CameraHDRMode)reader.ReadInt32();
				RealtimeGICPUUsage = (RealtimeGICPUUsage)reader.ReadInt32();
			}
			UseCascadedShadowMaps = reader.ReadBoolean();
			if (IsReadPrefer32BitShadowMaps(reader.Version))
			{
				Prefer32BitShadowMaps = reader.ReadBoolean();
			}
			if (IsReadEnableLPPV(reader.Version))
			{
				EnableLPPV = reader.ReadBoolean();
			}
			if (IsReadUseHDR(reader.Version))
			{
				UseHDR = reader.ReadBoolean();
			}
			reader.AlignStream();
		}

		public YAMLNode ExportYAML(IExportContainer container)
		{
			YAMLMappingNode node = new YAMLMappingNode();
			node.Add(RenderingPathName, (int)RenderingPath);
			node.Add(HdrModeName, (int)HdrMode);
			node.Add(RealtimeGICPUUsageName, (int)RealtimeGICPUUsage);
			node.Add(UseCascadedShadowMapsName, UseCascadedShadowMaps);
			node.Add(Prefer32BitShadowMapsName, Prefer32BitShadowMaps);
			node.Add(EnableLPPVName, EnableLPPV);
			node.Add(UseHDRName, UseHDR);
			return node;
		}

		public RenderingPath RenderingPath { get; private set; }
		public CameraHDRMode HdrMode { get; private set; }
		public RealtimeGICPUUsage RealtimeGICPUUsage { get; private set; }
		public bool UseCascadedShadowMaps { get; private set; }
		public bool Prefer32BitShadowMaps { get; private set; }
		public bool EnableLPPV { get; private set; }
		public bool UseHDR { get; private set; }

		public const string RenderingPathName = "renderingPath";
		public const string HdrModeName = "hdrMode";
		public const string RealtimeGICPUUsageName = "realtimeGICPUUsage";
		public const string UseCascadedShadowMapsName = "useCascadedShadowMaps";
		public const string Prefer32BitShadowMapsName = "prefer32BitShadowMaps";
		public const string EnableLPPVName = "enableLPPV";
		public const string UseHDRName = "useHDR";
	}
}
