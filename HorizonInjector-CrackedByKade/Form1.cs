using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Child;
using MetroSet_UI.Controls;
using MetroSet_UI.Forms;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace HorizonInjector_CrackedByKade
{
    public partial class Form1 : MetroSetForm
	{
		// Token: 0x06000042 RID: 66
		[DllImport("Kernel32.dll", SetLastError = true)]
		private static extern bool GetVolumeInformation(string string_5, StringBuilder stringBuilder_0, int int_9, out uint uint_4, out uint uint_5, out uint uint_6, StringBuilder stringBuilder_1, int int_10);

		// Token: 0x06000043 RID: 67
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int int_9, bool bool_4, int int_10);

		// Token: 0x06000044 RID: 68
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CloseHandle(IntPtr intptr_0);

		// Token: 0x06000045 RID: 69
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string string_5);

		// Token: 0x06000046 RID: 70
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_5);

		// Token: 0x06000047 RID: 71
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr intptr_0, IntPtr intptr_1, uint uint_4, uint uint_5, uint uint_6);

		// Token: 0x06000048 RID: 72
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, uint uint_4, out UIntPtr uintptr_0);

		// Token: 0x06000049 RID: 73
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr intptr_0, IntPtr intptr_1, uint uint_4, IntPtr intptr_2, IntPtr intptr_3, uint uint_5, IntPtr intptr_4);

		// Token: 0x0600004A RID: 74
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int WaitForSingleObject(IntPtr intptr_0, int int_9);

		// Token: 0x0600004B RID: 75
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		private static extern uint GetNamedSecurityInfoW(string string_5, Form1.GEnum0 genum0_0, SecurityInfos securityInfos_0, out IntPtr intptr_0, out IntPtr intptr_1, out IntPtr intptr_2, out IntPtr intptr_3, out IntPtr intptr_4);

		// Token: 0x0600004C RID: 76
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		private static extern uint SetNamedSecurityInfoW(string string_5, Form1.GEnum0 genum0_0, SecurityInfos securityInfos_0, IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3);

		// Token: 0x0600004D RID: 77
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr ConvertStringSidToSidW(string string_5, out IntPtr intptr_0);

		// Token: 0x0600004E RID: 78
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr LocalFree(IntPtr intptr_0);

		// Token: 0x0600004F RID: 79
		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern uint SetEntriesInAcl(int int_9, ref Form1.Struct5 struct5_0, IntPtr intptr_0, out IntPtr intptr_1);

		// Token: 0x06000050 RID: 80
		[DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern bool AdjustTokenPrivileges(IntPtr intptr_0, bool bool_4, ref Form1.Struct7 struct7_0, int int_9, IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x06000051 RID: 81
		[DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern bool OpenProcessToken(Process process_0, int int_9, ref IntPtr intptr_0);

		// Token: 0x06000052 RID: 82
		[DllImport("advapi32.dll", SetLastError = true)]
		internal static extern bool LookupPrivilegeValue(string string_5, string string_6, ref long long_0);

		// Token: 0x06000053 RID: 83 RVA: 0x00003BF8 File Offset: 0x00001DF8
		private void method_0(bool bool_4)
		{
			if (bool_4)
			{
				this.metroSetButton_0.Font = new Font("Segoe UI", 48f);
				this.metroSetButton_3.Font = new Font("Segoe UI", 27.75f);
				this.metroSetButton_4.Font = new Font("Segoe UI", 27.75f);
				this.metroSetButton_1.Font = new Font("Segoe UI", 27.75f);
				this.metroSetButton_2.Font = new Font("Segoe UI", 27.75f);
				return;
			}
			this.metroSetButton_0.Font = new Font("Constantia", 48f, FontStyle.Bold);
			this.metroSetButton_3.Font = new Font("Constantia", 27.75f);
			this.metroSetButton_4.Font = new Font("Constantia", 27.75f);
			this.metroSetButton_1.Font = new Font("Constantia", 27.75f);
			this.metroSetButton_2.Font = new Font("Constantia", 27.75f);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003D14 File Offset: 0x00001F14
		private void method_1()
		{
			try
			{
				JObject jobject = new JObject();
				jobject["token"] = this.string_3;
				jobject["path"] = this.string_2;
				jobject["segoe"] = this.bool_1;
				File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "injk.conf"), Convert.ToBase64String(Encoding.UTF8.GetBytes(jobject.ToString())));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Config could not be saved:\n" + ex.Message);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003DC0 File Offset: 0x00001FC0
		public Form1()
		{
			InitializeComponent();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000022A7 File Offset: 0x000004A7
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.class5_0.method_4();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003E10 File Offset: 0x00002010
		private void Form1_Load(object sender, EventArgs e)
		{
			base.FormClosed += this.Form1_FormClosed;
			this.class5_0 = new Class5(this.metroSetLabel_10);
			try
			{
				string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "injk.conf");
				if (!File.Exists(path))
				{
					this.method_1();
				}
				else
				{
					object arg = JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(File.ReadAllText(path))));
					if (Form1.Class7.callSite_1 == null)
					{
						Form1.Class7.callSite_1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Form1)));
					}
					Func<CallSite, object, string> target = Form1.Class7.callSite_1.Target;
					CallSite callSite_ = Form1.Class7.callSite_1;
					if (Form1.Class7.callSite_0 == null)
					{
						Form1.Class7.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "token", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					this.string_3 = target(callSite_, Form1.Class7.callSite_0.Target(Form1.Class7.callSite_0, arg));
					if (Form1.Class7.callSite_3 == null)
					{
						Form1.Class7.callSite_3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Form1)));
					}
					Func<CallSite, object, string> target2 = Form1.Class7.callSite_3.Target;
					CallSite callSite_2 = Form1.Class7.callSite_3;
					if (Form1.Class7.callSite_2 == null)
					{
						Form1.Class7.callSite_2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "path", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					this.string_2 = target2(callSite_2, Form1.Class7.callSite_2.Target(Form1.Class7.callSite_2, arg));
					if (Form1.Class7.callSite_5 == null)
					{
						Form1.Class7.callSite_5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(bool), typeof(Form1)));
					}
					Func<CallSite, object, bool> target3 = Form1.Class7.callSite_5.Target;
					CallSite callSite_3 = Form1.Class7.callSite_5;
					if (Form1.Class7.callSite_4 == null)
					{
						Form1.Class7.callSite_4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "segoe", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					this.bool_1 = target3(callSite_3, Form1.Class7.callSite_4.Target(Form1.Class7.callSite_4, arg));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Config could not be loaded:\n" + ex.Message);
				this.method_1();
			}
			if (this.bool_1)
			{
				this.metroSetSwitch_0.Switched = true;
			}
			this.method_0(this.bool_1);
			try
			{
				Task<string> task = new WebClient
				{
					Headers =
				{
					{
						HttpRequestHeader.UserAgent,
						"HorionInjector"
					}
				},
					Proxy = null
				}.DownloadStringTaskAsync(new Uri("http://www.horionbeta.club:50451/version"));
				while (!task.IsCompleted)
				{
					Application.DoEvents();
					Thread.Sleep(3);
				}
				object arg2 = JObject.Parse(task.Result);
				if (Form1.Class7.callSite_8 == null)
				{
					Form1.Class7.callSite_8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Form1)));
				}
				Func<CallSite, object, string> target4 = Form1.Class7.callSite_8.Target;
				CallSite callSite_4 = Form1.Class7.callSite_8;
				if (Form1.Class7.callSite_7 == null)
				{
					Form1.Class7.callSite_7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, object> target5 = Form1.Class7.callSite_7.Target;
				CallSite callSite_5 = Form1.Class7.callSite_7;
				if (Form1.Class7.callSite_6 == null)
				{
					Form1.Class7.callSite_6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "discord", typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				this.string_1 = target4(callSite_4, target5(callSite_5, Form1.Class7.callSite_6.Target(Form1.Class7.callSite_6, arg2)));
				this.metroSetLabel_7.Text = "discord.gg/" + this.string_1;
				if (Form1.Class7.callSite_11 == null)
				{
					Form1.Class7.callSite_11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target6 = Form1.Class7.callSite_11.Target;
				CallSite callSite_6 = Form1.Class7.callSite_11;
				if (Form1.Class7.callSite_10 == null)
				{
					Form1.Class7.callSite_10 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, int, object> target7 = Form1.Class7.callSite_10.Target;
				CallSite callSite_7 = Form1.Class7.callSite_10;
				if (Form1.Class7.callSite_9 == null)
				{
					Form1.Class7.callSite_9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "injectorversion", typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				if (target6(callSite_6, target7(callSite_7, Form1.Class7.callSite_9.Target(Form1.Class7.callSite_9, arg2), 2)))
				{
					MessageBox.Show("New Injector version available! (But ignored due to Modified Injector)");
				}
				if (Form1.Class7.callSite_13 == null)
				{
					Form1.Class7.callSite_13 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
				}
				Func<CallSite, object, string> target8 = Form1.Class7.callSite_13.Target;
				CallSite callSite_8 = Form1.Class7.callSite_13;
				if (Form1.Class7.callSite_12 == null)
				{
					Form1.Class7.callSite_12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "motd", typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				if (target8(callSite_8, Form1.Class7.callSite_12.Target(Form1.Class7.callSite_12, arg2)).Length > 0)
				{
					if (Form1.Class7.callSite_15 == null)
					{
						Form1.Class7.callSite_15 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
					}
					Func<CallSite, object, string> target9 = Form1.Class7.callSite_15.Target;
					CallSite callSite_9 = Form1.Class7.callSite_15;
					if (Form1.Class7.callSite_14 == null)
					{
						Form1.Class7.callSite_14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "motd", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					this.string_4 = target9(callSite_9, Form1.Class7.callSite_14.Target(Form1.Class7.callSite_14, arg2));
					MetroSetLabel metroSetLabel = this.metroSetLabel_1;
					metroSetLabel.Text = metroSetLabel.Text + "\n" + this.string_4;
					this.metroSetLabel_1.Refresh();
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine("error: " + ex2.Message);
			}
			uint num;
			uint num2;
			Form1.GetVolumeInformation("C:\\", null, 0, out this.uint_3, out num, out num2, null, 0);
			string[] subKeyNames = Registry.ClassesRoot.OpenSubKey("Installer\\Dependencies").GetSubKeyNames();
			bool flag = false;
			bool flag2 = false;
			foreach (string text in subKeyNames)
			{
				if (text.StartsWith("VC,redist.x64,amd64,14."))
				{
					flag = true;
					try
					{
						string text2 = text.Substring("VC,redist.x64,amd64,14.".Length);
						text2 = text2.Substring(0, text2.IndexOf(","));
						if (int.Parse(text2) < 23)
						{
							flag2 = true;
							flag = false;
						}
					}
					catch (Exception ex3)
					{
						Console.WriteLine(ex3.Message);
					}
					IL_6BE:
					if (!flag)
					{
						if (!flag2)
						{
							MessageBox.Show("You need to install the 2015 - 2019 visual c++ redistributable in order to use Horion");
						}
						else
						{
							MessageBox.Show("Your C++ redistributable is too old to be used with Horion, try reinstalling it if you have problems with injecting");
						}
						Process.Start("https://aka.ms/vs/16/release/vc_redist.x64.exe");
					}
					if (this.string_3.Length > 10)
					{
						try
						{
							this.metroSetLabel_3.Text = "Logging in...";
							string text3 = new WebClient
							{
								Headers =
							{
								{
									HttpRequestHeader.UserAgent,
									"HorionInjector"
								}
							},
								Proxy = null
							}.DownloadString("http://www.horionbeta.club:50451/api/beta/check?client=" + this.string_3 + "&serial=" + this.uint_3.ToString());
							object arg3 = JObject.Parse(text3);
							this.metroSetLabel_3.Text = "";
							if (Form1.Class7.callSite_23 == null)
							{
								Form1.Class7.callSite_23 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, bool> target10 = Form1.Class7.callSite_23.Target;
							CallSite callSite_10 = Form1.Class7.callSite_23;
							if (Form1.Class7.callSite_16 == null)
							{
								Form1.Class7.callSite_16 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ContainsKey", null, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							object obj = Form1.Class7.callSite_16.Target(Form1.Class7.callSite_16, arg3, "name");
							if (Form1.Class7.callSite_22 == null)
							{
								Form1.Class7.callSite_22 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							object arg5;
							if (!Form1.Class7.callSite_22.Target(Form1.Class7.callSite_22, obj))
							{
								if (Form1.Class7.callSite_21 == null)
								{
									Form1.Class7.callSite_21 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, object, object> target11 = Form1.Class7.callSite_21.Target;
								CallSite callSite_11 = Form1.Class7.callSite_21;
								object arg4 = obj;
								if (Form1.Class7.callSite_20 == null)
								{
									Form1.Class7.callSite_20 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								Func<CallSite, object, int, object> target12 = Form1.Class7.callSite_20.Target;
								CallSite callSite_12 = Form1.Class7.callSite_20;
								if (Form1.Class7.callSite_19 == null)
								{
									Form1.Class7.callSite_19 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Length", typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, object> target13 = Form1.Class7.callSite_19.Target;
								CallSite callSite_13 = Form1.Class7.callSite_19;
								if (Form1.Class7.callSite_18 == null)
								{
									Form1.Class7.callSite_18 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, object> target14 = Form1.Class7.callSite_18.Target;
								CallSite callSite_14 = Form1.Class7.callSite_18;
								if (Form1.Class7.callSite_17 == null)
								{
									Form1.Class7.callSite_17 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								arg5 = target11(callSite_11, arg4, target12(callSite_12, target13(callSite_13, target14(callSite_14, Form1.Class7.callSite_17.Target(Form1.Class7.callSite_17, arg3))), 0));
							}
							else
							{
								arg5 = obj;
							}
							if (target10(callSite_10, arg5))
							{
								if (Form1.Class7.callSite_28 == null)
								{
									Form1.Class7.callSite_28 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, bool> target15 = Form1.Class7.callSite_28.Target;
								CallSite callSite_15 = Form1.Class7.callSite_28;
								if (Form1.Class7.callSite_27 == null)
								{
									Form1.Class7.callSite_27 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								Func<CallSite, object, int, object> target16 = Form1.Class7.callSite_27.Target;
								CallSite callSite_16 = Form1.Class7.callSite_27;
								if (Form1.Class7.callSite_26 == null)
								{
									Form1.Class7.callSite_26 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Length", typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, object> target17 = Form1.Class7.callSite_26.Target;
								CallSite callSite_17 = Form1.Class7.callSite_26;
								if (Form1.Class7.callSite_25 == null)
								{
									Form1.Class7.callSite_25 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, object> target18 = Form1.Class7.callSite_25.Target;
								CallSite callSite_18 = Form1.Class7.callSite_25;
								if (Form1.Class7.callSite_24 == null)
								{
									Form1.Class7.callSite_24 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								if (target15(callSite_15, target16(callSite_16, target17(callSite_17, target18(callSite_18, Form1.Class7.callSite_24.Target(Form1.Class7.callSite_24, arg3))), 1)))
								{
									MetroSetLabel metroSetLabel2 = this.metroSetLabel_3;
									Control control = metroSetLabel2;
									if (Form1.Class7.callSite_33 == null)
									{
										Form1.Class7.callSite_33 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
									}
									Func<CallSite, object, string> target19 = Form1.Class7.callSite_33.Target;
									CallSite callSite_19 = Form1.Class7.callSite_33;
									if (Form1.Class7.callSite_32 == null)
									{
										Form1.Class7.callSite_32 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, string, object, object> target20 = Form1.Class7.callSite_32.Target;
									CallSite callSite_20 = Form1.Class7.callSite_32;
									string text4 = metroSetLabel2.Text;
									if (Form1.Class7.callSite_31 == null)
									{
										Form1.Class7.callSite_31 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									Func<CallSite, object, string, object> target21 = Form1.Class7.callSite_31.Target;
									CallSite callSite_21 = Form1.Class7.callSite_31;
									if (Form1.Class7.callSite_30 == null)
									{
										Form1.Class7.callSite_30 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, string, object, object> target22 = Form1.Class7.callSite_30.Target;
									CallSite callSite_22 = Form1.Class7.callSite_30;
									string arg6 = "Welcome ";
									if (Form1.Class7.callSite_29 == null)
									{
										Form1.Class7.callSite_29 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									control.Text = target19(callSite_19, target20(callSite_20, text4, target21(callSite_21, target22(callSite_22, arg6, Form1.Class7.callSite_29.Target(Form1.Class7.callSite_29, arg3)), "!\n")));
								}
								else
								{
									if (Form1.Class7.callSite_37 == null)
									{
										Form1.Class7.callSite_37 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, bool> target23 = Form1.Class7.callSite_37.Target;
									CallSite callSite_23 = Form1.Class7.callSite_37;
									if (Form1.Class7.callSite_36 == null)
									{
										Form1.Class7.callSite_36 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									Func<CallSite, object, string, object> target24 = Form1.Class7.callSite_36.Target;
									CallSite callSite_24 = Form1.Class7.callSite_36;
									if (Form1.Class7.callSite_35 == null)
									{
										Form1.Class7.callSite_35 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, object> target25 = Form1.Class7.callSite_35.Target;
									CallSite callSite_25 = Form1.Class7.callSite_35;
									if (Form1.Class7.callSite_34 == null)
									{
										Form1.Class7.callSite_34 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									if (target23(callSite_23, target24(callSite_24, target25(callSite_25, Form1.Class7.callSite_34.Target(Form1.Class7.callSite_34, arg3)), "n")))
									{
										MetroSetLabel metroSetLabel3 = this.metroSetLabel_3;
										metroSetLabel3.Text += "Join the discord!\n";
									}
								}
							}
							Console.WriteLine(text3);
							if (Form1.Class7.callSite_40 == null)
							{
								Form1.Class7.callSite_40 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, bool> target26 = Form1.Class7.callSite_40.Target;
							CallSite callSite_26 = Form1.Class7.callSite_40;
							if (Form1.Class7.callSite_39 == null)
							{
								Form1.Class7.callSite_39 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Func<CallSite, object, string, object> target27 = Form1.Class7.callSite_39.Target;
							CallSite callSite_27 = Form1.Class7.callSite_39;
							if (Form1.Class7.callSite_38 == null)
							{
								Form1.Class7.callSite_38 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							if (!target26(callSite_26, target27(callSite_27, Form1.Class7.callSite_38.Target(Form1.Class7.callSite_38, arg3), "success")))
							{
								if (Form1.Class7.callSite_43 == null)
								{
									Form1.Class7.callSite_43 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, bool> target28 = Form1.Class7.callSite_43.Target;
								CallSite callSite_28 = Form1.Class7.callSite_43;
								if (Form1.Class7.callSite_42 == null)
								{
									Form1.Class7.callSite_42 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								Func<CallSite, object, string, object> target29 = Form1.Class7.callSite_42.Target;
								CallSite callSite_29 = Form1.Class7.callSite_42;
								if (Form1.Class7.callSite_41 == null)
								{
									Form1.Class7.callSite_41 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								if (!target28(callSite_28, target29(callSite_29, Form1.Class7.callSite_41.Target(Form1.Class7.callSite_41, arg3), "nobeta")))
								{
									if (Form1.Class7.callSite_46 == null)
									{
										Form1.Class7.callSite_46 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, bool> target30 = Form1.Class7.callSite_46.Target;
									CallSite callSite_30 = Form1.Class7.callSite_46;
									if (Form1.Class7.callSite_45 == null)
									{
										Form1.Class7.callSite_45 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									Func<CallSite, object, string, object> target31 = Form1.Class7.callSite_45.Target;
									CallSite callSite_31 = Form1.Class7.callSite_45;
									if (Form1.Class7.callSite_44 == null)
									{
										Form1.Class7.callSite_44 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
										{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									if (!target30(callSite_30, target31(callSite_31, Form1.Class7.callSite_44.Target(Form1.Class7.callSite_44, arg3), "login")))
									{
										MetroSetLabel metroSetLabel2 = this.metroSetLabel_3;
										Control control2 = metroSetLabel2;
										if (Form1.Class7.callSite_50 == null)
										{
											Form1.Class7.callSite_50 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
										}
										Func<CallSite, object, string> target32 = Form1.Class7.callSite_50.Target;
										CallSite callSite_32 = Form1.Class7.callSite_50;
										if (Form1.Class7.callSite_49 == null)
										{
											Form1.Class7.callSite_49 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof(Form1), new CSharpArgumentInfo[]
											{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, string, object, object> target33 = Form1.Class7.callSite_49.Target;
										CallSite callSite_33 = Form1.Class7.callSite_49;
										string text5 = metroSetLabel2.Text;
										if (Form1.Class7.callSite_48 == null)
										{
											Form1.Class7.callSite_48 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
											{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, string, object, object> target34 = Form1.Class7.callSite_48.Target;
										CallSite callSite_34 = Form1.Class7.callSite_48;
										string arg7 = "Status:\n";
										if (Form1.Class7.callSite_47 == null)
										{
											Form1.Class7.callSite_47 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
											{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										control2.Text = target32(callSite_32, target33(callSite_33, text5, target34(callSite_34, arg7, Form1.Class7.callSite_47.Target(Form1.Class7.callSite_47, arg3))));
										this.metroSetButton_3.Enabled = true;
									}
									else
									{
										this.metroSetLabel_3.Text = "Not logged in";
										this.metroSetButton_3.Enabled = true;
									}
								}
								else
								{
									MetroSetLabel metroSetLabel4 = this.metroSetLabel_3;
									metroSetLabel4.Text += "Not a beta user!\nBoost the discord server with Nitro\nOr donate to patreon.com/horion";
									this.metroSetButton_3.Enabled = true;
								}
							}
							else
							{
								MetroSetLabel metroSetLabel5 = this.metroSetLabel_3;
								metroSetLabel5.Text += "Beta available!";
								this.metroSetButton_3.Enabled = false;
							}
							this.metroSetButton_4.Enabled = !this.metroSetButton_3.Enabled;
							return;
						}
						catch (WebException ex4)
						{
							this.metroSetLabel_3.Text = "A Web Exception occured:\n" + ex4.Message;
							return;
						}
					}
					this.string_3 = GClass2.smethod_0(32);
					this.method_1();
					return;
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000022B4 File Offset: 0x000004B4
		private void metroSetTabControl_0_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000022B4 File Offset: 0x000004B4
		private void metroSetTabPage_0_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000022B6 File Offset: 0x000004B6
		private void method_2(object sender, DownloadProgressChangedEventArgs e)
		{
			this.metroSetProgressBar_0.Value = e.ProgressPercentage / 2 + 40;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000022CE File Offset: 0x000004CE
		private void method_3(object sender, DownloadProgressChangedEventArgs e)
		{
			this.metroSetProgressBar_1.Value = e.ProgressPercentage / 2 + 30;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000022B4 File Offset: 0x000004B4
		private void method_4(object object_0, AsyncCompletedEventHandler asyncCompletedEventHandler_0)
		{
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000051C0 File Offset: 0x000033C0
		private void metroSetButton_0_Click(object sender, EventArgs e)
		{
			string text = "";
			bool flag = false;
			((MetroSetButton)sender).Enabled = false;
			try
			{
				WebClient webClient = new WebClient();
				webClient.Headers.Add(HttpRequestHeader.UserAgent, "Horion");
				webClient.Proxy = null;
				this.metroSetLabel_1.Text = "Retrieving...";
				this.metroSetLabel_1.Refresh();
				this.metroSetProgressBar_0.Value = 10;
				this.metroSetProgressBar_0.Refresh();
				string text2 = webClient.DownloadString("https://api.github.com/repos/horionclient/Horion-Releases/releases/latest");
				this.metroSetLabel_1.Text = "Parsing...";
				this.metroSetLabel_1.Refresh();
				this.metroSetProgressBar_0.Value = 20;
				this.metroSetProgressBar_0.Refresh();
				object arg = JObject.Parse(text2);
				int num = 0;
				this.metroSetProgressBar_0.Value = 30;
				this.metroSetProgressBar_0.Refresh();
				for (; ; )
				{
					if (Form1.Class8.callSite_3 == null)
					{
						Form1.Class8.callSite_3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target = Form1.Class8.callSite_3.Target;
					CallSite callSite_ = Form1.Class8.callSite_3;
					if (Form1.Class8.callSite_2 == null)
					{
						Form1.Class8.callSite_2 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, object, object> target2 = Form1.Class8.callSite_2.Target;
					CallSite callSite_2 = Form1.Class8.callSite_2;
					if (Form1.Class8.callSite_1 == null)
					{
						Form1.Class8.callSite_1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					Func<CallSite, object, int, object> target3 = Form1.Class8.callSite_1.Target;
					CallSite callSite_3 = Form1.Class8.callSite_1;
					if (Form1.Class8.callSite_0 == null)
					{
						Form1.Class8.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "assets", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					if (!target(callSite_, target2(callSite_2, target3(callSite_3, Form1.Class8.callSite_0.Target(Form1.Class8.callSite_0, arg), num), null)))
					{
						goto IL_748;
					}
					if (Form1.Class8.callSite_7 == null)
					{
						Form1.Class8.callSite_7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
					}
					Func<CallSite, object, string> target4 = Form1.Class8.callSite_7.Target;
					CallSite callSite_4 = Form1.Class8.callSite_7;
					if (Form1.Class8.callSite_6 == null)
					{
						Form1.Class8.callSite_6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> target5 = Form1.Class8.callSite_6.Target;
					CallSite callSite_5 = Form1.Class8.callSite_6;
					if (Form1.Class8.callSite_5 == null)
					{
						Form1.Class8.callSite_5 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					Func<CallSite, object, int, object> target6 = Form1.Class8.callSite_5.Target;
					CallSite callSite_6 = Form1.Class8.callSite_5;
					if (Form1.Class8.callSite_4 == null)
					{
						Form1.Class8.callSite_4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "assets", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					if (target4(callSite_4, target5(callSite_5, target6(callSite_6, Form1.Class8.callSite_4.Target(Form1.Class8.callSite_4, arg), num))).ToLower().Contains("dll"))
					{
						break;
					}
					num++;
				}
				this.metroSetLabel_1.Text = "Downloading...";
				MetroSetLabel metroSetLabel = this.metroSetLabel_1;
				metroSetLabel.Text += "\n";
				MetroSetLabel metroSetLabel2 = this.metroSetLabel_1;
				Control control = metroSetLabel2;
				if (Form1.Class8.callSite_10 == null)
				{
					Form1.Class8.callSite_10 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
				}
				Func<CallSite, object, string> target7 = Form1.Class8.callSite_10.Target;
				CallSite callSite_7 = Form1.Class8.callSite_10;
				if (Form1.Class8.callSite_9 == null)
				{
					Form1.Class8.callSite_9 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, string, object, object> target8 = Form1.Class8.callSite_9.Target;
				CallSite callSite_8 = Form1.Class8.callSite_9;
				string text3 = metroSetLabel2.Text;
				if (Form1.Class8.callSite_8 == null)
				{
					Form1.Class8.callSite_8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				control.Text = target7(callSite_7, target8(callSite_8, text3, Form1.Class8.callSite_8.Target(Form1.Class8.callSite_8, arg)));
				MetroSetLabel metroSetLabel3 = this.metroSetLabel_1;
				metroSetLabel3.Text += "\n";
				metroSetLabel2 = this.metroSetLabel_1;
				Control control2 = metroSetLabel2;
				if (Form1.Class8.callSite_13 == null)
				{
					Form1.Class8.callSite_13 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
				}
				Func<CallSite, object, string> target9 = Form1.Class8.callSite_13.Target;
				CallSite callSite_9 = Form1.Class8.callSite_13;
				if (Form1.Class8.callSite_12 == null)
				{
					Form1.Class8.callSite_12 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, string, object, object> target10 = Form1.Class8.callSite_12.Target;
				CallSite callSite_10 = Form1.Class8.callSite_12;
				string text4 = metroSetLabel2.Text;
				if (Form1.Class8.callSite_11 == null)
				{
					Form1.Class8.callSite_11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "tag_name", typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				control2.Text = target9(callSite_9, target10(callSite_10, text4, Form1.Class8.callSite_11.Target(Form1.Class8.callSite_11, arg)));
				this.metroSetLabel_1.Refresh();
				webClient.DownloadProgressChanged += this.method_2;
				text = Path.Combine(Path.GetTempPath(), "Horion.dll");
				Application.DoEvents();
				this.metroSetProgressBar_0.Value = 40;
				WebClient webClient2 = webClient;
				if (Form1.Class8.callSite_17 == null)
				{
					Form1.Class8.callSite_17 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
				}
				Func<CallSite, object, string> target11 = Form1.Class8.callSite_17.Target;
				CallSite callSite_11 = Form1.Class8.callSite_17;
				if (Form1.Class8.callSite_16 == null)
				{
					Form1.Class8.callSite_16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "browser_download_url", typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, object> target12 = Form1.Class8.callSite_16.Target;
				CallSite callSite_12 = Form1.Class8.callSite_16;
				if (Form1.Class8.callSite_15 == null)
				{
					Form1.Class8.callSite_15 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Func<CallSite, object, int, object> target13 = Form1.Class8.callSite_15.Target;
				CallSite callSite_13 = Form1.Class8.callSite_15;
				if (Form1.Class8.callSite_14 == null)
				{
					Form1.Class8.callSite_14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "assets", typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				webClient2.DownloadFileAsync(new Uri(target11(callSite_11, target12(callSite_12, target13(callSite_13, Form1.Class8.callSite_14.Target(Form1.Class8.callSite_14, arg), num)))), text);
				while (webClient.IsBusy)
				{
					Application.DoEvents();
					Thread.Sleep(3);
				}
				this.metroSetLabel_1.Text = "Done";
				this.metroSetLabel_1.Refresh();
				if (File.Exists(text) && new FileInfo(text).Length > 500L)
				{
					flag = true;
				}
				else
				{
					MessageBox.Show("Dll could not be downloaded, check your Anti Virus!");
				}
				IL_748:;
			}
			catch (WebException ex)
			{
				MessageBox.Show(ex.ToString());
				((MetroSetButton)sender).Enabled = true;
				return;
			}
			if (flag)
			{
				this.metroSetLabel_1.Text = "Injecting...";
				this.metroSetLabel_1.Refresh();
				this.metroSetProgressBar_0.Value = 90;
				this.metroSetProgressBar_0.Refresh();
				string text5 = this.method_6(text, this.metroSetProgressBar_0);
				if (text5 == "")
				{
					this.metroSetLabel_1.Text = "Done!";
					this.metroSetLabel_1.Refresh();
				}
				else
				{
					this.metroSetLabel_1.Text = text5;
					this.metroSetLabel_1.Refresh();
				}
				this.metroSetProgressBar_0.Value = 100;
				this.metroSetProgressBar_0.Refresh();
			}
			((MetroSetButton)sender).Enabled = true;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000022E6 File Offset: 0x000004E6
		private void method_5()
		{
			Application.DoEvents();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005A00 File Offset: 0x00003C00
		private string method_6(string string_5, MetroSetProgressBar metroSetProgressBar_3)
		{
			string fileName = Path.GetFileName(string_5);
			int num = (metroSetProgressBar_3 == null) ? 0 : metroSetProgressBar_3.Value;
			float num2 = (float)(100 - num) / 100f;
			Console.WriteLine("Injecting dll from: " + string_5);
			if (!File.Exists(string_5))
			{
				return "The dll was deleted before it could be injected\nCheck your antivirus";
			}
			if (new FileInfo(string_5).Length < 100L)
			{
				return "The dll is smaller than 100 bytes\nCheck your antivirus if you think that this is a problem";
			}
			foreach (Process process in Process.GetProcesses())
			{
				if (process.ProcessName.ToLower().Equals("minecraft.windows.exe") || process.ProcessName.ToLower().Equals("minecraft.windows"))
				{
					int id = process.Id;
					IntPtr intPtr = Form1.OpenProcess(1146, false, id);
					Console.WriteLine("procHandle: " + intPtr.ToString());
					if (!(intPtr == IntPtr.Zero))
					{
						if (metroSetProgressBar_3 != null)
						{
							metroSetProgressBar_3.Value = (int)((float)num + 30f * num2);
							metroSetProgressBar_3.Refresh();
						}
						ProcessModuleCollection modules = process.Modules;
						for (int j = 0; j < modules.Count; j++)
						{
							if (modules[j].ModuleName == fileName)
							{
								return "Dll already injected";
							}
						}
						if (metroSetProgressBar_3 != null)
						{
							metroSetProgressBar_3.Value = (int)((float)num + 50f * num2);
							metroSetProgressBar_3.Refresh();
						}
						IntPtr procAddress = Form1.GetProcAddress(Form1.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
						Console.WriteLine("loadLibraryAddr: " + procAddress.ToString());
						this.method_7(string_5);
						IntPtr intPtr2 = Form1.VirtualAllocEx(intPtr, IntPtr.Zero, (uint)(Encoding.ASCII.GetBytes(string_5).Length + 1), 12288u, 64u);
						UIntPtr uintPtr;
						if (intPtr2 == IntPtr.Zero)
						{
							MessageBox.Show("Alloc Error " + Marshal.GetLastWin32Error().ToString());
						}
						else if (!Form1.WriteProcessMemory(intPtr, intPtr2, Encoding.ASCII.GetBytes(string_5), (uint)(string_5.Length + 1), out uintPtr))
						{
							MessageBox.Show("Write Error " + Marshal.GetLastWin32Error().ToString());
						}
						else
						{
							IntPtr intPtr3 = Form1.CreateRemoteThread(intPtr, IntPtr.Zero, 0u, procAddress, intPtr2, 0u, IntPtr.Zero);
							if (!(intPtr3 == IntPtr.Zero))
							{
								if (metroSetProgressBar_3 != null)
								{
									metroSetProgressBar_3.Value = (int)((float)num + 70f * num2);
									metroSetProgressBar_3.Refresh();
								}
								Form1.WaitForSingleObject(intPtr3, 5000);
								DateTime now = DateTime.Now;
								bool flag = false;
								while (now > DateTime.Now.AddSeconds(-5.0))
								{
									DateTime now2 = DateTime.Now;
									while (now > DateTime.Now.AddMilliseconds(-300.0))
									{
										Thread.Sleep(5);
										Application.DoEvents();
									}
									process.Refresh();
									ProcessModuleCollection modules2 = process.Modules;
									for (int k = 0; k < modules2.Count; k++)
									{
										if (modules2[k].ModuleName == fileName)
										{
											flag = true;
											goto IL_32C;
										}
									}
									continue;
									IL_32C:
									if (metroSetProgressBar_3 != null)
									{
										metroSetProgressBar_3.Value = (int)((float)num + 90f * num2);
									}
									if (!flag)
									{
										Form1.CloseHandle(intPtr);
										return "An error occured\nThe DLL was not loaded!\nThis is probably due to your AntiVirus";
									}
									Thread.Sleep(1000);
									GClass5 gclass = new GClass5();
									gclass.method_3(id, intPtr);
									byte[] byte_ = new byte[]
									{
									72,
									79,
									82,
									0,
									73,
									79,
									78,
									35,
									156,
									71,
									251,
									byte.MaxValue,
									125,
									156,
									66,
									87
									};
									gclass.method_8(byte_, new Action(this.method_5));
									gclass.method_5();
									if (gclass.GClass4_0.Length > 1)
									{
										MessageBox.Show("We found " + gclass.GClass4_0.Length.ToString() + " horion connections. This indicates that horion has been injected more than once, dont blame us for crashes.");
										return "More than 1 Horion connection found\nExpect unexpected behaviour";
									}
									if (gclass.GClass4_0.Length == 0)
									{
										return "Horion connection not found.\n(Are you using an old Horion version?)";
									}
									GClass4 gclass2 = gclass.GClass4_0[0];
									Console.WriteLine("Reconnecting les go: " + gclass2.IntPtr_0.ToString());
									this.class5_0.method_2(gclass2.IntPtr_0, intPtr, 2, this.string_3, this.bool_0 && !this.metroSetButton_3.Enabled, this.uint_3, this.string_1);
									return "";
								}
							}
							string text = "Access Denied: " + Marshal.GetLastWin32Error().ToString() + "\n Check your antivirus!";
							MessageBox.Show(text);
							return text;
						}
					}
				}
			}
			MessageBox.Show("Start Minecraft: Windows 10 Edition First");
			return "Start Minecraft: Windows 10 Edition First";
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00005E90 File Offset: 0x00004090
		public static void smethod_0(Process process_0, string string_5, bool bool_4)
		{
			IntPtr zero = IntPtr.Zero;
			Form1.OpenProcessToken(process_0, 40, ref zero);
			Form1.Struct7 @struct;
			@struct.int_0 = 1;
			@struct.long_0 = 0L;
			@struct.int_1 = 2;
			Form1.LookupPrivilegeValue(null, string_5, ref @struct.long_0);
			Form1.AdjustTokenPrivileges(zero, false, ref @struct, 0, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005EF4 File Offset: 0x000040F4
		private void method_7(string string_5)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr zero4 = IntPtr.Zero;
			IntPtr zero5 = IntPtr.Zero;
			if (Form1.GetNamedSecurityInfoW(string_5, Form1.GEnum0.SE_FILE_OBJECT, SecurityInfos.DiscretionaryAcl, out zero5, out zero5, out zero, out zero5, out zero3) == 0u)
			{
				Form1.ConvertStringSidToSidW("S-1-15-2-1", out zero4);
				if (!(zero4 != IntPtr.Zero))
				{
					MessageBox.Show("Restart with Administrator Privileges");
				}
				else
				{
					Form1.Struct5 @struct = new Form1.Struct5
					{
						uint_0 = 268435456u,
						uint_1 = 2u,
						uint_2 = 3u,
						struct6_0 = new Form1.Struct6
						{
							enum0_0 = Form1.Enum0.TRUSTEE_IS_SID,
							enum1_0 = Form1.Enum1.TRUSTEE_IS_WELL_KNOWN_GROUP,
							intptr_1 = zero4
						}
					};
					if (Form1.SetEntriesInAcl(1, ref @struct, zero, out zero2) == 0u)
					{
						if (Form1.SetNamedSecurityInfoW(string_5, Form1.GEnum0.SE_FILE_OBJECT, SecurityInfos.DiscretionaryAcl, IntPtr.Zero, IntPtr.Zero, zero2, IntPtr.Zero) != 0u)
						{
							MessageBox.Show("Restart with Administrator Privileges");
						}
					}
					else
					{
						MessageBox.Show("Restart with Administrator Privileges");
					}
				}
			}
			else
			{
				MessageBox.Show("Restart with Administrator Privileges");
			}
			if (zero3 != IntPtr.Zero)
			{
				Form1.LocalFree(zero3);
			}
			if (zero2 != IntPtr.Zero)
			{
				Form1.LocalFree(zero2);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000022B4 File Offset: 0x000004B4
		private void metroSetLabel_0_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000022B4 File Offset: 0x000004B4
		private void metroSetLabel_1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000022ED File Offset: 0x000004ED
		private void method_8(object sender, EventArgs e)
		{
			((MetroSetButton)sender).Enabled = false;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000022B4 File Offset: 0x000004B4
		private void method_9(object sender, EventArgs e)
		{
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00006028 File Offset: 0x00004228
		private void metroSetButton_2_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = this.string_2;
				openFileDialog.Filter = "DLL Files (*.dll)|*.dll";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.string_0 = "";
					GClass1 gclass = new GClass1(openFileDialog.FileName);
					if (!gclass.Boolean_0)
					{
						if (gclass.GStruct5_0.ushort_1 <= 7)
						{
							this.metroSetLabel_5.Text = "Please select a valid debug build!\n";
							MetroSetLabel metroSetLabel = this.metroSetLabel_5;
							metroSetLabel.Text += "If you want to inject beta builds, use the beta tab";
							this.metroSetButton_1.Enabled = false;
						}
						else
						{
							this.metroSetLabel_5.Text = "Dll selected\n";
							MetroSetLabel metroSetLabel2 = this.metroSetLabel_5;
							metroSetLabel2.Text += openFileDialog.SafeFileName;
							MetroSetLabel metroSetLabel3 = this.metroSetLabel_5;
							metroSetLabel3.Text += "\n";
							if (gclass.DateTime_0 < DateTime.Now.AddHours(-2.0))
							{
								MetroSetLabel metroSetLabel4 = this.metroSetLabel_5;
								metroSetLabel4.Text += "DLL is older than 2 hours\n";
							}
							MetroSetLabel metroSetLabel5 = this.metroSetLabel_5;
							metroSetLabel5.Text += gclass.DateTime_0.ToString();
							this.string_0 = openFileDialog.FileName;
							this.metroSetButton_1.Enabled = true;
							this.metroSetButton_1.Refresh();
							this.string_2 = Path.GetDirectoryName(this.string_0);
							this.method_1();
						}
					}
					else
					{
						this.metroSetLabel_5.Text = "32-Bit Dlls can not be injected!";
						this.metroSetButton_1.Enabled = false;
					}
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00006200 File Offset: 0x00004400
		private void metroSetButton_1_Click(object sender, EventArgs e)
		{
			((MetroSetButton)sender).Enabled = false;
			if (this.string_0 != "")
			{
				this.metroSetLabel_5.Text = "Injecting...";
				this.metroSetLabel_5.Refresh();
				this.metroSetProgressBar_2.Value = 30;
				this.metroSetProgressBar_2.Refresh();
				string text = this.method_6(this.string_0, this.metroSetProgressBar_2);
				if (text == "")
				{
					this.metroSetLabel_5.Text = "Done!";
					this.metroSetLabel_5.Refresh();
				}
				else
				{
					this.metroSetLabel_5.Text = text;
					this.metroSetLabel_5.Refresh();
				}
				this.metroSetProgressBar_2.Value = 100;
				this.metroSetProgressBar_2.Refresh();
			}
			((MetroSetButton)sender).Enabled = true;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000062DC File Offset: 0x000044DC
		private void metroSetButton_4_Click(object sender, EventArgs e)
		{
			string text = "";
			bool flag = false;
			((MetroSetButton)sender).Enabled = false;
			try
			{
				WebClient webClient = new WebClient();
				this.metroSetProgressBar_1.Value = 10;
				Application.DoEvents();
				webClient.Headers.Add(HttpRequestHeader.UserAgent, "Horion");
				webClient.Proxy = null;
				this.metroSetLabel_3.Text = "Checking...";
				this.metroSetLabel_3.Refresh();
				string text2 = "";
				try
				{
					text2 = webClient.DownloadString("http://www.horionbeta.club:50451/api/beta/check?client=" + this.string_3 + "&serial=" + this.uint_3.ToString());
				}
				catch (WebException ex)
				{
					this.metroSetLabel_3.Text = "An error occured while \nchecking the beta status";
					((MetroSetButton)sender).Enabled = true;
					if (ex.Status == WebExceptionStatus.ProtocolError)
					{
						this.metroSetLabel_3.Text = "Login required";
						((MetroSetButton)sender).Enabled = false;
						((MetroSetButton)sender).Refresh();
						this.metroSetButton_3.Enabled = true;
						this.metroSetButton_3.Refresh();
						this.string_3 = GClass2.smethod_0(32);
						this.method_1();
					}
					else
					{
						MessageBox.Show(ex.ToString());
					}
					this.metroSetProgressBar_1.Value = 0;
					return;
				}
				this.metroSetProgressBar_1.Value = 20;
				Application.DoEvents();
				object arg = JObject.Parse(text2);
				this.metroSetProgressBar_1.Value = 30;
				Application.DoEvents();
				this.metroSetLabel_3.Text = "";
				if (Form1.Class9.callSite_7 == null)
				{
					Form1.Class9.callSite_7 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target = Form1.Class9.callSite_7.Target;
				CallSite callSite_ = Form1.Class9.callSite_7;
				if (Form1.Class9.callSite_0 == null)
				{
					Form1.Class9.callSite_0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ContainsKey", null, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				object obj = Form1.Class9.callSite_0.Target(Form1.Class9.callSite_0, arg, "name");
				if (Form1.Class9.callSite_6 == null)
				{
					Form1.Class9.callSite_6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				object arg3;
				if (!Form1.Class9.callSite_6.Target(Form1.Class9.callSite_6, obj))
				{
					if (Form1.Class9.callSite_5 == null)
					{
						Form1.Class9.callSite_5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object, object> target2 = Form1.Class9.callSite_5.Target;
					CallSite callSite_2 = Form1.Class9.callSite_5;
					object arg2 = obj;
					if (Form1.Class9.callSite_4 == null)
					{
						Form1.Class9.callSite_4 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, int, object> target3 = Form1.Class9.callSite_4.Target;
					CallSite callSite_3 = Form1.Class9.callSite_4;
					if (Form1.Class9.callSite_3 == null)
					{
						Form1.Class9.callSite_3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Length", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> target4 = Form1.Class9.callSite_3.Target;
					CallSite callSite_4 = Form1.Class9.callSite_3;
					if (Form1.Class9.callSite_2 == null)
					{
						Form1.Class9.callSite_2 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> target5 = Form1.Class9.callSite_2.Target;
					CallSite callSite_5 = Form1.Class9.callSite_2;
					if (Form1.Class9.callSite_1 == null)
					{
						Form1.Class9.callSite_1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					arg3 = target2(callSite_2, arg2, target3(callSite_3, target4(callSite_4, target5(callSite_5, Form1.Class9.callSite_1.Target(Form1.Class9.callSite_1, arg))), 0));
				}
				else
				{
					arg3 = obj;
				}
				if (target(callSite_, arg3))
				{
					if (Form1.Class9.callSite_12 == null)
					{
						Form1.Class9.callSite_12 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target6 = Form1.Class9.callSite_12.Target;
					CallSite callSite_6 = Form1.Class9.callSite_12;
					if (Form1.Class9.callSite_11 == null)
					{
						Form1.Class9.callSite_11 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, int, object> target7 = Form1.Class9.callSite_11.Target;
					CallSite callSite_7 = Form1.Class9.callSite_11;
					if (Form1.Class9.callSite_10 == null)
					{
						Form1.Class9.callSite_10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Length", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> target8 = Form1.Class9.callSite_10.Target;
					CallSite callSite_8 = Form1.Class9.callSite_10;
					if (Form1.Class9.callSite_9 == null)
					{
						Form1.Class9.callSite_9 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> target9 = Form1.Class9.callSite_9.Target;
					CallSite callSite_9 = Form1.Class9.callSite_9;
					if (Form1.Class9.callSite_8 == null)
					{
						Form1.Class9.callSite_8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					if (!target6(callSite_6, target7(callSite_7, target8(callSite_8, target9(callSite_9, Form1.Class9.callSite_8.Target(Form1.Class9.callSite_8, arg))), 1)))
					{
						if (Form1.Class9.callSite_21 == null)
						{
							Form1.Class9.callSite_21 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, bool> target10 = Form1.Class9.callSite_21.Target;
						CallSite callSite_10 = Form1.Class9.callSite_21;
						if (Form1.Class9.callSite_20 == null)
						{
							Form1.Class9.callSite_20 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, string, object> target11 = Form1.Class9.callSite_20.Target;
						CallSite callSite_11 = Form1.Class9.callSite_20;
						if (Form1.Class9.callSite_19 == null)
						{
							Form1.Class9.callSite_19 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object> target12 = Form1.Class9.callSite_19.Target;
						CallSite callSite_12 = Form1.Class9.callSite_19;
						if (Form1.Class9.callSite_18 == null)
						{
							Form1.Class9.callSite_18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						if (target10(callSite_10, target11(callSite_11, target12(callSite_12, Form1.Class9.callSite_18.Target(Form1.Class9.callSite_18, arg)), "n")))
						{
							MetroSetLabel metroSetLabel = this.metroSetLabel_3;
							metroSetLabel.Text += "Join the discord!\n";
						}
					}
					else
					{
						MetroSetLabel metroSetLabel2 = this.metroSetLabel_3;
						Control control = metroSetLabel2;
						if (Form1.Class9.callSite_17 == null)
						{
							Form1.Class9.callSite_17 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
						}
						Func<CallSite, object, string> target13 = Form1.Class9.callSite_17.Target;
						CallSite callSite_13 = Form1.Class9.callSite_17;
						if (Form1.Class9.callSite_16 == null)
						{
							Form1.Class9.callSite_16 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, string, object, object> target14 = Form1.Class9.callSite_16.Target;
						CallSite callSite_14 = Form1.Class9.callSite_16;
						string text3 = metroSetLabel2.Text;
						if (Form1.Class9.callSite_15 == null)
						{
							Form1.Class9.callSite_15 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, string, object> target15 = Form1.Class9.callSite_15.Target;
						CallSite callSite_15 = Form1.Class9.callSite_15;
						if (Form1.Class9.callSite_14 == null)
						{
							Form1.Class9.callSite_14 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, string, object, object> target16 = Form1.Class9.callSite_14.Target;
						CallSite callSite_16 = Form1.Class9.callSite_14;
						string arg4 = "Welcome ";
						if (Form1.Class9.callSite_13 == null)
						{
							Form1.Class9.callSite_13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						control.Text = target13(callSite_13, target14(callSite_14, text3, target15(callSite_15, target16(callSite_16, arg4, Form1.Class9.callSite_13.Target(Form1.Class9.callSite_13, arg)), "!\n")));
					}
				}
				if (Form1.Class9.callSite_24 == null)
				{
					Form1.Class9.callSite_24 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target17 = Form1.Class9.callSite_24.Target;
				CallSite callSite_17 = Form1.Class9.callSite_24;
				if (Form1.Class9.callSite_23 == null)
				{
					Form1.Class9.callSite_23 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target18 = Form1.Class9.callSite_23.Target;
				CallSite callSite_18 = Form1.Class9.callSite_23;
				if (Form1.Class9.callSite_22 == null)
				{
					Form1.Class9.callSite_22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
					{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				if (!target17(callSite_17, target18(callSite_18, Form1.Class9.callSite_22.Target(Form1.Class9.callSite_22, arg), "success")))
				{
					if (Form1.Class9.callSite_27 == null)
					{
						Form1.Class9.callSite_27 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target19 = Form1.Class9.callSite_27.Target;
					CallSite callSite_19 = Form1.Class9.callSite_27;
					if (Form1.Class9.callSite_26 == null)
					{
						Form1.Class9.callSite_26 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, string, object> target20 = Form1.Class9.callSite_26.Target;
					CallSite callSite_20 = Form1.Class9.callSite_26;
					if (Form1.Class9.callSite_25 == null)
					{
						Form1.Class9.callSite_25 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					if (!target19(callSite_19, target20(callSite_20, Form1.Class9.callSite_25.Target(Form1.Class9.callSite_25, arg), "nobeta")))
					{
						if (Form1.Class9.callSite_30 == null)
						{
							Form1.Class9.callSite_30 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, bool> target21 = Form1.Class9.callSite_30.Target;
						CallSite callSite_21 = Form1.Class9.callSite_30;
						if (Form1.Class9.callSite_29 == null)
						{
							Form1.Class9.callSite_29 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, string, object> target22 = Form1.Class9.callSite_29.Target;
						CallSite callSite_22 = Form1.Class9.callSite_29;
						if (Form1.Class9.callSite_28 == null)
						{
							Form1.Class9.callSite_28 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						if (target21(callSite_21, target22(callSite_22, Form1.Class9.callSite_28.Target(Form1.Class9.callSite_28, arg), "login")))
						{
							this.metroSetLabel_3.Text = "Not logged in";
							this.metroSetButton_3.Enabled = true;
						}
						else
						{
							MetroSetLabel metroSetLabel2 = this.metroSetLabel_3;
							Control control2 = metroSetLabel2;
							if (Form1.Class9.callSite_34 == null)
							{
								Form1.Class9.callSite_34 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
							}
							Func<CallSite, object, string> target23 = Form1.Class9.callSite_34.Target;
							CallSite callSite_23 = Form1.Class9.callSite_34;
							if (Form1.Class9.callSite_33 == null)
							{
								Form1.Class9.callSite_33 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, string, object, object> target24 = Form1.Class9.callSite_33.Target;
							CallSite callSite_24 = Form1.Class9.callSite_33;
							string text4 = metroSetLabel2.Text;
							if (Form1.Class9.callSite_32 == null)
							{
								Form1.Class9.callSite_32 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, string, object, object> target25 = Form1.Class9.callSite_32.Target;
							CallSite callSite_25 = Form1.Class9.callSite_32;
							string arg5 = "Status:\n";
							if (Form1.Class9.callSite_31 == null)
							{
								Form1.Class9.callSite_31 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							control2.Text = target23(callSite_23, target24(callSite_24, text4, target25(callSite_25, arg5, Form1.Class9.callSite_31.Target(Form1.Class9.callSite_31, arg))));
							this.metroSetButton_3.Enabled = true;
						}
					}
					else
					{
						MetroSetLabel metroSetLabel3 = this.metroSetLabel_3;
						metroSetLabel3.Text += "Not a beta user!\nBoost the discord server with Nitro\nOr donate to patreon.com/horion";
						this.metroSetButton_3.Enabled = true;
					}
				}
				else
				{
					MetroSetLabel metroSetLabel4 = this.metroSetLabel_3;
					metroSetLabel4.Text += "Beta available!";
					this.metroSetButton_3.Enabled = false;
				}
				this.metroSetButton_4.Enabled = !this.metroSetButton_3.Enabled;
				if (!this.metroSetButton_3.Enabled)
				{
					webClient.DownloadProgressChanged += this.method_3;
					text = Path.Combine(Path.GetTempPath(), "Horion.dll");
					webClient.DownloadFileAsync(new Uri("http://www.horionbeta.club:50451/api/beta/download?client=" + this.string_3 + "&serial=" + this.uint_3.ToString()), text);
					while (webClient.IsBusy)
					{
						Application.DoEvents();
						Thread.Sleep(3);
					}
					this.metroSetProgressBar_1.Value = 80;
					Application.DoEvents();
					this.metroSetLabel_3.Text = "Done";
					this.metroSetLabel_3.Refresh();
					if (!File.Exists(text))
					{
						MessageBox.Show("Dll could not be downloaded, check your Anti Virus!");
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					flag = false;
				}
			}
			catch (WebException ex2)
			{
				MessageBox.Show(ex2.ToString());
				((MetroSetButton)sender).Enabled = true;
				return;
			}
			if (flag)
			{
				this.metroSetLabel_3.Text = "Injecting...";
				this.metroSetLabel_3.Refresh();
				this.metroSetProgressBar_1.Value = 80;
				this.metroSetProgressBar_1.Refresh();
				string text5 = this.method_6(text, this.metroSetProgressBar_1);
				if (text5 == "")
				{
					this.metroSetLabel_3.Text = "Done!";
					this.metroSetLabel_3.Refresh();
				}
				else
				{
					this.metroSetLabel_3.Text = text5;
					this.metroSetLabel_3.Refresh();
				}
			}
			this.metroSetProgressBar_1.Value = 100;
			this.metroSetProgressBar_1.Refresh();
			((MetroSetButton)sender).Enabled = !this.metroSetButton_3.Enabled;
			((MetroSetButton)sender).Refresh();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000071C4 File Offset: 0x000053C4
		private void metroSetButton_3_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.string_3.Length > 10)
				{
					this.metroSetLabel_3.Text = "Logging in...";
					object arg = JObject.Parse(new WebClient
					{
						Headers =
					{
						{
							HttpRequestHeader.UserAgent,
							"HorionInjector"
						}
					},
						Proxy = null
					}.DownloadString("http://www.horionbeta.club:50451/api/beta/check?client=" + this.string_3 + "&serial=" + this.uint_3.ToString()));
					this.metroSetLabel_3.Text = "";
					if (Form1.Class10.callSite_7 == null)
					{
						Form1.Class10.callSite_7 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target = Form1.Class10.callSite_7.Target;
					CallSite callSite_ = Form1.Class10.callSite_7;
					if (Form1.Class10.callSite_0 == null)
					{
						Form1.Class10.callSite_0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ContainsKey", null, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					object obj = Form1.Class10.callSite_0.Target(Form1.Class10.callSite_0, arg, "name");
					if (Form1.Class10.callSite_6 == null)
					{
						Form1.Class10.callSite_6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					object arg3;
					if (!Form1.Class10.callSite_6.Target(Form1.Class10.callSite_6, obj))
					{
						if (Form1.Class10.callSite_5 == null)
						{
							Form1.Class10.callSite_5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target2 = Form1.Class10.callSite_5.Target;
						CallSite callSite_2 = Form1.Class10.callSite_5;
						object arg2 = obj;
						if (Form1.Class10.callSite_4 == null)
						{
							Form1.Class10.callSite_4 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, int, object> target3 = Form1.Class10.callSite_4.Target;
						CallSite callSite_3 = Form1.Class10.callSite_4;
						if (Form1.Class10.callSite_3 == null)
						{
							Form1.Class10.callSite_3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Length", typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object> target4 = Form1.Class10.callSite_3.Target;
						CallSite callSite_4 = Form1.Class10.callSite_3;
						if (Form1.Class10.callSite_2 == null)
						{
							Form1.Class10.callSite_2 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object> target5 = Form1.Class10.callSite_2.Target;
						CallSite callSite_5 = Form1.Class10.callSite_2;
						if (Form1.Class10.callSite_1 == null)
						{
							Form1.Class10.callSite_1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						arg3 = target2(callSite_2, arg2, target3(callSite_3, target4(callSite_4, target5(callSite_5, Form1.Class10.callSite_1.Target(Form1.Class10.callSite_1, arg))), 0));
					}
					else
					{
						arg3 = obj;
					}
					if (target(callSite_, arg3))
					{
						if (Form1.Class10.callSite_12 == null)
						{
							Form1.Class10.callSite_12 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, bool> target6 = Form1.Class10.callSite_12.Target;
						CallSite callSite_6 = Form1.Class10.callSite_12;
						if (Form1.Class10.callSite_11 == null)
						{
							Form1.Class10.callSite_11 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, int, object> target7 = Form1.Class10.callSite_11.Target;
						CallSite callSite_7 = Form1.Class10.callSite_11;
						if (Form1.Class10.callSite_10 == null)
						{
							Form1.Class10.callSite_10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Length", typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object> target8 = Form1.Class10.callSite_10.Target;
						CallSite callSite_8 = Form1.Class10.callSite_10;
						if (Form1.Class10.callSite_9 == null)
						{
							Form1.Class10.callSite_9 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object> target9 = Form1.Class10.callSite_9.Target;
						CallSite callSite_9 = Form1.Class10.callSite_9;
						if (Form1.Class10.callSite_8 == null)
						{
							Form1.Class10.callSite_8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						if (target6(callSite_6, target7(callSite_7, target8(callSite_8, target9(callSite_9, Form1.Class10.callSite_8.Target(Form1.Class10.callSite_8, arg))), 1)))
						{
							MetroSetLabel metroSetLabel = this.metroSetLabel_3;
							Control control = metroSetLabel;
							if (Form1.Class10.callSite_17 == null)
							{
								Form1.Class10.callSite_17 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
							}
							Func<CallSite, object, string> target10 = Form1.Class10.callSite_17.Target;
							CallSite callSite_10 = Form1.Class10.callSite_17;
							if (Form1.Class10.callSite_16 == null)
							{
								Form1.Class10.callSite_16 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, string, object, object> target11 = Form1.Class10.callSite_16.Target;
							CallSite callSite_11 = Form1.Class10.callSite_16;
							string text = metroSetLabel.Text;
							if (Form1.Class10.callSite_15 == null)
							{
								Form1.Class10.callSite_15 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Func<CallSite, object, string, object> target12 = Form1.Class10.callSite_15.Target;
							CallSite callSite_12 = Form1.Class10.callSite_15;
							if (Form1.Class10.callSite_14 == null)
							{
								Form1.Class10.callSite_14 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, string, object, object> target13 = Form1.Class10.callSite_14.Target;
							CallSite callSite_13 = Form1.Class10.callSite_14;
							string arg4 = "Welcome ";
							if (Form1.Class10.callSite_13 == null)
							{
								Form1.Class10.callSite_13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							control.Text = target10(callSite_10, target11(callSite_11, text, target12(callSite_12, target13(callSite_13, arg4, Form1.Class10.callSite_13.Target(Form1.Class10.callSite_13, arg)), "!\n")));
						}
						else
						{
							if (Form1.Class10.callSite_21 == null)
							{
								Form1.Class10.callSite_21 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, bool> target14 = Form1.Class10.callSite_21.Target;
							CallSite callSite_14 = Form1.Class10.callSite_21;
							if (Form1.Class10.callSite_20 == null)
							{
								Form1.Class10.callSite_20 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Func<CallSite, object, string, object> target15 = Form1.Class10.callSite_20.Target;
							CallSite callSite_15 = Form1.Class10.callSite_20;
							if (Form1.Class10.callSite_19 == null)
							{
								Form1.Class10.callSite_19 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object> target16 = Form1.Class10.callSite_19.Target;
							CallSite callSite_16 = Form1.Class10.callSite_19;
							if (Form1.Class10.callSite_18 == null)
							{
								Form1.Class10.callSite_18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							if (target14(callSite_14, target15(callSite_15, target16(callSite_16, Form1.Class10.callSite_18.Target(Form1.Class10.callSite_18, arg)), "n")))
							{
								MetroSetLabel metroSetLabel2 = this.metroSetLabel_3;
								metroSetLabel2.Text += "Join the discord!\n";
							}
						}
					}
					if (Form1.Class10.callSite_24 == null)
					{
						Form1.Class10.callSite_24 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target17 = Form1.Class10.callSite_24.Target;
					CallSite callSite_17 = Form1.Class10.callSite_24;
					if (Form1.Class10.callSite_23 == null)
					{
						Form1.Class10.callSite_23 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, string, object> target18 = Form1.Class10.callSite_23.Target;
					CallSite callSite_18 = Form1.Class10.callSite_23;
					if (Form1.Class10.callSite_22 == null)
					{
						Form1.Class10.callSite_22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
						{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					if (target17(callSite_17, target18(callSite_18, Form1.Class10.callSite_22.Target(Form1.Class10.callSite_22, arg), "success")))
					{
						MetroSetLabel metroSetLabel3 = this.metroSetLabel_3;
						metroSetLabel3.Text += "Beta available!";
						this.metroSetButton_3.Enabled = false;
					}
					else
					{
						if (Form1.Class10.callSite_27 == null)
						{
							Form1.Class10.callSite_27 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, bool> target19 = Form1.Class10.callSite_27.Target;
						CallSite callSite_19 = Form1.Class10.callSite_27;
						if (Form1.Class10.callSite_26 == null)
						{
							Form1.Class10.callSite_26 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, string, object> target20 = Form1.Class10.callSite_26.Target;
						CallSite callSite_20 = Form1.Class10.callSite_26;
						if (Form1.Class10.callSite_25 == null)
						{
							Form1.Class10.callSite_25 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
							{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						if (target19(callSite_19, target20(callSite_20, Form1.Class10.callSite_25.Target(Form1.Class10.callSite_25, arg), "nobeta")))
						{
							MetroSetLabel metroSetLabel4 = this.metroSetLabel_3;
							metroSetLabel4.Text += "Not a beta user!\nBoost the discord server with Nitro\nOr donate to patreon.com/horion";
							this.metroSetButton_3.Enabled = true;
						}
						else
						{
							if (Form1.Class10.callSite_30 == null)
							{
								Form1.Class10.callSite_30 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, bool> target21 = Form1.Class10.callSite_30.Target;
							CallSite callSite_21 = Form1.Class10.callSite_30;
							if (Form1.Class10.callSite_29 == null)
							{
								Form1.Class10.callSite_29 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Func<CallSite, object, string, object> target22 = Form1.Class10.callSite_29.Target;
							CallSite callSite_22 = Form1.Class10.callSite_29;
							if (Form1.Class10.callSite_28 == null)
							{
								Form1.Class10.callSite_28 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
								{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							if (target21(callSite_21, target22(callSite_22, Form1.Class10.callSite_28.Target(Form1.Class10.callSite_28, arg), "login")))
							{
								this.metroSetLabel_3.Text = "Opening browser...\nClick Login again when you're done";
								this.metroSetButton_3.Enabled = true;
							}
							else
							{
								MetroSetLabel metroSetLabel = this.metroSetLabel_3;
								Control control2 = metroSetLabel;
								if (Form1.Class10.callSite_34 == null)
								{
									Form1.Class10.callSite_34 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Form1)));
								}
								Func<CallSite, object, string> target23 = Form1.Class10.callSite_34.Target;
								CallSite callSite_23 = Form1.Class10.callSite_34;
								if (Form1.Class10.callSite_33 == null)
								{
									Form1.Class10.callSite_33 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, string, object, object> target24 = Form1.Class10.callSite_33.Target;
								CallSite callSite_24 = Form1.Class10.callSite_33;
								string text2 = metroSetLabel.Text;
								if (Form1.Class10.callSite_32 == null)
								{
									Form1.Class10.callSite_32 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, string, object, object> target25 = Form1.Class10.callSite_32.Target;
								CallSite callSite_25 = Form1.Class10.callSite_32;
								string arg5 = "Status:\n";
								if (Form1.Class10.callSite_31 == null)
								{
									Form1.Class10.callSite_31 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(Form1), new CSharpArgumentInfo[]
									{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								control2.Text = target23(callSite_23, target24(callSite_24, text2, target25(callSite_25, arg5, Form1.Class10.callSite_31.Target(Form1.Class10.callSite_31, arg))));
								this.metroSetButton_3.Enabled = true;
							}
						}
					}
					this.metroSetButton_4.Enabled = !this.metroSetButton_3.Enabled;
				}
				else
				{
					this.string_3 = GClass2.smethod_0(32);
					this.method_1();
				}
				if (this.metroSetButton_3.Enabled && !this.bool_3)
				{
					this.string_3 = GClass2.smethod_0(32);
					this.method_1();
					string text3 = "http://www.horionbeta.club:50451/login?client=" + this.string_3 + "&serial=" + this.uint_3.ToString();
					Console.WriteLine("Opening url " + text3);
					Process.Start(text3);
					this.bool_3 = true;
				}
			}
			catch (WebException ex)
			{
				this.metroSetLabel_3.Text = "A Web exception was thrown:\n" + ex.Message;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000022FB File Offset: 0x000004FB
		private void metroSetLabel_7_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/" + this.string_1);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002313 File Offset: 0x00000513
		private void metroSetSwitch_0_SwitchedChanged(object object_0)
		{
			this.bool_1 = ((MetroSetSwitch)object_0).Switched;
			this.method_0(this.bool_1);
			this.method_1();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002338 File Offset: 0x00000538
		private void metroSetSwitch_1_SwitchedChanged(object object_0)
		{
			this.bool_0 = ((MetroSetSwitch)object_0).Switched;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000022B4 File Offset: 0x000004B4
		private void metroSetLabel_10_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000234B File Offset: 0x0000054B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		public struct GStruct0
		{
			// Token: 0x0400007B RID: 123
			public uint uint_0;

			// Token: 0x0400007C RID: 124
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 39)]
			public char[] char_0;

			// Token: 0x0400007D RID: 125
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
			public char[] char_1;
		}

		// Token: 0x02000012 RID: 18
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct Struct5
		{
			// Token: 0x0400007E RID: 126
			public uint uint_0;

			// Token: 0x0400007F RID: 127
			public uint uint_1;

			// Token: 0x04000080 RID: 128
			public uint uint_2;

			// Token: 0x04000081 RID: 129
			public Form1.Struct6 struct6_0;
		}

		// Token: 0x02000013 RID: 19
		internal enum Enum0
		{
			// Token: 0x04000083 RID: 131
			TRUSTEE_IS_SID,
			// Token: 0x04000084 RID: 132
			TRUSTEE_IS_NAME,
			// Token: 0x04000085 RID: 133
			TRUSTEE_BAD_FORM,
			// Token: 0x04000086 RID: 134
			TRUSTEE_IS_OBJECTS_AND_SID,
			// Token: 0x04000087 RID: 135
			TRUSTEE_IS_OBJECTS_AND_NAME
		}

		// Token: 0x02000014 RID: 20
		internal enum Enum1
		{
			// Token: 0x04000089 RID: 137
			TRUSTEE_IS_UNKNOWN,
			// Token: 0x0400008A RID: 138
			TRUSTEE_IS_USER,
			// Token: 0x0400008B RID: 139
			TRUSTEE_IS_GROUP,
			// Token: 0x0400008C RID: 140
			TRUSTEE_IS_DOMAIN,
			// Token: 0x0400008D RID: 141
			TRUSTEE_IS_ALIAS,
			// Token: 0x0400008E RID: 142
			TRUSTEE_IS_WELL_KNOWN_GROUP,
			// Token: 0x0400008F RID: 143
			TRUSTEE_IS_DELETED,
			// Token: 0x04000090 RID: 144
			TRUSTEE_IS_INVALID,
			// Token: 0x04000091 RID: 145
			TRUSTEE_IS_COMPUTER
		}

		// Token: 0x02000015 RID: 21
		internal enum Enum2
		{
			// Token: 0x04000093 RID: 147
			NO_MULTIPLE_TRUSTEE,
			// Token: 0x04000094 RID: 148
			TRUSTEE_IS_IMPERSONATE
		}

		// Token: 0x02000016 RID: 22
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct Struct6
		{
			// Token: 0x04000095 RID: 149
			public IntPtr intptr_0;

			// Token: 0x04000096 RID: 150
			public Form1.Enum2 enum2_0;

			// Token: 0x04000097 RID: 151
			public Form1.Enum0 enum0_0;

			// Token: 0x04000098 RID: 152
			public Form1.Enum1 enum1_0;

			// Token: 0x04000099 RID: 153
			public IntPtr intptr_1;
		}

		// Token: 0x02000017 RID: 23
		public enum GEnum0
		{
			// Token: 0x0400009B RID: 155
			SE_UNKNOWN_OBJECT_TYPE,
			// Token: 0x0400009C RID: 156
			SE_FILE_OBJECT,
			// Token: 0x0400009D RID: 157
			SE_SERVICE,
			// Token: 0x0400009E RID: 158
			SE_PRINTER,
			// Token: 0x0400009F RID: 159
			SE_REGISTRY_KEY,
			// Token: 0x040000A0 RID: 160
			SE_LMSHARE,
			// Token: 0x040000A1 RID: 161
			SE_KERNEL_OBJECT,
			// Token: 0x040000A2 RID: 162
			SE_WINDOW_OBJECT,
			// Token: 0x040000A3 RID: 163
			SE_DS_OBJECT,
			// Token: 0x040000A4 RID: 164
			SE_DS_OBJECT_ALL,
			// Token: 0x040000A5 RID: 165
			SE_PROVIDER_DEFINED_OBJECT,
			// Token: 0x040000A6 RID: 166
			SE_WMIGUID_OBJECT,
			// Token: 0x040000A7 RID: 167
			SE_REGISTRY_WOW64_32KEY
		}

		// Token: 0x02000018 RID: 24
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		internal struct Struct7
		{
			// Token: 0x040000A8 RID: 168
			public int int_0;

			// Token: 0x040000A9 RID: 169
			public long long_0;

			// Token: 0x040000AA RID: 170
			public int int_1;
		}

		// Token: 0x02000019 RID: 25
		[CompilerGenerated]
		private static class Class7
		{
			// Token: 0x040000AB RID: 171
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			// Token: 0x040000AC RID: 172
			public static CallSite<Func<CallSite, object, string>> callSite_1;

			// Token: 0x040000AD RID: 173
			public static CallSite<Func<CallSite, object, object>> callSite_2;

			// Token: 0x040000AE RID: 174
			public static CallSite<Func<CallSite, object, string>> callSite_3;

			// Token: 0x040000AF RID: 175
			public static CallSite<Func<CallSite, object, object>> callSite_4;

			// Token: 0x040000B0 RID: 176
			public static CallSite<Func<CallSite, object, bool>> callSite_5;

			// Token: 0x040000B1 RID: 177
			public static CallSite<Func<CallSite, object, object>> callSite_6;

			// Token: 0x040000B2 RID: 178
			public static CallSite<Func<CallSite, object, object>> callSite_7;

			// Token: 0x040000B3 RID: 179
			public static CallSite<Func<CallSite, object, string>> callSite_8;

			// Token: 0x040000B4 RID: 180
			public static CallSite<Func<CallSite, object, object>> callSite_9;

			// Token: 0x040000B5 RID: 181
			public static CallSite<Func<CallSite, object, int, object>> callSite_10;

			// Token: 0x040000B6 RID: 182
			public static CallSite<Func<CallSite, object, bool>> callSite_11;

			// Token: 0x040000B7 RID: 183
			public static CallSite<Func<CallSite, object, object>> callSite_12;

			// Token: 0x040000B8 RID: 184
			public static CallSite<Func<CallSite, object, string>> callSite_13;

			// Token: 0x040000B9 RID: 185
			public static CallSite<Func<CallSite, object, object>> callSite_14;

			// Token: 0x040000BA RID: 186
			public static CallSite<Func<CallSite, object, string>> callSite_15;

			// Token: 0x040000BB RID: 187
			public static CallSite<Func<CallSite, object, string, object>> callSite_16;

			// Token: 0x040000BC RID: 188
			public static CallSite<Func<CallSite, object, object>> callSite_17;

			// Token: 0x040000BD RID: 189
			public static CallSite<Func<CallSite, object, object>> callSite_18;

			// Token: 0x040000BE RID: 190
			public static CallSite<Func<CallSite, object, object>> callSite_19;

			// Token: 0x040000BF RID: 191
			public static CallSite<Func<CallSite, object, int, object>> callSite_20;

			// Token: 0x040000C0 RID: 192
			public static CallSite<Func<CallSite, object, object, object>> callSite_21;

			// Token: 0x040000C1 RID: 193
			public static CallSite<Func<CallSite, object, bool>> callSite_22;

			// Token: 0x040000C2 RID: 194
			public static CallSite<Func<CallSite, object, bool>> callSite_23;

			// Token: 0x040000C3 RID: 195
			public static CallSite<Func<CallSite, object, object>> callSite_24;

			// Token: 0x040000C4 RID: 196
			public static CallSite<Func<CallSite, object, object>> callSite_25;

			// Token: 0x040000C5 RID: 197
			public static CallSite<Func<CallSite, object, object>> callSite_26;

			// Token: 0x040000C6 RID: 198
			public static CallSite<Func<CallSite, object, int, object>> callSite_27;

			// Token: 0x040000C7 RID: 199
			public static CallSite<Func<CallSite, object, bool>> callSite_28;

			// Token: 0x040000C8 RID: 200
			public static CallSite<Func<CallSite, object, object>> callSite_29;

			// Token: 0x040000C9 RID: 201
			public static CallSite<Func<CallSite, string, object, object>> callSite_30;

			// Token: 0x040000CA RID: 202
			public static CallSite<Func<CallSite, object, string, object>> callSite_31;

			// Token: 0x040000CB RID: 203
			public static CallSite<Func<CallSite, string, object, object>> callSite_32;

			// Token: 0x040000CC RID: 204
			public static CallSite<Func<CallSite, object, string>> callSite_33;

			// Token: 0x040000CD RID: 205
			public static CallSite<Func<CallSite, object, object>> callSite_34;

			// Token: 0x040000CE RID: 206
			public static CallSite<Func<CallSite, object, object>> callSite_35;

			// Token: 0x040000CF RID: 207
			public static CallSite<Func<CallSite, object, string, object>> callSite_36;

			// Token: 0x040000D0 RID: 208
			public static CallSite<Func<CallSite, object, bool>> callSite_37;

			// Token: 0x040000D1 RID: 209
			public static CallSite<Func<CallSite, object, object>> callSite_38;

			// Token: 0x040000D2 RID: 210
			public static CallSite<Func<CallSite, object, string, object>> callSite_39;

			// Token: 0x040000D3 RID: 211
			public static CallSite<Func<CallSite, object, bool>> callSite_40;

			// Token: 0x040000D4 RID: 212
			public static CallSite<Func<CallSite, object, object>> callSite_41;

			// Token: 0x040000D5 RID: 213
			public static CallSite<Func<CallSite, object, string, object>> callSite_42;

			// Token: 0x040000D6 RID: 214
			public static CallSite<Func<CallSite, object, bool>> callSite_43;

			// Token: 0x040000D7 RID: 215
			public static CallSite<Func<CallSite, object, object>> callSite_44;

			// Token: 0x040000D8 RID: 216
			public static CallSite<Func<CallSite, object, string, object>> callSite_45;

			// Token: 0x040000D9 RID: 217
			public static CallSite<Func<CallSite, object, bool>> callSite_46;

			// Token: 0x040000DA RID: 218
			public static CallSite<Func<CallSite, object, object>> callSite_47;

			// Token: 0x040000DB RID: 219
			public static CallSite<Func<CallSite, string, object, object>> callSite_48;

			// Token: 0x040000DC RID: 220
			public static CallSite<Func<CallSite, string, object, object>> callSite_49;

			// Token: 0x040000DD RID: 221
			public static CallSite<Func<CallSite, object, string>> callSite_50;
		}

		// Token: 0x0200001A RID: 26
		[CompilerGenerated]
		private static class Class8
		{
			// Token: 0x040000DE RID: 222
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			// Token: 0x040000DF RID: 223
			public static CallSite<Func<CallSite, object, int, object>> callSite_1;

			// Token: 0x040000E0 RID: 224
			public static CallSite<Func<CallSite, object, object, object>> callSite_2;

			// Token: 0x040000E1 RID: 225
			public static CallSite<Func<CallSite, object, bool>> callSite_3;

			// Token: 0x040000E2 RID: 226
			public static CallSite<Func<CallSite, object, object>> callSite_4;

			// Token: 0x040000E3 RID: 227
			public static CallSite<Func<CallSite, object, int, object>> callSite_5;

			// Token: 0x040000E4 RID: 228
			public static CallSite<Func<CallSite, object, object>> callSite_6;

			// Token: 0x040000E5 RID: 229
			public static CallSite<Func<CallSite, object, string>> callSite_7;

			// Token: 0x040000E6 RID: 230
			public static CallSite<Func<CallSite, object, object>> callSite_8;

			// Token: 0x040000E7 RID: 231
			public static CallSite<Func<CallSite, string, object, object>> callSite_9;

			// Token: 0x040000E8 RID: 232
			public static CallSite<Func<CallSite, object, string>> callSite_10;

			// Token: 0x040000E9 RID: 233
			public static CallSite<Func<CallSite, object, object>> callSite_11;

			// Token: 0x040000EA RID: 234
			public static CallSite<Func<CallSite, string, object, object>> callSite_12;

			// Token: 0x040000EB RID: 235
			public static CallSite<Func<CallSite, object, string>> callSite_13;

			// Token: 0x040000EC RID: 236
			public static CallSite<Func<CallSite, object, object>> callSite_14;

			// Token: 0x040000ED RID: 237
			public static CallSite<Func<CallSite, object, int, object>> callSite_15;

			// Token: 0x040000EE RID: 238
			public static CallSite<Func<CallSite, object, object>> callSite_16;

			// Token: 0x040000EF RID: 239
			public static CallSite<Func<CallSite, object, string>> callSite_17;
		}

		// Token: 0x0200001B RID: 27
		[CompilerGenerated]
		private static class Class9
		{
			// Token: 0x040000F0 RID: 240
			public static CallSite<Func<CallSite, object, string, object>> callSite_0;

			// Token: 0x040000F1 RID: 241
			public static CallSite<Func<CallSite, object, object>> callSite_1;

			// Token: 0x040000F2 RID: 242
			public static CallSite<Func<CallSite, object, object>> callSite_2;

			// Token: 0x040000F3 RID: 243
			public static CallSite<Func<CallSite, object, object>> callSite_3;

			// Token: 0x040000F4 RID: 244
			public static CallSite<Func<CallSite, object, int, object>> callSite_4;

			// Token: 0x040000F5 RID: 245
			public static CallSite<Func<CallSite, object, object, object>> callSite_5;

			// Token: 0x040000F6 RID: 246
			public static CallSite<Func<CallSite, object, bool>> callSite_6;

			// Token: 0x040000F7 RID: 247
			public static CallSite<Func<CallSite, object, bool>> callSite_7;

			// Token: 0x040000F8 RID: 248
			public static CallSite<Func<CallSite, object, object>> callSite_8;

			// Token: 0x040000F9 RID: 249
			public static CallSite<Func<CallSite, object, object>> callSite_9;

			// Token: 0x040000FA RID: 250
			public static CallSite<Func<CallSite, object, object>> callSite_10;

			// Token: 0x040000FB RID: 251
			public static CallSite<Func<CallSite, object, int, object>> callSite_11;

			// Token: 0x040000FC RID: 252
			public static CallSite<Func<CallSite, object, bool>> callSite_12;

			// Token: 0x040000FD RID: 253
			public static CallSite<Func<CallSite, object, object>> callSite_13;

			// Token: 0x040000FE RID: 254
			public static CallSite<Func<CallSite, string, object, object>> callSite_14;

			// Token: 0x040000FF RID: 255
			public static CallSite<Func<CallSite, object, string, object>> callSite_15;

			// Token: 0x04000100 RID: 256
			public static CallSite<Func<CallSite, string, object, object>> callSite_16;

			// Token: 0x04000101 RID: 257
			public static CallSite<Func<CallSite, object, string>> callSite_17;

			// Token: 0x04000102 RID: 258
			public static CallSite<Func<CallSite, object, object>> callSite_18;

			// Token: 0x04000103 RID: 259
			public static CallSite<Func<CallSite, object, object>> callSite_19;

			// Token: 0x04000104 RID: 260
			public static CallSite<Func<CallSite, object, string, object>> callSite_20;

			// Token: 0x04000105 RID: 261
			public static CallSite<Func<CallSite, object, bool>> callSite_21;

			// Token: 0x04000106 RID: 262
			public static CallSite<Func<CallSite, object, object>> callSite_22;

			// Token: 0x04000107 RID: 263
			public static CallSite<Func<CallSite, object, string, object>> callSite_23;

			// Token: 0x04000108 RID: 264
			public static CallSite<Func<CallSite, object, bool>> callSite_24;

			// Token: 0x04000109 RID: 265
			public static CallSite<Func<CallSite, object, object>> callSite_25;

			// Token: 0x0400010A RID: 266
			public static CallSite<Func<CallSite, object, string, object>> callSite_26;

			// Token: 0x0400010B RID: 267
			public static CallSite<Func<CallSite, object, bool>> callSite_27;

			// Token: 0x0400010C RID: 268
			public static CallSite<Func<CallSite, object, object>> callSite_28;

			// Token: 0x0400010D RID: 269
			public static CallSite<Func<CallSite, object, string, object>> callSite_29;

			// Token: 0x0400010E RID: 270
			public static CallSite<Func<CallSite, object, bool>> callSite_30;

			// Token: 0x0400010F RID: 271
			public static CallSite<Func<CallSite, object, object>> callSite_31;

			// Token: 0x04000110 RID: 272
			public static CallSite<Func<CallSite, string, object, object>> callSite_32;

			// Token: 0x04000111 RID: 273
			public static CallSite<Func<CallSite, string, object, object>> callSite_33;

			// Token: 0x04000112 RID: 274
			public static CallSite<Func<CallSite, object, string>> callSite_34;
		}

		// Token: 0x0200001C RID: 28
		[CompilerGenerated]
		private static class Class10
		{
			// Token: 0x04000113 RID: 275
			public static CallSite<Func<CallSite, object, string, object>> callSite_0;

			// Token: 0x04000114 RID: 276
			public static CallSite<Func<CallSite, object, object>> callSite_1;

			// Token: 0x04000115 RID: 277
			public static CallSite<Func<CallSite, object, object>> callSite_2;

			// Token: 0x04000116 RID: 278
			public static CallSite<Func<CallSite, object, object>> callSite_3;

			// Token: 0x04000117 RID: 279
			public static CallSite<Func<CallSite, object, int, object>> callSite_4;

			// Token: 0x04000118 RID: 280
			public static CallSite<Func<CallSite, object, object, object>> callSite_5;

			// Token: 0x04000119 RID: 281
			public static CallSite<Func<CallSite, object, bool>> callSite_6;

			// Token: 0x0400011A RID: 282
			public static CallSite<Func<CallSite, object, bool>> callSite_7;

			// Token: 0x0400011B RID: 283
			public static CallSite<Func<CallSite, object, object>> callSite_8;

			// Token: 0x0400011C RID: 284
			public static CallSite<Func<CallSite, object, object>> callSite_9;

			// Token: 0x0400011D RID: 285
			public static CallSite<Func<CallSite, object, object>> callSite_10;

			// Token: 0x0400011E RID: 286
			public static CallSite<Func<CallSite, object, int, object>> callSite_11;

			// Token: 0x0400011F RID: 287
			public static CallSite<Func<CallSite, object, bool>> callSite_12;

			// Token: 0x04000120 RID: 288
			public static CallSite<Func<CallSite, object, object>> callSite_13;

			// Token: 0x04000121 RID: 289
			public static CallSite<Func<CallSite, string, object, object>> callSite_14;

			// Token: 0x04000122 RID: 290
			public static CallSite<Func<CallSite, object, string, object>> callSite_15;

			// Token: 0x04000123 RID: 291
			public static CallSite<Func<CallSite, string, object, object>> callSite_16;

			// Token: 0x04000124 RID: 292
			public static CallSite<Func<CallSite, object, string>> callSite_17;

			// Token: 0x04000125 RID: 293
			public static CallSite<Func<CallSite, object, object>> callSite_18;

			// Token: 0x04000126 RID: 294
			public static CallSite<Func<CallSite, object, object>> callSite_19;

			// Token: 0x04000127 RID: 295
			public static CallSite<Func<CallSite, object, string, object>> callSite_20;

			// Token: 0x04000128 RID: 296
			public static CallSite<Func<CallSite, object, bool>> callSite_21;

			// Token: 0x04000129 RID: 297
			public static CallSite<Func<CallSite, object, object>> callSite_22;

			// Token: 0x0400012A RID: 298
			public static CallSite<Func<CallSite, object, string, object>> callSite_23;

			// Token: 0x0400012B RID: 299
			public static CallSite<Func<CallSite, object, bool>> callSite_24;

			// Token: 0x0400012C RID: 300
			public static CallSite<Func<CallSite, object, object>> callSite_25;

			// Token: 0x0400012D RID: 301
			public static CallSite<Func<CallSite, object, string, object>> callSite_26;

			// Token: 0x0400012E RID: 302
			public static CallSite<Func<CallSite, object, bool>> callSite_27;

			// Token: 0x0400012F RID: 303
			public static CallSite<Func<CallSite, object, object>> callSite_28;

			// Token: 0x04000130 RID: 304
			public static CallSite<Func<CallSite, object, string, object>> callSite_29;

			// Token: 0x04000131 RID: 305
			public static CallSite<Func<CallSite, object, bool>> callSite_30;

			// Token: 0x04000132 RID: 306
			public static CallSite<Func<CallSite, object, object>> callSite_31;

			// Token: 0x04000133 RID: 307
			public static CallSite<Func<CallSite, string, object, object>> callSite_32;

			// Token: 0x04000134 RID: 308
			public static CallSite<Func<CallSite, string, object, object>> callSite_33;

			// Token: 0x04000135 RID: 309
			public static CallSite<Func<CallSite, object, string>> callSite_34;
		}


		// Token: 0x04000049 RID: 73
		private const int int_0 = 2;

		// Token: 0x0400004A RID: 74
		private const int int_1 = 1024;

		// Token: 0x0400004B RID: 75
		private const int int_2 = 8;

		// Token: 0x0400004C RID: 76
		private const int int_3 = 32;

		// Token: 0x0400004D RID: 77
		private const int int_4 = 16;

		// Token: 0x0400004E RID: 78
		private const uint uint_0 = 4096u;

		// Token: 0x0400004F RID: 79
		private const uint uint_1 = 8192u;

		// Token: 0x04000050 RID: 80
		private const uint uint_2 = 4u;

		// Token: 0x04000051 RID: 81
		internal const int int_5 = 2;

		// Token: 0x04000052 RID: 82
		internal const int int_6 = 8;

		// Token: 0x04000053 RID: 83
		internal const int int_7 = 32;

		// Token: 0x04000054 RID: 84
		private string string_0 = "";

		// Token: 0x04000055 RID: 85
		private bool bool_0;

		// Token: 0x04000056 RID: 86
		private uint uint_3;

		// Token: 0x04000057 RID: 87
		private string string_1 = "horion";

		// Token: 0x04000058 RID: 88
		private string string_2 = "C:\\";

		// Token: 0x04000059 RID: 89
		private string string_3 = "";

		// Token: 0x0400005A RID: 90
		private bool bool_1;

		// Token: 0x0400005B RID: 91
		private string string_4 = "";

		// Token: 0x0400005C RID: 92
		private const int int_8 = 2;

		// Token: 0x0400005D RID: 93
		private Class5 class5_0;

		// Token: 0x0400005E RID: 94
		private bool bool_2;

		// Token: 0x0400005F RID: 95
		private bool bool_3;

		// Token: 0x04000060 RID: 96
		private IContainer icontainer_0;
	}

}
