using System;
using System.Security.Cryptography;
using System.Text;

// Token: 0x02000025 RID: 37
public class GClass2
{
	// Token: 0x0600007C RID: 124 RVA: 0x0000A370 File Offset: 0x00008570
	public static string smethod_0(int int_0)
	{
		byte[] array = new byte[4 * int_0];
		using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
		{
			rngcryptoServiceProvider.GetBytes(array);
		}
		StringBuilder stringBuilder = new StringBuilder(int_0);
		for (int i = 0; i < int_0; i++)
		{
			long num = (long)((ulong)BitConverter.ToUInt32(array, i * 4) % (ulong)((long)GClass2.char_0.Length));
			stringBuilder.Append(GClass2.char_0[(int)(checked((IntPtr)num))]);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600007D RID: 125 RVA: 0x0000A3F0 File Offset: 0x000085F0
	public static string smethod_1(int int_0)
	{
		char[] array = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
		byte[] array2 = new byte[int_0];
		using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
		{
			rngcryptoServiceProvider.GetBytes(array2);
		}
		StringBuilder stringBuilder = new StringBuilder(int_0);
		foreach (byte b in array2)
		{
			stringBuilder.Append(array[(int)b % array.Length]);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x040001F3 RID: 499
	internal static readonly char[] char_0 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
}
