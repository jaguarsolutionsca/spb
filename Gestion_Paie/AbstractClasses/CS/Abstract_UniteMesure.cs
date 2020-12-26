using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [UniteMesure] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_UniteMesure {

		Params.spS_UniteMesure Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_UniteMesure class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_UniteMesure(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'UniteMesure'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "UniteMesure", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_UniteMesure(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_UniteMesure class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_UniteMesure(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'UniteMesure'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "UniteMesure", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_UniteMesure(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_UniteMesure class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_UniteMesure(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'UniteMesure'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "UniteMesure", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_UniteMesure(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlString col_ID;
		/// <summary>
		/// Returns the value of the ID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ID {

			get {

				return (this.col_ID);
			}
		}

		private System.Data.SqlTypes.SqlString col_Description;
		/// <summary>
		/// Returns the value of the Description column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Description&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Description {

			get {

				return (this.col_Description);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Nb_decimale;
		/// <summary>
		/// Returns the value of the Nb_decimale column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Nb_decimale&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Nb_decimale {

			get {

				return (this.col_Nb_decimale);
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

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_plan_conjoint;
		/// <summary>
		/// Returns the value of the Montant_Preleve_plan_conjoint column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_plan_conjoint&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_plan_conjoint {

			get {

				return (this.col_Montant_Preleve_plan_conjoint);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_fond_roulement;
		/// <summary>
		/// Returns the value of the Montant_Preleve_fond_roulement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_fond_roulement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_fond_roulement {

			get {

				return (this.col_Montant_Preleve_fond_roulement);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_fond_forestier;
		/// <summary>
		/// Returns the value of the Montant_Preleve_fond_forestier column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_fond_forestier&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_fond_forestier {

			get {

				return (this.col_Montant_Preleve_fond_forestier);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_divers;
		/// <summary>
		/// Returns the value of the Montant_Preleve_divers column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_divers&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_divers {

			get {

				return (this.col_Montant_Preleve_divers);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Pourc_Preleve_plan_conjoint;
		/// <summary>
		/// Returns the value of the Pourc_Preleve_plan_conjoint column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourc_Preleve_plan_conjoint&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Pourc_Preleve_plan_conjoint {

			get {

				return (this.col_Pourc_Preleve_plan_conjoint);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Pourc_Preleve_fond_roulement;
		/// <summary>
		/// Returns the value of the Pourc_Preleve_fond_roulement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourc_Preleve_fond_roulement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Pourc_Preleve_fond_roulement {

			get {

				return (this.col_Pourc_Preleve_fond_roulement);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Pourc_Preleve_fond_forestier;
		/// <summary>
		/// Returns the value of the Pourc_Preleve_fond_forestier column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourc_Preleve_fond_forestier&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Pourc_Preleve_fond_forestier {

			get {

				return (this.col_Pourc_Preleve_fond_forestier);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Pourc_Preleve_divers;
		/// <summary>
		/// Returns the value of the Pourc_Preleve_divers column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourc_Preleve_divers&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Pourc_Preleve_divers {

			get {

				return (this.col_Pourc_Preleve_divers);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlString.Null;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;
			this.col_Nb_decimale = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_UseMontant = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Montant_Preleve_plan_conjoint = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_fond_roulement = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_fond_forestier = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_divers = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Pourc_Preleve_plan_conjoint = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Pourc_Preleve_fond_roulement = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Pourc_Preleve_fond_forestier = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Pourc_Preleve_divers = System.Data.SqlTypes.SqlDouble.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [UniteMesure] table.
		/// </summary>
		/// <param name="col_ID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlString col_ID) {

			bool Status;
			Reset();

			if (col_ID.IsNull) {

				throw new ArgumentNullException("col_ID" , "The primary key 'col_ID' can not have a Null value!");
			}


			this.col_ID = col_ID;

			this.Param.Reset();

			this.Param.Param_ID = this.col_ID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_UniteMesure SP = new SPs.spS_UniteMesure(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = DR.GetSqlString(SPs.spS_UniteMesure.Resultset1.Fields.Column_Description.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Nb_decimale.ColumnIndex)) {

						this.col_Nb_decimale = DR.GetSqlInt32(SPs.spS_UniteMesure.Resultset1.Fields.Column_Nb_decimale.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = DR.GetSqlBoolean(SPs.spS_UniteMesure.Resultset1.Fields.Column_Actif.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_UseMontant.ColumnIndex)) {

						this.col_UseMontant = DR.GetSqlBoolean(SPs.spS_UniteMesure.Resultset1.Fields.Column_UseMontant.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_plan_conjoint.ColumnIndex)) {

						this.col_Montant_Preleve_plan_conjoint = DR.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_plan_conjoint.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_fond_roulement.ColumnIndex)) {

						this.col_Montant_Preleve_fond_roulement = DR.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_fond_roulement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_fond_forestier.ColumnIndex)) {

						this.col_Montant_Preleve_fond_forestier = DR.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_fond_forestier.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_divers.ColumnIndex)) {

						this.col_Montant_Preleve_divers = DR.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_divers.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_plan_conjoint.ColumnIndex)) {

						this.col_Pourc_Preleve_plan_conjoint = DR.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_plan_conjoint.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_fond_roulement.ColumnIndex)) {

						this.col_Pourc_Preleve_fond_roulement = DR.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_fond_roulement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_fond_forestier.ColumnIndex)) {

						this.col_Pourc_Preleve_fond_forestier = DR.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_fond_forestier.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_divers.ColumnIndex)) {

						this.col_Pourc_Preleve_divers = DR.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_divers.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_UniteMesure", "Refresh");
			}
		}
	}
}
