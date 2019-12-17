// TS3AudioBot - An advanced Musicbot for Teamspeak 3
// Copyright (C) 2017  TS3AudioBot contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the Open Software License v. 3.0
//
// You should have received a copy of the Open Software License along with this
// program. If not, see <https://opensource.org/licenses/OSL-3.0>.

using System;
using System.Collections.Generic;
using TS3AudioBot.Config;
using TSLib.Helper;

namespace TS3AudioBot.Helper.Environment
{
	public class Stats
	{
		private const string StatsTable = "stats";
		private static readonly TimeSpan CheckSendInterval = TimeSpan.FromHours(1);
		private static readonly TimeSpan SendInterval = TimeSpan.FromDays(7);

		private readonly ConfRoot conf;
		private TickWorker ticker;
		private readonly object lockObj = new object();

		private DateTime runtimeLastTrack;

		public Stats(ConfRoot conf, DbStore database)
		{
			this.conf = conf;

			database.GetMetaData(StatsTable);

			runtimeLastTrack = Tools.Now;
		}

		public void StartSendStats()
		{
			if (ticker != null)
				throw new InvalidOperationException();
			ticker = TickPool.RegisterTick(CheckSendStats, CheckSendInterval, true);
		}

		public void CheckSendStats()
		{
			if (!conf.Configs.SendStats)
				return;

			lock (lockObj)
			{

			}
		}

		public void TrackSongLoad(string factory, bool successful, bool fromUser)
		{
			lock (lockObj)
			{

			}
		}

		public void TrackSongPlayback(string factory, TimeSpan time)
		{
			lock (lockObj)
			{

			}
		}

		public void TrackRuntime()
		{
			lock (lockObj)
			{

			}
		}

		public void TrackBotRuntime()
		{
			lock (lockObj)
			{

			}
		}

		public class StatsPing
		{
			public string Platform { get; set; }
			public string Runtime { get; set; }
			public string BotVersion { get; set; }
			public int RunningBots { get; set; }
			public TimeSpan RunTime { get; set; }
			public Dictionary<string, StatsFactory> SongStats { get; set; }
		}

		public class StatsData
		{
			public TimeSpan RunTime { get; set; }
			public Dictionary<string, StatsFactory> SongStats { get; set; }
		}

		public class StatsFactory
		{
			public int? Requests { get; set; }
			public int? Loaded { get; set; }
			///<summary>How many actually were started by a user (and not i.e. from a playlist)</summary>
			public int? FromUser { get; set; }
			public TimeSpan? Playtime { get; set; }
		}
	}
}
