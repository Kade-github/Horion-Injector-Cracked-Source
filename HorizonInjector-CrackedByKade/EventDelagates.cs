using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Token: 0x0200002B RID: 43
public class GClass5
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x0600008A RID: 138 RVA: 0x0000A4E8 File Offset: 0x000086E8
	// (remove) Token: 0x0600008B RID: 139 RVA: 0x0000A520 File Offset: 0x00008720
	public event GClass5.GDelegate0 Event_0
	{
		[CompilerGenerated]
		add
		{
			GClass5.GDelegate0 gdelegate = this.gdelegate0_0;
			GClass5.GDelegate0 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GClass5.GDelegate0 value2 = (GClass5.GDelegate0)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GClass5.GDelegate0>(ref this.gdelegate0_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GClass5.GDelegate0 gdelegate = this.gdelegate0_0;
			GClass5.GDelegate0 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GClass5.GDelegate0 value2 = (GClass5.GDelegate0)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GClass5.GDelegate0>(ref this.gdelegate0_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x0600008C RID: 140
	[DllImport("kernel32.dll")]
	public static extern void GetSystemInfo(out GStruct7 gstruct7_0);

	// Token: 0x0600008D RID: 141
	[DllImport("kernel32.dll")]
	public static extern IntPtr OpenProcess(uint uint_0, bool bool_0, int int_1);

	// Token: 0x0600008E RID: 142
	[DllImport("kernel32.dll")]
	public static extern bool CloseHandle(IntPtr intptr_2);

	// Token: 0x0600008F RID: 143
	[DllImport("kernel32.dll")]
	public static extern int VirtualQueryEx(IntPtr intptr_2, IntPtr intptr_3, out GStruct8 gstruct8_0, uint uint_0);

	// Token: 0x06000090 RID: 144
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool ReadProcessMemory(IntPtr intptr_2, IntPtr intptr_3, byte[] byte_0, uint uint_0, out int int_1);

	// Token: 0x06000091 RID: 145
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool WriteProcessMemory(IntPtr intptr_2, IntPtr intptr_3, byte[] byte_0, int int_1, out int int_2);

	// Token: 0x06000092 RID: 146 RVA: 0x0000A55C File Offset: 0x0000875C
	public GClass5()
	{
		GStruct7 gstruct;
		GClass5.GetSystemInfo(out gstruct);
		this.intptr_1 = gstruct.intptr_1;
		this.method_0();
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00002435 File Offset: 0x00000635
	private void method_0()
	{
		this.intptr_0 = IntPtr.Zero;
		this.dictionary_0 = new Dictionary<IntPtr, byte[]>();
		this.list_0 = new List<GClass4>();
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00002458 File Offset: 0x00000658
	public void method_1(GClass5.GDelegate0 gdelegate0_1)
	{
		this.gdelegate0_0 = gdelegate0_1;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000A588 File Offset: 0x00008788
	public void method_2(int int_1)
	{
		if (this.intptr_0 != IntPtr.Zero)
		{
			this.method_4();
			this.method_0();
		}
		this.int_0 = int_1;
		this.intptr_0 = GClass5.OpenProcess(1080u, false, int_1);
		if (this.intptr_0 == IntPtr.Zero)
		{
			throw new Exception("Failed to open process " + int_1.ToString() + ". Error code: " + Marshal.GetLastWin32Error().ToString());
		}
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00002461 File Offset: 0x00000661
	public void method_3(int int_1, IntPtr intptr_2)
	{
		if (this.intptr_0 != IntPtr.Zero)
		{
			this.method_0();
		}
		this.int_0 = int_1;
		this.intptr_0 = intptr_2;
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00002489 File Offset: 0x00000689
	public void method_4()
	{
		GClass5.CloseHandle(this.intptr_0);
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00002497 File Offset: 0x00000697
	public void method_5()
	{
		this.dictionary_0.Clear();
	}

	// Token: 0x06000099 RID: 153 RVA: 0x0000A608 File Offset: 0x00008808
	private void method_6()
	{
		if (this.intptr_0 == IntPtr.Zero)
		{
			throw new InvalidOperationException("Cannot dump process memory regions. No process loaded.");
		}
		this.dictionary_0.Clear();
		IntPtr zero = IntPtr.Zero;
		GStruct8 gstruct = default(GStruct8);
		Console.WriteLine("Handle: " + this.intptr_0.ToString());
		while ((long)zero < (long)this.intptr_1 && (long)zero >= 0L && GClass5.VirtualQueryEx(this.intptr_0, zero, out gstruct, (uint)Marshal.SizeOf(typeof(GStruct8))) != 0)
		{
			if (gstruct.int_2 == 4096)
			{
				if (gstruct.int_3 == 4 && (uint)gstruct.ulong_2 != 0u)
				{
					byte[] array = new byte[(int)gstruct.ulong_2];
					int num = 0;
					if (!GClass5.ReadProcessMemory(this.intptr_0, new IntPtr((long)gstruct.ulong_0), array, (uint)gstruct.ulong_2, out num))
					{
						throw new Exception("Failed to read process memory at search " + gstruct.ulong_0.ToString() + ". Error code: " + Marshal.GetLastWin32Error().ToString());
					}
					this.dictionary_0.Add(new IntPtr((long)gstruct.ulong_0), array);
				}
			}
			zero = new IntPtr((long)(gstruct.ulong_0 + gstruct.ulong_2));
		}
	}

	// Token: 0x0600009A RID: 154 RVA: 0x000024A4 File Offset: 0x000006A4
	private void method_7(int int_1)
	{
		if (this.gdelegate0_0 != null)
		{
			this.gdelegate0_0(int_1);
		}
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000A764 File Offset: 0x00008964
	public void method_8(byte[] byte_0, Action action_0 = null)
	{
		if (this.intptr_0 == IntPtr.Zero)
		{
			throw new InvalidOperationException("Cannot scan process memory regions. No process loaded.");
		}
		if (byte_0.Length != 0)
		{
			this.list_0.Clear();
			this.method_6();
			this.method_7(0);
			int num = 0;
			foreach (IntPtr intPtr in this.dictionary_0.Keys)
			{
				foreach (int offset in GClass0.smethod_5(this.dictionary_0[intPtr], byte_0))
				{
					this.list_0.Add(new GClass4(IntPtr.Add(intPtr, offset), byte_0));
				}
				num++;
				this.method_7(num / this.dictionary_0.Count * 100);
			}
			this.method_7(100);
			if (action_0 != null)
			{
				action_0();
			}
			return;
		}
		throw new ArgumentOutOfRangeException("Buffer cannot be of length 0.");
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0000A870 File Offset: 0x00008A70
	public void method_9(byte[] byte_0, Action action_0 = null)
	{
		if (this.intptr_0 == IntPtr.Zero)
		{
			throw new InvalidOperationException("Cannot scan process memory regions. No process loaded.");
		}
		if (byte_0.Length == 0)
		{
			throw new ArgumentOutOfRangeException("Buffer cannot be of length 0.");
		}
		this.method_6();
		this.method_7(0);
		int num = 0;
		GClass4[] array = this.list_0.ToArray();
		int i = 0;
		while (i < array.Length)
		{
			GClass4 gclass = array[i];
			if (!this.dictionary_0.ContainsKey(gclass.IntPtr_0))
			{
				using (Dictionary<IntPtr, byte[]>.KeyCollection.Enumerator enumerator = this.dictionary_0.Keys.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IntPtr intPtr = enumerator.Current;
						int num2 = (int)intPtr;
						int num3 = num2 + this.dictionary_0[intPtr].Length;
						int num4 = (int)gclass.IntPtr_0;
						if (num4 >= num2 && num4 <= num3)
						{
							if (!GClass0.smethod_1(this.dictionary_0[intPtr], byte_0, num4 - num2))
							{
								this.list_0.Remove(gclass);
								break;
							}
							gclass.Byte_0 = byte_0;
							break;
						}
					}
					goto IL_13B;
				}
				goto IL_10B;
			}
			goto IL_10B;
			IL_13B:
			num++;
			this.method_7(num / this.dictionary_0.Count * 100);
			i++;
			continue;
			IL_10B:
			if (!GClass0.smethod_1(this.dictionary_0[gclass.IntPtr_0], byte_0, 0))
			{
				this.list_0.Remove(gclass);
				goto IL_13B;
			}
			gclass.Byte_0 = byte_0;
			goto IL_13B;
		}
		this.method_7(100);
		if (action_0 != null)
		{
			action_0();
		}
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000AA00 File Offset: 0x00008C00
	public byte[] method_10(IntPtr intptr_2, int int_1)
	{
		if (this.intptr_0 == IntPtr.Zero)
		{
			throw new InvalidOperationException("Cannot read process memory at " + intptr_2.ToString() + ". No process loaded.");
		}
		if (intptr_2 == IntPtr.Zero)
		{
			throw new ArgumentOutOfRangeException("Cannot read process memory. Invalid memory address.");
		}
		if (int_1 < 1)
		{
			throw new ArgumentOutOfRangeException("Cannot read process memory of size " + int_1.ToString() + ".");
		}
		byte[] array = new byte[int_1];
		int num;
		if (!GClass5.ReadProcessMemory(this.intptr_0, intptr_2, array, (uint)array.Length, out num))
		{
			throw new Exception("Failed to read process memory at readMemory() " + intptr_2.ToString() + ". Error code: " + Marshal.GetLastWin32Error().ToString());
		}
		return array;
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000AAB8 File Offset: 0x00008CB8
	public void method_11(IntPtr intptr_2, byte[] byte_0)
	{
		if (this.intptr_0 == IntPtr.Zero)
		{
			throw new InvalidOperationException("Cannot write process memory at " + intptr_2.ToString() + ". No process loaded.");
		}
		if (intptr_2 == IntPtr.Zero)
		{
			throw new ArgumentOutOfRangeException("Cannot write process memory. Invalid memory address.");
		}
		if (byte_0.Length < 1)
		{
			throw new ArgumentOutOfRangeException("Cannot write process memory of size " + byte_0.Length.ToString() + ".");
		}
		int num;
		if (!GClass5.WriteProcessMemory(this.intptr_0, intptr_2, byte_0, byte_0.Length, out num))
		{
			throw new Exception("Failed to write process memory at " + intptr_2.ToString() + ". Error code: " + Marshal.GetLastWin32Error().ToString());
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x0600009F RID: 159 RVA: 0x000024BA File Offset: 0x000006BA
	public IntPtr IntPtr_0
	{
		get
		{
			return this.intptr_0;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x060000A0 RID: 160 RVA: 0x000024C2 File Offset: 0x000006C2
	public GClass4[] GClass4_0
	{
		get
		{
			return this.list_0.ToArray();
		}
	}

	// Token: 0x04000210 RID: 528
	private IntPtr intptr_0;

	// Token: 0x04000211 RID: 529
	private int int_0;

	// Token: 0x04000212 RID: 530
	private IntPtr intptr_1;

	// Token: 0x04000213 RID: 531
	private Dictionary<IntPtr, byte[]> dictionary_0;

	// Token: 0x04000214 RID: 532
	private List<GClass4> list_0;

	// Token: 0x04000215 RID: 533
	[CompilerGenerated]
	private GClass5.GDelegate0 gdelegate0_0;

	// Token: 0x0200002C RID: 44
	// (Invoke) Token: 0x060000A2 RID: 162
	public delegate void GDelegate0(int value);
}
