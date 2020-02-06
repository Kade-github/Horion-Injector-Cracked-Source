using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using MetroSet_UI.Controls;
using Newtonsoft.Json.Linq;

// Token: 0x0200000C RID: 12
internal class Class5
{
	// Token: 0x06000038 RID: 56
	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool CloseHandle(IntPtr intptr_3);

	// Token: 0x06000039 RID: 57 RVA: 0x0000352C File Offset: 0x0000172C
	private void method_0()
	{
		Console.WriteLine("Connection thread started");
		DateTime now = DateTime.Now;
		DateTime now2 = DateTime.Now;
		while (this.bool_0)
		{
			Thread.Sleep(50);
			DateTime now3 = DateTime.Now;
			if (this.bool_1)
			{
				try
				{
					Class5.Struct4 @struct = this.gclass3_0.method_0<Class5.Struct4>(this.intptr_0);
					Class5.Struct4 struct2 = this.gclass3_0.method_0<Class5.Struct4>(this.intptr_1);
					if (!@struct.bool_0)
					{
						this.bool_1 = false;
						this.method_1("Disconnected", -1);
						continue;
					}
					if (@struct.bool_1)
					{
						@struct.bool_1 = false;
						now2 = DateTime.Now;
						switch (@struct.mem_CMD_0)
						{
						case Class5.MEM_CMD.CMD_PING:
							this.method_3(new Class5.Struct4
							{
								mem_CMD_0 = Class5.MEM_CMD.CMD_PONG,
								int_1 = @struct.int_1
							});
							break;
						case Class5.MEM_CMD.CMD_PONG:
							break;
						case Class5.MEM_CMD.CMD_OPENBROWSER:
						{
							byte[] byte_ = @struct.byte_0;
							if (byte_.Length > @struct.int_6)
							{
								string @string = Encoding.Unicode.GetString(byte_, 0, @struct.int_6);
								if (@string.StartsWith("http"))
								{
									Console.WriteLine("Opening Browser: " + @string);
									Process.Start(@string);
								}
							}
							break;
						}
						default:
							Console.WriteLine("Unknown message: " + @struct.mem_CMD_0.ToString());
							break;
						}
						if (this.gclass3_0.method_1<Class5.Struct4>(this.intptr_0, @struct))
						{
							this.bool_1 = false;
							this.method_1("Disconnected", -1);
							continue;
						}
					}
					if ((now3 - now).TotalSeconds > 1.0)
					{
						this.method_3(new Class5.Struct4
						{
							mem_CMD_0 = Class5.MEM_CMD.CMD_PING,
							int_1 = 1193046
						});
						now = DateTime.Now;
					}
					if (this.queue_0.Count > 0 && !struct2.bool_1)
					{
						Class5.Struct4 gparam_ = this.queue_0.Dequeue();
						if (this.gclass3_0.method_1<Class5.Struct4>(this.intptr_1, gparam_))
						{
							this.bool_1 = false;
							this.method_1("Disconnected", -1);
							continue;
						}
					}
					if ((now3 - now2).TotalSeconds > 5.0)
					{
						this.bool_1 = false;
						this.method_1("Disconnected", -1);
					}
					else if ((now3 - now2).TotalSeconds <= 2.0)
					{
						this.method_1("Connected", 0);
					}
					else
					{
						this.method_1("Timing out...", 0);
					}
					continue;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Exception in connection thread: " + ex.Message);
					this.bool_1 = false;
					this.method_1("Disconnected", -1);
					continue;
				}
			}
			if (this.bool_0)
			{
				now = DateTime.Now;
				now2 = DateTime.Now;
				Thread.Sleep(150);
			}
		}
		Console.WriteLine("Connection thread deleted");
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00003828 File Offset: 0x00001A28
	private void method_1(string string_1, int int_1)
	{
		Class5.Class6 @class = new Class5.Class6();
		@class.class5_0 = this;
		@class.string_0 = string_1;
		@class.int_0 = int_1;
		this.metroSetLabel_0.BeginInvoke(new Action(@class.method_0));
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00003868 File Offset: 0x00001A68
	public Class5(MetroSetLabel metroSetLabel_1)
	{
		this.metroSetLabel_0 = metroSetLabel_1;
		this.method_1("Not connected", 0);
		ThreadStart start = new ThreadStart(this.method_0);
		this.thread_0 = new Thread(start);
		this.thread_0.Start();
	}

	// Token: 0x0600003C RID: 60 RVA: 0x000038D0 File Offset: 0x00001AD0
	public void method_2(IntPtr intptr_3, IntPtr intptr_4, int int_1, string string_1, bool bool_2, uint uint_0, string string_2)
	{
		this.method_1("Connecting...", 0);
		this.string_0 = string_1;
		if (this.intptr_2 != IntPtr.Zero)
		{
			Class5.CloseHandle(this.intptr_2);
			this.intptr_2 = IntPtr.Zero;
		}
		this.bool_0 = true;
		this.queue_0.Clear();
		this.gclass3_0 = new GClass3(intptr_4);
		this.intptr_2 = intptr_4;
		this.int_0 = int_1;
		try
		{
			Console.WriteLine("addrt: " + intptr_3.ToString());
			this.intptr_0 = this.gclass3_0.method_0<IntPtr>(intptr_3 + 16);
			this.intptr_1 = this.gclass3_0.method_0<IntPtr>(intptr_3 + 16 + 8);
			Console.WriteLine("horionToInjectorPtr: " + this.intptr_0.ToString());
			Console.WriteLine("injectorToHorionPtr: " + this.intptr_1.ToString());
			this.bool_1 = true;
			Class5.Struct4 @struct = default(Class5.Struct4);
			@struct.mem_CMD_0 = Class5.MEM_CMD.CMD_INIT;
			@struct.int_1 |= 1;
			if (this.string_0.Length > 10)
			{
				@struct.int_1 |= 2;
			}
			if (bool_2)
			{
				@struct.int_1 |= 4;
			}
			JObject jobject = new JObject();
			if (this.string_0.Length <= 10)
			{
				jobject["discordAuth"] = "none";
			}
			else
			{
				jobject["discordAuth"] = this.string_0;
			}
			jobject["invite"] = string_2;
			jobject["serial"] = uint_0;
			string s = jobject.ToString();
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			@struct.byte_0 = new byte[3000];
			Array.Copy(bytes, 0, @struct.byte_0, 0, bytes.Length);
			@struct.int_6 = bytes.Length;
			this.method_3(@struct);
			this.method_1("Connected", 1);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			this.bool_1 = false;
			this.method_1("Disconnected", -1);
		}
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002274 File Offset: 0x00000474
	private void method_3(Class5.Struct4 struct4_0)
	{
		struct4_0.short_0 = 1;
		struct4_0.bool_0 = true;
		struct4_0.int_0 = this.int_0;
		struct4_0.bool_1 = true;
		this.queue_0.Enqueue(struct4_0);
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00003B0C File Offset: 0x00001D0C
	public void method_4()
	{
		this.bool_0 = false;
		this.bool_1 = false;
		this.thread_0.Abort();
		if (this.intptr_2 != IntPtr.Zero)
		{
			Class5.CloseHandle(this.intptr_2);
			this.intptr_2 = IntPtr.Zero;
		}
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00003B5C File Offset: 0x00001D5C
	public Class5()
	{
		this.method_4();
	}

	// Token: 0x0400002A RID: 42
	private MetroSetLabel metroSetLabel_0;

	// Token: 0x0400002B RID: 43
	private GClass3 gclass3_0;

	// Token: 0x0400002C RID: 44
	private IntPtr intptr_0;

	// Token: 0x0400002D RID: 45
	private IntPtr intptr_1;

	// Token: 0x0400002E RID: 46
	private IntPtr intptr_2;

	// Token: 0x0400002F RID: 47
	private Queue<Class5.Struct4> queue_0 = new Queue<Class5.Struct4>();

	// Token: 0x04000030 RID: 48
	private Thread thread_0;

	// Token: 0x04000031 RID: 49
	private bool bool_0 = true;

	// Token: 0x04000032 RID: 50
	private bool bool_1;

	// Token: 0x04000033 RID: 51
	private int int_0;

	// Token: 0x04000034 RID: 52
	private string string_0 = "none";

	// Token: 0x0200000D RID: 13
	internal enum MEM_CMD
	{
		// Token: 0x04000036 RID: 54
		CMD_INIT,
		// Token: 0x04000037 RID: 55
		CMD_PING,
		// Token: 0x04000038 RID: 56
		CMD_PONG,
		// Token: 0x04000039 RID: 57
		CMD_OPENBROWSER
	}

	// Token: 0x0200000E RID: 14
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct4
	{
		// Token: 0x0400003A RID: 58
		[MarshalAs(UnmanagedType.I2)]
		public short short_0;

		// Token: 0x0400003B RID: 59
		[MarshalAs(UnmanagedType.U1)]
		public bool bool_0;

		// Token: 0x0400003C RID: 60
		[MarshalAs(UnmanagedType.U1)]
		public bool bool_1;

		// Token: 0x0400003D RID: 61
		[MarshalAs(UnmanagedType.I4)]
		public int int_0;

		// Token: 0x0400003E RID: 62
		[MarshalAs(UnmanagedType.I4)]
		public Class5.MEM_CMD mem_CMD_0;

		// Token: 0x0400003F RID: 63
		[MarshalAs(UnmanagedType.I4)]
		public int int_1;

		// Token: 0x04000040 RID: 64
		[MarshalAs(UnmanagedType.I4)]
		public int int_2;

		// Token: 0x04000041 RID: 65
		[MarshalAs(UnmanagedType.I4)]
		public int int_3;

		// Token: 0x04000042 RID: 66
		[MarshalAs(UnmanagedType.I4)]
		public int int_4;

		// Token: 0x04000043 RID: 67
		[MarshalAs(UnmanagedType.I4)]
		public int int_5;

		// Token: 0x04000044 RID: 68
		[MarshalAs(UnmanagedType.I4)]
		public int int_6;

		// Token: 0x04000045 RID: 69
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3000, ArraySubType = UnmanagedType.U1)]
		public byte[] byte_0;
	}

	// Token: 0x0200000F RID: 15
	[CompilerGenerated]
	private sealed class Class6
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00003B88 File Offset: 0x00001D88
		internal void method_0()
		{
			this.class5_0.metroSetLabel_0.Text = this.string_0;
			this.class5_0.metroSetLabel_0.BackColor = ((this.int_0 == 0) ? Color.FromArgb(255, 128, 0) : ((this.int_0 == -1) ? Color.FromArgb(255, 0, 0) : Color.FromArgb(0, 255, 0)));
		}

		// Token: 0x04000046 RID: 70
		public Class5 class5_0;

		// Token: 0x04000047 RID: 71
		public string string_0;

		// Token: 0x04000048 RID: 72
		public int int_0;
	}
}
