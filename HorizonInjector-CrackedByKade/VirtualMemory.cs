using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

// Token: 0x02000026 RID: 38
[SuppressUnmanagedCodeSecurity]
public class GClass3
{
	// Token: 0x06000080 RID: 128
	[DllImport("ntdll")]
	private static extern bool NtReadVirtualMemory(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3, int int_0, int int_1);

	// Token: 0x06000081 RID: 129
	[DllImport("ntdll")]
	private static extern bool NtWriteVirtualMemory(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3, int int_0, int int_1);

	// Token: 0x06000082 RID: 130 RVA: 0x000023EE File Offset: 0x000005EE
	public GClass3(IntPtr intptr_1)
	{
		this.intptr_0 = intptr_1;
	}

	// Token: 0x06000083 RID: 131 RVA: 0x0000A474 File Offset: 0x00008674
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T method_0<T>(IntPtr intptr_1) where T : struct
	{
		int num = Marshal.SizeOf<T>();
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		if (GClass3.NtReadVirtualMemory(this.intptr_0, intptr_1, intPtr, num, 0))
		{
			throw new Exception("");
		}
		return Marshal.PtrToStructure<T>(intPtr);
	}

	// Token: 0x06000084 RID: 132 RVA: 0x0000A4B0 File Offset: 0x000086B0
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool method_1<T>(IntPtr intptr_1, T gparam_0) where T : struct
	{
		int num = Marshal.SizeOf<T>();
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.StructureToPtr<T>(gparam_0, intPtr, false);
		bool result = GClass3.NtWriteVirtualMemory(this.intptr_0, intptr_1, intPtr, num, 0);
		Marshal.DestroyStructure<T>(intPtr);
		return result;
	}

	// Token: 0x040001F4 RID: 500
	private readonly IntPtr intptr_0;
}
