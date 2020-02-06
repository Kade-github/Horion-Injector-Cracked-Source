using System;
using System.Collections.Generic;

// Token: 0x0200000B RID: 11
public static class GClass0
{
	// Token: 0x06000032 RID: 50 RVA: 0x00003348 File Offset: 0x00001548
	private static int[] smethod_0(byte[] byte_0)
	{
		int[] array = new int[256];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_0.Length;
		}
		for (int j = 0; j < byte_0.Length - 1; j++)
		{
			array[Convert.ToInt32(byte_0[j])] = byte_0.Length - j - 1;
		}
		return array;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00003398 File Offset: 0x00001598
	public static bool smethod_1(byte[] byte_0, byte[] byte_1, int int_0)
	{
		if (int_0 + byte_1.Length > byte_0.Length)
		{
			return false;
		}
		for (int i = 0; i < byte_1.Length; i++)
		{
			if (byte_0[i + int_0] != byte_1[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002265 File Offset: 0x00000465
	public static bool smethod_2(byte[] byte_0, byte[] byte_1)
	{
		return GClass0.smethod_3(byte_0, byte_1) != -1;
	}

	// Token: 0x06000035 RID: 53 RVA: 0x000033D0 File Offset: 0x000015D0
	public static int smethod_3(byte[] byte_0, byte[] byte_1)
	{
		int[] array = GClass0.smethod_0(byte_1);
		int num;
		for (int i = byte_1.Length - 1; i < byte_0.Length; i += array[Convert.ToInt32(byte_0[i - num])])
		{
			num = 0;
			while (num < byte_1.Length && byte_1[byte_1.Length - 1 - num] == byte_0[i - num])
			{
				if (num == byte_1.Length - 1)
				{
					return i - num;
				}
				num++;
			}
		}
		return -1;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00003430 File Offset: 0x00001630
	public static int smethod_4(byte[] byte_0, byte[] byte_1)
	{
		int result = -1;
		int[] array = GClass0.smethod_0(byte_1);
		int i = byte_1.Length - 1;
		while (i < byte_0.Length)
		{
			bool flag = false;
			int j;
			for (j = 0; j < byte_1.Length; j++)
			{
				if (byte_1[byte_1.Length - 1 - j] != byte_0[i - j])
				{
					break;
				}
				if (j == byte_1.Length - 1)
				{
					result = i - j;
					flag = true;
				}
			}
			if (!flag)
			{
				i += array[Convert.ToInt32(byte_0[i - j])];
			}
			else
			{
				i++;
			}
		}
		return result;
	}

	// Token: 0x06000037 RID: 55 RVA: 0x000034A8 File Offset: 0x000016A8
	public static int[] smethod_5(byte[] byte_0, byte[] byte_1)
	{
		List<int> list = new List<int>();
		int[] array = GClass0.smethod_0(byte_1);
		int i = byte_1.Length - 1;
		while (i < byte_0.Length)
		{
			bool flag = false;
			int num = 0;
			while (num < byte_1.Length && byte_1[byte_1.Length - 1 - num] == byte_0[i - num])
			{
				if (num == byte_1.Length - 1)
				{
					list.Add(i - num);
					flag = true;
				}
				num++;
			}
			if (flag)
			{
				i++;
			}
			else
			{
				i += array[Convert.ToInt32(byte_0[i - num])];
			}
		}
		return list.ToArray();
	}
}
