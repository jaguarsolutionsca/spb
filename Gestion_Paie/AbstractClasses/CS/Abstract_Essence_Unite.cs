using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Essence_Unite] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Essence_Unite {

		Params.spS_Essence_Unite Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Essence_Unite class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Essence_Unite(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString.Length != 0) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Essence_Unite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Essence_Unite", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Essence_Unite(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Essence_Unite class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Essence_Unite(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {

				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlConnection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlConnection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Essence_Unite'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Essence_Unite", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Essence_Unite(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Essence_Unite class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Essence_Unite(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {
				throw new ArgumentNullException("sqlTransaction", "Invalid transaction!");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlTransaction.Connection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlTransaction.Connection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlTransaction.Connection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Essence_Unite'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Essence_Unite", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Essence_Unite(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlString col_EssenceID;
		/// <summary>
		/// Returns the value of the EssenceID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EssenceID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_EssenceID {

			get {

				return (this.col_EssenceID);
			}
		}

		private System.Data.SqlTypes.SqlString col_UniteID;
		/// <summary>
		/// Returns the value of the UniteID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UniteID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_UniteID {

			get {

				return (this.col_UniteID);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Facteur_M3app;
		/// <summary>
		/// Returns the value of the Facteur_M3app column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Facteur_M3app&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Facteur_M3app {

			get {

				return (this.col_Facteur_M3app);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Facteur_M3sol;
		/// <summary>
		/// Returns the value of the Facteur_M3sol column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Facteur_M3sol&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Facteur_M3sol {

			get {

				return (this.col_Facteur_M3sol);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Facteur_FPBQ;
		/// <summary>
		/// Returns the value of the Facteur_FPBQ column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Facteur_FPBQ&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Facteur_FPBQ {

			get {

				return (this.col_Facteur_FPBQ);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Actif;
		/// <summary>
		/// Returns the value of the Actif column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Actif&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Actif {

			get {

				return (this.col_Actif);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Preleve_plan_conjoint;
		/// <summary>
		/// Returns the value of the Preleve_plan_conjoint column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Preleve_plan_conjoint&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Preleve_plan_conjoint {

			get {

				return (this.col_Preleve_plan_conjoint);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Preleve_plan_conjoint_Override;
		/// <summary>
		/// Returns the value of the Preleve_plan_conjoint_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Preleve_plan_conjoint_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Preleve_plan_conjoint_Override {

			get {

				return (this.col_Preleve_plan_conjoint_Override);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Preleve_fond_roulement;
		/// <summary>
		/// Returns the value of the Preleve_fond_roulement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Preleve_fond_roulement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Preleve_fond_roulement {

			get {

				return (this.col_Preleve_fond_roulement);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Preleve_fond_roulement_Override;
		/// <summary>
		/// Returns the value of the Preleve_fond_roulement_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Preleve_fond_roulement_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Preleve_fond_roulement_Override {

			get {

				return (this.col_Preleve_fond_roulement_Override);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Preleve_fond_forestier;
		/// <summary>
		/// Returns the value of the Preleve_fond_forestier column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Preleve_fond_forestier&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Preleve_fond_forestier {

			get {

				return (this.col_Preleve_fond_forestier);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Preleve_fond_forestier_Override;
		/// <summary>
		/// Returns the value of the Preleve_fond_forestier_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Preleve_fond_forestier_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Preleve_fond_forestier_Override {

			get {

				return (this.col_Preleve_fond_forestier_Override);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Preleve_divers;
		/// <summary>
		/// Returns the value of the Preleve_divers column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Preleve_divers&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Preleve_divers {

			get {

				return (this.col_Preleve_divers);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Preleve_divers_Override;
		/// <summary>
		/// Returns the value of the Preleve_divers_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Preleve_divers_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Preleve_divers_Override {

			get {

				return (this.col_Preleve_divers_Override);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_UseMontant;
		/// <summary>
		/// Returns the value of the UseMontant column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UseMontant&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_UseMontant {

			get {

				return (this.col_UseMontant);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;
			this.col_Facteur_M3app = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Facteur_M3sol = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Facteur_FPBQ = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Preleve_plan_conjoint = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Preleve_plan_conjoint_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Preleve_fond_roulement = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Preleve_fond_roulement_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Preleve_fond_forestier = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Preleve_fond_forestier_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Preleve_divers = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Preleve_divers_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_UseMontant = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Essence_Unite] table.
		/// </summary>
		/// <param name="col_EssenceID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EssenceID&quot; column.</param>
		/// <param name="col_UniteID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UniteID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteID) {

			bool Status;
			Reset();

			if (col_EssenceID.IsNull) {

				throw new ArgumentNullException("col_EssenceID" , "The primary key 'col_EssenceID' can not have a Null value!");
			}

			if (col_UniteID.IsNull) {

				throw new ArgumentNullException("col_UniteID" , "The primary key 'col_UniteID' can not have a Null value!");
			}


			this.col_EssenceID = col_EssenceID;
			this.col_UniteID = col_UniteID;

			this.Param.Reset();

			this.Param.Param_EssenceID = this.col_EssenceID;
			this.Param.Param_UniteID = this.col_UniteID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Essence_Unite SP = new SPs.spS_Essence_Unite(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_M3app.ColumnIndex)) {

						this.col_Facteur_M3app = DR.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_M3app.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_M3sol.ColumnIndex)) {

						this.col_Facteur_M3sol = DR.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_M3sol.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_FPBQ.ColumnIndex)) {

						this.col_Facteur_FPBQ = DR.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_FPBQ.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = DR.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Actif.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_plan_conjoint.ColumnIndex)) {

						this.col_Preleve_plan_conjoint = DR.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_plan_conjoint.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_plan_conjoint_Override.ColumnIndex)) {

						this.col_Preleve_plan_conjoint_Override = DR.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_plan_conjoint_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_roulement.ColumnIndex)) {

						this.col_Preleve_fond_roulement = DR.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_roulement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_roulement_Override.ColumnIndex)) {

						this.col_Preleve_fond_roulement_Override = DR.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_roulement_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_forestier.ColumnIndex)) {

						this.col_Preleve_fond_forestier = DR.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_forestier.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_forestier_Override.ColumnIndex)) {

						this.col_Preleve_fond_forestier_Override = DR.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_forestier_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_divers.ColumnIndex)) {

						this.col_Preleve_divers = DR.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_divers.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_divers_Override.ColumnIndex)) {

						this.col_Preleve_divers_Override = DR.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_divers_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_UseMontant.ColumnIndex)) {

						this.col_UseMontant = DR.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_UseMontant.ColumnIndex);
					}

					Status = true;
				}

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				return(Status);
			}

			else {

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Essence_Unite", "Refresh");
			}
		}
	}
}
