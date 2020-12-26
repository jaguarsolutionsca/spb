using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Contrat_Transporteur] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Contrat_Transporteur {

		Params.spS_Contrat_Transporteur Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Contrat_Transporteur class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Contrat_Transporteur(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat_Transporteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contrat_Transporteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Contrat_Transporteur(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contrat_Transporteur class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Contrat_Transporteur(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat_Transporteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contrat_Transporteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contrat_Transporteur(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contrat_Transporteur class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Contrat_Transporteur(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat_Transporteur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contrat_Transporteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contrat_Transporteur(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlString col_ContratID;
		/// <summary>
		/// Returns the value of the ContratID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContratID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ContratID {

			get {

				return (this.col_ContratID);
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

		private System.Data.SqlTypes.SqlString col_MunicipaliteID;
		/// <summary>
		/// Returns the value of the MunicipaliteID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MunicipaliteID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {

			get {

				return (this.col_MunicipaliteID);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Taux_transporteur;
		/// <summary>
		/// Returns the value of the Taux_transporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_transporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Taux_transporteur {

			get {

				return (this.col_Taux_transporteur);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Taux_producteur;
		/// <summary>
		/// Returns the value of the Taux_producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Taux_producteur {

			get {

				return (this.col_Taux_producteur);
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

		private System.Data.SqlTypes.SqlString col_ZoneID;
		/// <summary>
		/// Returns the value of the ZoneID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ZoneID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ZoneID {

			get {

				return (this.col_ZoneID);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.col_Taux_transporteur = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Taux_producteur = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Contrat_Transporteur] table.
		/// </summary>
		/// <param name="col_ContratID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContratID&quot; column.</param>
		/// <param name="col_UniteID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UniteID&quot; column.</param>
		/// <param name="col_MunicipaliteID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MunicipaliteID&quot; column.</param>
		/// <param name="col_ZoneID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ZoneID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlString col_ContratID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlString col_MunicipaliteID, System.Data.SqlTypes.SqlString col_ZoneID) {

			bool Status;
			Reset();

			if (col_ContratID.IsNull) {

				throw new ArgumentNullException("col_ContratID" , "The primary key 'col_ContratID' can not have a Null value!");
			}

			if (col_UniteID.IsNull) {

				throw new ArgumentNullException("col_UniteID" , "The primary key 'col_UniteID' can not have a Null value!");
			}

			if (col_MunicipaliteID.IsNull) {

				throw new ArgumentNullException("col_MunicipaliteID" , "The primary key 'col_MunicipaliteID' can not have a Null value!");
			}

			if (col_ZoneID.IsNull) {

				throw new ArgumentNullException("col_ZoneID" , "The primary key 'col_ZoneID' can not have a Null value!");
			}


			this.col_ContratID = col_ContratID;
			this.col_UniteID = col_UniteID;
			this.col_MunicipaliteID = col_MunicipaliteID;
			this.col_ZoneID = col_ZoneID;

			this.Param.Reset();

			this.Param.Param_ContratID = this.col_ContratID;
			this.Param.Param_UniteID = this.col_UniteID;
			this.Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			this.Param.Param_ZoneID = this.col_ZoneID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Contrat_Transporteur SP = new SPs.spS_Contrat_Transporteur(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Taux_transporteur.ColumnIndex)) {

						this.col_Taux_transporteur = DR.GetSqlSingle(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Taux_transporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Taux_producteur.ColumnIndex)) {

						this.col_Taux_producteur = DR.GetSqlSingle(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Taux_producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = DR.GetSqlBoolean(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Contrat_Transporteur", "Refresh");
			}
		}
	}
}
