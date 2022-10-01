using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Assets.Scripts.Database
{
	internal class LeaderboardIO
	{
		private static string _filename = "leaderboard.db";

		/// <summary>
		/// Записывает в конец файла строчку лидерборда
		/// </summary>
		public static void Write(LeaderboardRow leaderboard)
		{
			using (var stream = File.Open(_filename, FileMode.Append))
			{
				using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
				{
					writer.Write(leaderboard.PlayerName);
					writer.Write(leaderboard.MapId);
					writer.Write(leaderboard.WalkthroughTime);
				}
			}
		}

		/// <summary>
		/// Считывает лидерборд из файла
		/// </summary>
		public static List<LeaderboardRow> GetAllLeaderboardData()
		{
			List<LeaderboardRow> list = new List<LeaderboardRow>();


			if (File.Exists(_filename))
			{
				using (var stream = File.Open(_filename, FileMode.Open))
				{
					using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
					{
						while (reader.BaseStream.Position != reader.BaseStream.Length)
						{
							LeaderboardRow row = new LeaderboardRow();

							row.PlayerName = reader.ReadString();
							row.MapId = reader.ReadInt32();
							row.WalkthroughTime = reader.ReadDouble();

							list.Add(row);
						}
					}
				}
			}

			return list;
		}

		public static IEnumerable<LeaderboardRow> GetLeaderboard(int rowsAmount = 5)
		{
			var data = GetAllLeaderboardData();

			return data.OrderBy(r => r.WalkthroughTime).Take(rowsAmount);
		}
	}
}
