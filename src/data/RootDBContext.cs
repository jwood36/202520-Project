using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace coding_lms.data {
	public class RootDBContext : DbContext {
		/****
		 * Default Constructor
		 * "RootData" is the Default ConnectionString Name
		 * **/
		public RootDBContext() : this("RootData") { }
		public RootDBContext(string conn) : base(conn) {
			Schema = "dbo";
		}

		#region Shared Properties
		/// <summary>
		/// A member that represents the schema portion of a database object
		/// </summary>
		private string _schema;
		public string Schema {
			get { return _schema; }
			set { _schema = value; }
		}

		#endregion

		#region Shared Methods

		/***
		 * Execute a Stored Procedure
		 * 
		 * @name should be the Fully-Qualified signature for the Sproc, with parameter placeholder assignments, if necessary
		 * 
		 * 
		 * **/
		public IEnumerable<T> ExecuteSProc<T>(string name, params SqlParameter[] parms) {
			return this.Execute<T>(name, parms);
		}

		/// <summary>
		/// Execute a Stored Procedure but only Return a single Type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name"></param>
		/// <param name="parms"></param>
		/// <returns></returns>
		public T ExecuteFunc<T>(string name, params SqlParameter[] parms) {
			return this.Execute<T>(name, parms).Single();
		}

		/// <summary>
		/// Executes a Stored Procedure in the Database.
		///
		/// </summary>
		/// <typeparam name="T">any Type</typeparam>
		/// <param name="name">String value; Should be the full name + placeholders signature</param>
		/// <param name="parms">SqlParameter array</param>
		/// <returns>an IEnumerable&lt;<typeparamref name="T"/>&gt;</returns>
		/// <example>
		/// string v1 = "value";
		/// int v2 = 42;	// The meaning of life
		/// 
		/// SqlParameter[] parms = {
		///		new SqlParameter("@p1", v1) ,
		///		new SqlParameter("@p2", v2)
		/// };
		/// 
		/// // Ordinal Signature Call
		/// ExecuteStoredProcedure&lt;Entity&gt;("sproc @p1, @p2", parms);
		/// // Explicit Parameter Call
		/// ExecuteStoredProcedure&lt;Entity&gt;("sproc @Param1=@p1, @Param2=@p2", parms);
		/// </example>
		private IEnumerable<T> Execute<T>(string name, params SqlParameter[] parms) {
			return this.Database.SqlQuery<T>($"exec {name}", parms).ToList<T>();
		}
		#endregion

	}

}
