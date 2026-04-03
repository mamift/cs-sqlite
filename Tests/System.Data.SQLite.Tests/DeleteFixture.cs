using CsSqlite.Client;
using NUnit.Framework;

namespace System.Data.SQLite.Tests
{
	[TestFixture]
	public class DeleteFixture
	{
		[Test()]
		public void SimpleDeleteTest()
		{
			using(var con = new SQLiteConnection("Data Source=:memory:"))
				using(var cmd = con.CreateCommand())
				{
					con.Open();
					cmd.CommandText = "CREATE TABLE People (id INTEGER NOT NULL, name VARCHAR(255) NULL);";
					cmd.ExecuteNonQuery();
					cmd.CommandText = "INSERT INTO People VALUES(1, 'test')";
					cmd.ExecuteNonQuery();
					cmd.CommandText = "INSERT INTO People VALUES(2, 'test')";
					cmd.ExecuteNonQuery();
					cmd.CommandText = "DELETE FROM People;";
					cmd.ExecuteNonQuery();
					cmd.CommandText = "SELECT COUNT(*) FROM People;";
					Assert.That(cmd.ExecuteScalar(), Is.EqualTo(0));
				}
		}

		[Test()]
		public void DeleteWhereClauseTest()
		{
			using(var con = new SQLiteConnection("Data Source=:memory:"))
				using(var cmd = con.CreateCommand())
				{
					con.Open();
					cmd.CommandText = "CREATE TABLE People (id INTEGER NOT NULL, name VARCHAR(255) NULL);";
					cmd.ExecuteNonQuery();
					cmd.CommandText = "INSERT INTO People VALUES(1, 'test')";
					cmd.ExecuteNonQuery();
					cmd.CommandText = "INSERT INTO People VALUES(2, 'test')";
					cmd.ExecuteNonQuery();
					cmd.CommandText = "DELETE FROM People WHERE id = 1;";
					cmd.ExecuteNonQuery();
					cmd.CommandText = "SELECT COUNT(*) FROM People;";
					Assert.That(cmd.ExecuteScalar(), Is.EqualTo(1));
				}
		}
	}
}

