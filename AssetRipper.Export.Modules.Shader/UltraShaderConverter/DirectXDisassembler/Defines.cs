﻿namespace AssetRipper.Export.Modules.Shaders.UltraShaderConverter.DirectXDisassembler
{
	//tokens.h
	public enum Opcode
	{
		add,
		and,
		@break,
		breakc,
		call,
		callc,
		@case,
		@continue,
		continuec,
		cut,
		@default,
		deriv_rtx,
		deriv_rty,
		discard,
		div,
		dp2,
		dp3,
		dp4,
		@else,
		emit,
		emit_then_cut,
		endif,
		endloop,
		endswitch,
		eq,
		exp,
		frc,
		ftoi,
		ftou,
		ge,
		iadd,
		@if,
		ieq,
		ige,
		ilt,
		imad,
		imax,
		imin,
		imul,
		ine,
		ineg,
		ishl,
		ishr,
		itof,
		label,
		ld,
		ldms,
		log,
		loop,
		lt,
		mad,
		min,
		max,
		customdata,
		mov,
		movc,
		mul,
		ne,
		nop,
		not,
		or,
		resinfo,
		ret,
		retc,
		round_ne,
		round_ni,
		round_pi,
		round_z,
		rsq,
		sample,
		sample_c,
		sample_c_lz,
		sample_l,
		sample_d,
		sample_b,
		sqrt,
		@switch,
		sincos,
		udiv,
		ult,
		uge,
		umul,
		umad,
		umax,
		umin,
		ushr,
		utof,
		xor,
		dcl_resource,
		dcl_constantbuffer,
		dcl_sampler,
		dcl_indexrange,
		dcl_outputtopology,
		dcl_inputprimitive,
		dcl_maxout,
		dcl_input,
		dcl_input_sgv,
		dcl_input_siv,
		dcl_input_ps,
		dcl_input_ps_sgv,
		dcl_input_ps_siv,
		dcl_output,
		dcl_output_sgv,
		dcl_output_siv,
		dcl_temps,
		dcl_indexableTemp,
		dcl_globalFlags,
		reserved1,
		lod,
		gather4,
		samplepos,
		sampleinfo,
		reserved2,
		hs_decls,
		hs_control_point_phase,
		hs_fork_phase,
		hs_join_phase,
		emit_stream,
		cut_stream,
		emit_then_cut_stream,
		fcall,
		bufinfo,
		deriv_rtx_coarse,
		deriv_rtx_fine,
		deriv_rty_coarse,
		deriv_rty_fine,
		gather4_c,
		gather4_po,
		gather4_po_c,
		rcp,
		f32tof16,
		f16tof32,
		uaddc,
		usubb,
		countbits,
		firstbit_hi,
		firstbit_lo,
		firstbit_shi,
		ubfe,
		ibfe,
		bfi,
		bfrev,
		swapc,
		dcl_stream,
		dcl_function_body,
		dcl_function_table,
		dcl_interface,
		dcl_input_control_point_count,
		dcl_output_control_point_count,
		dcl_tessellator_domain,
		dcl_tessellator_paritioning,
		dcl_tessellator_output_primitive,
		dcl_hs_max_tessfactor,
		dcl_hs_fork_phase_instance_count,
		dcl_hs_join_phase_instance_count,
		dcl_thread_group,
		dcl_uav_typed,
		dcl_uav_raw,
		dcl_uav_structured,
		dcl_tgsm_raw,
		dcl_tgsm_structured,
		dcl_resource_raw,
		dcl_resource_structured,
		ld_uav_typed,
		store_uav_typed,
		ld_raw,
		store_raw,
		ld_structured,
		store_structured,
		atomic_and,
		atomic_or,
		atomic_xor,
		atomic_cmp_store,
		atomic_iadd,
		atomic_imax,
		atomic_imin,
		atomic_umax,
		atomic_umin,
		imm_atomic_alloc,
		imm_atomic_consume,
		imm_atomic_iadd,
		imm_atomic_and,
		imm_atomic_or,
		imm_atomic_xor,
		imm_atomic_exch,
		imm_atomic_cmp_exch,
		imm_atomic_imax,
		imm_atomic_imin,
		imm_atomic_umax,
		imm_atomic_umin,
		sync,
		dadd,
		dmax,
		dmin,
		dmul,
		deq,
		dge,
		dlt,
		dne,
		dmov,
		dmovc,
		dtof,
		ftod,
		eval_snapped,
		eval_sample_index,
		eval_centroid,
		dcl_gsinstances,
		abort,
		debug_break,
		reserved3,
		ddiv,
		dfma,
		drcp,
		msad,
		dtoi,
		dtou,
		itod,
		utod,
		reserved4
	}
	public enum Operand
	{
		ImmConstInt = -9,
		TexCoord,
		Position,
		Fog,
		PointSize,
		OutOffsetColor,
		OutBaseColor,
		Address,
		ImmConst,
		Temp = 0,
		Input,
		Output,
		IndexableTemp,
		Immediate32,
		Immediate64,
		Sampler,
		Resource,
		ConstantBuffer,
		ImmediateConstantBuffer,
		Label,
		InputPrimitiveID,
		OutputDepth,
		Null,
		Rasterizer,
		OutputCoverageMask,
		Stream,
		FunctionBody,
		FunctionTable,
		Interface,
		FunctionInput,
		FunctionOutput,
		OutputControlPointID,
		InputForkInstanceID,
		InputJoinInstanceID,
		InputControlPoint,
		OutputControlPoint,
		InputPatchConstant,
		InputDomainPoint,
		ThisPointer,
		UnorderedAccessView,
		ThreadGroupSharedMemory,
		InputThreadID,
		InputThreadGroupID,
		InputThreadIDInGroup,
		InputCoverageMask,
		InputThreadIDInGroupFlattened,
		InputGSInstanceID,
		OutputDepthGreaterEqual,
		OutputDepthLessEqual,
		CycleCounter,
		StencilRef,
		InnerCoverage
	}
	public enum Type
	{
		Pixel,
		Vertex,
		Geometry,
		Hull,
		Domain,
		Compute
	}
	public enum OperandIndex
	{
		Immediate32,
		Immediate64,
		IndexRelative,
		Immediate32Relative,
		Immediate64Relative
	}
	public enum ResourceDimension
	{
		Unknown,
		buffer,
		texture1d,
		texture2d,
		texture2dms,
		texture3d,
		texturecube,
		texture1darray,
		texture2darray,
		texture2dmsarray,
		texturecubearray,
		raw_buffer,
		structured_buffer
	}
	public enum InterpolationMode
	{
		undefined,
		constant,
		linear,
		linear_centroi,
		linear_noperspective,
		linear_noperspective_centroid,
		linear_sample,
		linear_noperspective_sample,
	}
	public enum ConstantBufferType
	{
		ImmediateIndexed,
		DynamicIndexed
	}

	public enum SamplerMode
	{
		Default,
		Comparison
	}
	public enum PrimitiveTopology
	{
		Undefined,
		pointlist,
		linelist,
		linestrip,
		trianglelist,
		trianglestrip,
		linelistadj,
		linestripadj,
		trianglelistadj,
		trianglestripadj
	}
	public enum Primitive
	{
		Undefined,
		point,
		line,
		triangle,
		lineadj,
		triangleadj,
		patch1,
		patch2,
		patch3,
		patch4,
		patch5,
		patch6,
		patch7,
		patch8,
		patch9,
		patch10,
		patch11,
		patch12,
		patch13,
		patch14,
		patch15,
		patch16,
		patch17,
		patch18,
		patch19,
		patch20,
		patch21,
		patch22,
		patch23,
		patch24,
		patch25,
		patch26,
		patch27,
		patch28,
		patch29,
		patch30,
		patch31,
		patch32
	}
	public enum TessDomain
	{
		Undefined,
		domain_isoline,
		domain_tri,
		domain_quad
	}
	public enum TessPartitioning
	{
		Undefined,
		integer,
		pow2,
		fractional_odd,
		fractional_even
	}
	public enum TessOutputPrimitive
	{
		Undefined,
		point,
		line,
		triangle_cw,
		triangle_ccw
	}
	public enum ResourceReturnType
	{
		UNorm,
		SNorm,
		SInt,
		UInt,
		Float,
		Mixed,
		Double,
		Continued,
		Unused
	}
	public enum SysValueType //
	{
		none,
		pos,
		clipdst,
		culldst,
		rtindex,
		vpindex,
		vertid,
		primid,
		instid,
		fface,
		sample,
		quadedge,
		quadint,
		triedge,
		triint,
		linedet,
		lineden
	}
	public enum FormatType
	{
		unknown,
		@uint,
		@int,
		@float
	}
	public enum ExtendedOpcodeType
	{
		Empty,
		SampleControls,
		ResourceDim,
		ResourceReturnType
	}
}