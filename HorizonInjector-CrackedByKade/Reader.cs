using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

// Token: 0x0200001D RID: 29
public class GClass1
{
	// Token: 0x06000071 RID: 113 RVA: 0x0000A20C File Offset: 0x0000840C
	public GClass1(string string_0)
	{
		using (FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read))
		{
			BinaryReader binaryReader = new BinaryReader(fileStream);
			this.gstruct1_0 = GClass1.smethod_2<GClass1.GStruct1>(binaryReader);
			fileStream.Seek((long)((ulong)this.gstruct1_0.uint_0), SeekOrigin.Begin);
			binaryReader.ReadUInt32();
			this.gstruct5_0 = GClass1.smethod_2<GClass1.GStruct5>(binaryReader);
			if (this.Boolean_0)
			{
				this.gstruct3_0 = GClass1.smethod_2<GClass1.GStruct3>(binaryReader);
			}
			else
			{
				this.gstruct4_0 = GClass1.smethod_2<GClass1.GStruct4>(binaryReader);
			}
			this.gstruct6_0 = new GClass1.GStruct6[(int)this.gstruct5_0.ushort_1];
			for (int i = 0; i < this.gstruct6_0.Length; i++)
			{
				this.gstruct6_0[i] = GClass1.smethod_2<GClass1.GStruct6>(binaryReader);
			}
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000236A File Offset: 0x0000056A
	public static GClass1 smethod_0()
	{
		return new GClass1(Assembly.GetCallingAssembly().Location);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x0000237B File Offset: 0x0000057B
	public static GClass1 smethod_1()
	{
		return new GClass1(Assembly.GetAssembly(typeof(GClass1)).Location);
	}

	// Token: 0x06000074 RID: 116 RVA: 0x0000A2DC File Offset: 0x000084DC
	public static T smethod_2<T>(BinaryReader binaryReader_0)
	{
		GCHandle gchandle = GCHandle.Alloc(binaryReader_0.ReadBytes(Marshal.SizeOf(typeof(T))), GCHandleType.Pinned);
		T result = (T)((object)Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(T)));
		gchandle.Free();
		return result;
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000075 RID: 117 RVA: 0x00002396 File Offset: 0x00000596
	public bool Boolean_0
	{
		get
		{
			return (256 & this.GStruct5_0.ushort_3) == 256;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000076 RID: 118 RVA: 0x000023B0 File Offset: 0x000005B0
	public GClass1.GStruct5 GStruct5_0
	{
		get
		{
			return this.gstruct5_0;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000077 RID: 119 RVA: 0x000023B8 File Offset: 0x000005B8
	public GClass1.GStruct3 GStruct3_0
	{
		get
		{
			return this.gstruct3_0;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000078 RID: 120 RVA: 0x000023C0 File Offset: 0x000005C0
	public GClass1.GStruct4 GStruct4_0
	{
		get
		{
			return this.gstruct4_0;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000079 RID: 121 RVA: 0x000023C8 File Offset: 0x000005C8
	public GClass1.GStruct6[] GStruct6_0
	{
		get
		{
			return this.gstruct6_0;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600007A RID: 122 RVA: 0x0000A328 File Offset: 0x00008528
	public DateTime DateTime_0
	{
		get
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
			dateTime = dateTime.AddSeconds(this.gstruct5_0.uint_0);
			dateTime += TimeZone.CurrentTimeZone.GetUtcOffset(dateTime);
			return dateTime;
		}
	}

	// Token: 0x04000136 RID: 310
	private GClass1.GStruct1 gstruct1_0;

	// Token: 0x04000137 RID: 311
	private GClass1.GStruct5 gstruct5_0;

	// Token: 0x04000138 RID: 312
	private GClass1.GStruct3 gstruct3_0;

	// Token: 0x04000139 RID: 313
	private GClass1.GStruct4 gstruct4_0;

	// Token: 0x0400013A RID: 314
	private GClass1.GStruct6[] gstruct6_0;

	// Token: 0x0200001E RID: 30
	public struct GStruct1
	{
		// Token: 0x0400013B RID: 315
		public ushort ushort_0;

		// Token: 0x0400013C RID: 316
		public ushort ushort_1;

		// Token: 0x0400013D RID: 317
		public ushort ushort_2;

		// Token: 0x0400013E RID: 318
		public ushort ushort_3;

		// Token: 0x0400013F RID: 319
		public ushort ushort_4;

		// Token: 0x04000140 RID: 320
		public ushort ushort_5;

		// Token: 0x04000141 RID: 321
		public ushort ushort_6;

		// Token: 0x04000142 RID: 322
		public ushort ushort_7;

		// Token: 0x04000143 RID: 323
		public ushort ushort_8;

		// Token: 0x04000144 RID: 324
		public ushort ushort_9;

		// Token: 0x04000145 RID: 325
		public ushort ushort_10;

		// Token: 0x04000146 RID: 326
		public ushort ushort_11;

		// Token: 0x04000147 RID: 327
		public ushort ushort_12;

		// Token: 0x04000148 RID: 328
		public ushort ushort_13;

		// Token: 0x04000149 RID: 329
		public ushort ushort_14;

		// Token: 0x0400014A RID: 330
		public ushort ushort_15;

		// Token: 0x0400014B RID: 331
		public ushort ushort_16;

		// Token: 0x0400014C RID: 332
		public ushort ushort_17;

		// Token: 0x0400014D RID: 333
		public ushort ushort_18;

		// Token: 0x0400014E RID: 334
		public ushort ushort_19;

		// Token: 0x0400014F RID: 335
		public ushort ushort_20;

		// Token: 0x04000150 RID: 336
		public ushort ushort_21;

		// Token: 0x04000151 RID: 337
		public ushort ushort_22;

		// Token: 0x04000152 RID: 338
		public ushort ushort_23;

		// Token: 0x04000153 RID: 339
		public ushort ushort_24;

		// Token: 0x04000154 RID: 340
		public ushort ushort_25;

		// Token: 0x04000155 RID: 341
		public ushort ushort_26;

		// Token: 0x04000156 RID: 342
		public ushort ushort_27;

		// Token: 0x04000157 RID: 343
		public ushort ushort_28;

		// Token: 0x04000158 RID: 344
		public ushort ushort_29;

		// Token: 0x04000159 RID: 345
		public uint uint_0;
	}

	// Token: 0x0200001F RID: 31
	public struct GStruct2
	{
		// Token: 0x0400015A RID: 346
		public uint uint_0;

		// Token: 0x0400015B RID: 347
		public uint uint_1;
	}

	// Token: 0x02000020 RID: 32
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GStruct3
	{
		// Token: 0x0400015C RID: 348
		public ushort ushort_0;

		// Token: 0x0400015D RID: 349
		public byte byte_0;

		// Token: 0x0400015E RID: 350
		public byte byte_1;

		// Token: 0x0400015F RID: 351
		public uint uint_0;

		// Token: 0x04000160 RID: 352
		public uint uint_1;

		// Token: 0x04000161 RID: 353
		public uint uint_2;

		// Token: 0x04000162 RID: 354
		public uint uint_3;

		// Token: 0x04000163 RID: 355
		public uint uint_4;

		// Token: 0x04000164 RID: 356
		public uint uint_5;

		// Token: 0x04000165 RID: 357
		public uint uint_6;

		// Token: 0x04000166 RID: 358
		public uint uint_7;

		// Token: 0x04000167 RID: 359
		public uint uint_8;

		// Token: 0x04000168 RID: 360
		public ushort ushort_1;

		// Token: 0x04000169 RID: 361
		public ushort ushort_2;

		// Token: 0x0400016A RID: 362
		public ushort ushort_3;

		// Token: 0x0400016B RID: 363
		public ushort ushort_4;

		// Token: 0x0400016C RID: 364
		public ushort ushort_5;

		// Token: 0x0400016D RID: 365
		public ushort ushort_6;

		// Token: 0x0400016E RID: 366
		public uint uint_9;

		// Token: 0x0400016F RID: 367
		public uint uint_10;

		// Token: 0x04000170 RID: 368
		public uint uint_11;

		// Token: 0x04000171 RID: 369
		public uint uint_12;

		// Token: 0x04000172 RID: 370
		public ushort ushort_7;

		// Token: 0x04000173 RID: 371
		public ushort ushort_8;

		// Token: 0x04000174 RID: 372
		public uint uint_13;

		// Token: 0x04000175 RID: 373
		public uint uint_14;

		// Token: 0x04000176 RID: 374
		public uint uint_15;

		// Token: 0x04000177 RID: 375
		public uint uint_16;

		// Token: 0x04000178 RID: 376
		public uint uint_17;

		// Token: 0x04000179 RID: 377
		public uint uint_18;

		// Token: 0x0400017A RID: 378
		public GClass1.GStruct2 gstruct2_0;

		// Token: 0x0400017B RID: 379
		public GClass1.GStruct2 gstruct2_1;

		// Token: 0x0400017C RID: 380
		public GClass1.GStruct2 gstruct2_2;

		// Token: 0x0400017D RID: 381
		public GClass1.GStruct2 gstruct2_3;

		// Token: 0x0400017E RID: 382
		public GClass1.GStruct2 gstruct2_4;

		// Token: 0x0400017F RID: 383
		public GClass1.GStruct2 gstruct2_5;

		// Token: 0x04000180 RID: 384
		public GClass1.GStruct2 gstruct2_6;

		// Token: 0x04000181 RID: 385
		public GClass1.GStruct2 gstruct2_7;

		// Token: 0x04000182 RID: 386
		public GClass1.GStruct2 gstruct2_8;

		// Token: 0x04000183 RID: 387
		public GClass1.GStruct2 gstruct2_9;

		// Token: 0x04000184 RID: 388
		public GClass1.GStruct2 gstruct2_10;

		// Token: 0x04000185 RID: 389
		public GClass1.GStruct2 gstruct2_11;

		// Token: 0x04000186 RID: 390
		public GClass1.GStruct2 gstruct2_12;

		// Token: 0x04000187 RID: 391
		public GClass1.GStruct2 gstruct2_13;

		// Token: 0x04000188 RID: 392
		public GClass1.GStruct2 gstruct2_14;

		// Token: 0x04000189 RID: 393
		public GClass1.GStruct2 gstruct2_15;
	}

	// Token: 0x02000021 RID: 33
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GStruct4
	{
		// Token: 0x0400018A RID: 394
		public ushort ushort_0;

		// Token: 0x0400018B RID: 395
		public byte byte_0;

		// Token: 0x0400018C RID: 396
		public byte byte_1;

		// Token: 0x0400018D RID: 397
		public uint uint_0;

		// Token: 0x0400018E RID: 398
		public uint uint_1;

		// Token: 0x0400018F RID: 399
		public uint uint_2;

		// Token: 0x04000190 RID: 400
		public uint uint_3;

		// Token: 0x04000191 RID: 401
		public uint uint_4;

		// Token: 0x04000192 RID: 402
		public ulong ulong_0;

		// Token: 0x04000193 RID: 403
		public uint uint_5;

		// Token: 0x04000194 RID: 404
		public uint uint_6;

		// Token: 0x04000195 RID: 405
		public ushort ushort_1;

		// Token: 0x04000196 RID: 406
		public ushort ushort_2;

		// Token: 0x04000197 RID: 407
		public ushort ushort_3;

		// Token: 0x04000198 RID: 408
		public ushort ushort_4;

		// Token: 0x04000199 RID: 409
		public ushort ushort_5;

		// Token: 0x0400019A RID: 410
		public ushort ushort_6;

		// Token: 0x0400019B RID: 411
		public uint uint_7;

		// Token: 0x0400019C RID: 412
		public uint uint_8;

		// Token: 0x0400019D RID: 413
		public uint uint_9;

		// Token: 0x0400019E RID: 414
		public uint uint_10;

		// Token: 0x0400019F RID: 415
		public ushort ushort_7;

		// Token: 0x040001A0 RID: 416
		public ushort ushort_8;

		// Token: 0x040001A1 RID: 417
		public ulong ulong_1;

		// Token: 0x040001A2 RID: 418
		public ulong ulong_2;

		// Token: 0x040001A3 RID: 419
		public ulong ulong_3;

		// Token: 0x040001A4 RID: 420
		public ulong ulong_4;

		// Token: 0x040001A5 RID: 421
		public uint uint_11;

		// Token: 0x040001A6 RID: 422
		public uint uint_12;

		// Token: 0x040001A7 RID: 423
		public GClass1.GStruct2 gstruct2_0;

		// Token: 0x040001A8 RID: 424
		public GClass1.GStruct2 gstruct2_1;

		// Token: 0x040001A9 RID: 425
		public GClass1.GStruct2 gstruct2_2;

		// Token: 0x040001AA RID: 426
		public GClass1.GStruct2 gstruct2_3;

		// Token: 0x040001AB RID: 427
		public GClass1.GStruct2 gstruct2_4;

		// Token: 0x040001AC RID: 428
		public GClass1.GStruct2 gstruct2_5;

		// Token: 0x040001AD RID: 429
		public GClass1.GStruct2 gstruct2_6;

		// Token: 0x040001AE RID: 430
		public GClass1.GStruct2 gstruct2_7;

		// Token: 0x040001AF RID: 431
		public GClass1.GStruct2 gstruct2_8;

		// Token: 0x040001B0 RID: 432
		public GClass1.GStruct2 gstruct2_9;

		// Token: 0x040001B1 RID: 433
		public GClass1.GStruct2 gstruct2_10;

		// Token: 0x040001B2 RID: 434
		public GClass1.GStruct2 gstruct2_11;

		// Token: 0x040001B3 RID: 435
		public GClass1.GStruct2 gstruct2_12;

		// Token: 0x040001B4 RID: 436
		public GClass1.GStruct2 gstruct2_13;

		// Token: 0x040001B5 RID: 437
		public GClass1.GStruct2 gstruct2_14;

		// Token: 0x040001B6 RID: 438
		public GClass1.GStruct2 gstruct2_15;
	}

	// Token: 0x02000022 RID: 34
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GStruct5
	{
		// Token: 0x040001B7 RID: 439
		public ushort ushort_0;

		// Token: 0x040001B8 RID: 440
		public ushort ushort_1;

		// Token: 0x040001B9 RID: 441
		public uint uint_0;

		// Token: 0x040001BA RID: 442
		public uint uint_1;

		// Token: 0x040001BB RID: 443
		public uint uint_2;

		// Token: 0x040001BC RID: 444
		public ushort ushort_2;

		// Token: 0x040001BD RID: 445
		public ushort ushort_3;
	}

	// Token: 0x02000023 RID: 35
	[StructLayout(LayoutKind.Explicit)]
	public struct GStruct6
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000023D0 File Offset: 0x000005D0
		public string String_0
		{
			get
			{
				return new string(this.char_0);
			}
		}

		// Token: 0x040001BE RID: 446
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public char[] char_0;

		// Token: 0x040001BF RID: 447
		[FieldOffset(8)]
		public uint uint_0;

		// Token: 0x040001C0 RID: 448
		[FieldOffset(12)]
		public uint uint_1;

		// Token: 0x040001C1 RID: 449
		[FieldOffset(16)]
		public uint uint_2;

		// Token: 0x040001C2 RID: 450
		[FieldOffset(20)]
		public uint uint_3;

		// Token: 0x040001C3 RID: 451
		[FieldOffset(24)]
		public uint uint_4;

		// Token: 0x040001C4 RID: 452
		[FieldOffset(28)]
		public uint uint_5;

		// Token: 0x040001C5 RID: 453
		[FieldOffset(32)]
		public ushort ushort_0;

		// Token: 0x040001C6 RID: 454
		[FieldOffset(34)]
		public ushort ushort_1;

		// Token: 0x040001C7 RID: 455
		[FieldOffset(36)]
		public GClass1.GEnum1 genum1_0;
	}

	// Token: 0x02000024 RID: 36
	[Flags]
	public enum GEnum1 : uint
	{
		// Token: 0x040001C9 RID: 457
		TypeReg = 0u,
		// Token: 0x040001CA RID: 458
		TypeDsect = 1u,
		// Token: 0x040001CB RID: 459
		TypeNoLoad = 2u,
		// Token: 0x040001CC RID: 460
		TypeGroup = 4u,
		// Token: 0x040001CD RID: 461
		TypeNoPadded = 8u,
		// Token: 0x040001CE RID: 462
		TypeCopy = 16u,
		// Token: 0x040001CF RID: 463
		ContentCode = 32u,
		// Token: 0x040001D0 RID: 464
		ContentInitializedData = 64u,
		// Token: 0x040001D1 RID: 465
		ContentUninitializedData = 128u,
		// Token: 0x040001D2 RID: 466
		LinkOther = 256u,
		// Token: 0x040001D3 RID: 467
		LinkInfo = 512u,
		// Token: 0x040001D4 RID: 468
		TypeOver = 1024u,
		// Token: 0x040001D5 RID: 469
		LinkRemove = 2048u,
		// Token: 0x040001D6 RID: 470
		LinkComDat = 4096u,
		// Token: 0x040001D7 RID: 471
		NoDeferSpecExceptions = 16384u,
		// Token: 0x040001D8 RID: 472
		RelativeGP = 32768u,
		// Token: 0x040001D9 RID: 473
		MemPurgeable = 131072u,
		// Token: 0x040001DA RID: 474
		Memory16Bit = 131072u,
		// Token: 0x040001DB RID: 475
		MemoryLocked = 262144u,
		// Token: 0x040001DC RID: 476
		MemoryPreload = 524288u,
		// Token: 0x040001DD RID: 477
		Align1Bytes = 1048576u,
		// Token: 0x040001DE RID: 478
		Align2Bytes = 2097152u,
		// Token: 0x040001DF RID: 479
		Align4Bytes = 3145728u,
		// Token: 0x040001E0 RID: 480
		Align8Bytes = 4194304u,
		// Token: 0x040001E1 RID: 481
		Align16Bytes = 5242880u,
		// Token: 0x040001E2 RID: 482
		Align32Bytes = 6291456u,
		// Token: 0x040001E3 RID: 483
		Align64Bytes = 7340032u,
		// Token: 0x040001E4 RID: 484
		Align128Bytes = 8388608u,
		// Token: 0x040001E5 RID: 485
		Align256Bytes = 9437184u,
		// Token: 0x040001E6 RID: 486
		Align512Bytes = 10485760u,
		// Token: 0x040001E7 RID: 487
		Align1024Bytes = 11534336u,
		// Token: 0x040001E8 RID: 488
		Align2048Bytes = 12582912u,
		// Token: 0x040001E9 RID: 489
		Align4096Bytes = 13631488u,
		// Token: 0x040001EA RID: 490
		Align8192Bytes = 14680064u,
		// Token: 0x040001EB RID: 491
		LinkExtendedRelocationOverflow = 16777216u,
		// Token: 0x040001EC RID: 492
		MemoryDiscardable = 33554432u,
		// Token: 0x040001ED RID: 493
		MemoryNotCached = 67108864u,
		// Token: 0x040001EE RID: 494
		MemoryNotPaged = 134217728u,
		// Token: 0x040001EF RID: 495
		MemoryShared = 268435456u,
		// Token: 0x040001F0 RID: 496
		MemoryExecute = 536870912u,
		// Token: 0x040001F1 RID: 497
		MemoryRead = 1073741824u,
		// Token: 0x040001F2 RID: 498
		MemoryWrite = 2147483648u
	}
}
