using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [FactureUsine_Detail] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_FactureUsine_Detail {

		Params.spS_FactureUsine_Detail Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_FactureUsine_Detail class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_FactureUsine_Detail(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine_Detail'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureUsine_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_FactureUsine_Detail(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FactureUsine_Detail class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_FactureUsine_Detail(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureUsine_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FactureUsine_Detail(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FactureUsine_Detail class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_FactureUsine_Detail(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine_Detail'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureUsine_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FactureUsine_Detail(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_ID;
		/// <summary>
		/// Returns the value of the ID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_ID {

			get {

				return (this.col_ID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_FactureUsineID;
		/// <summary>
		/// Returns the value of the FactureUsineID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;FactureUsineID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_FactureUsineID {

			get {

				return (this.col_FactureUsineID);
			}
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

		private System.Data.SqlTypes.SqlString col_ProducteurID;
		/// <summary>
		/// Returns the value of the ProducteurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ProducteurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ProducteurID {

			get {

				return (this.col_ProducteurID);
			}
		}

		private System.Data.SqlTypes.SqlString col_ProducteurEntentePaiementID;
		/// <summary>
		/// Returns the value of the ProducteurEntentePaiementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ProducteurEntentePaiementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ProducteurEntentePaiementID {

			get {

				return (this.col_ProducteurEntentePaiementID);
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

		private System.Data.SqlTypes.SqlInt32 col_LotID;
		/// <summary>
		/// Returns the value of the LotID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LotID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_LotID {

			get {

				return (this.col_LotID);
			}
		}

		private System.Data.SqlTypes.SqlString col_UniteMesureID;
		/// <summary>
		/// Returns the value of the UniteMesureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UniteMesureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {

			get {

				return (this.col_UniteMesureID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_LivraisonID;
		/// <summary>
		/// Returns the value of the LivraisonID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LivraisonID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {

			get {

				return (this.col_LivraisonID);
			}
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

		private System.Data.SqlTypes.SqlString col_Code;
		/// <summary>
		/// Returns the value of the Code column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Code&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Code {

			get {

				return (this.col_Code);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Volume;
		/// <summary>
		/// Returns the value of the Volume column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Volume {

			get {

				return (this.col_Volume);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux;
		/// <summary>
		/// Returns the value of the Taux column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux {

			get {

				return (this.col_Taux);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant;
		/// <summary>
		/// Returns the value of the Montant column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant {

			get {

				return (this.col_Montant);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Taux_Usine_Override;
		/// <summary>
		/// Returns the value of the Taux_Usine_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Usine_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Taux_Usine_Override {

			get {

				return (this.col_Taux_Usine_Override);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_PermisID;
		/// <summary>
		/// Returns the value of the PermisID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PermisID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_PermisID {

			get {

				return (this.col_PermisID);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_FactureUsineID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.col_LotID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;
			this.col_Volume = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_Usine_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_PermisID = System.Data.SqlTypes.SqlInt32.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [FactureUsine_Detail] table.
		/// </summary>
		/// <param name="col_ID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_ID) {

			bool Status;
			Reset();

			if (col_ID.IsNull) {

				throw new ArgumentNullException("col_ID" , "The primary key 'col_ID' can not have a Null value!");
			}


			this.col_ID = col_ID;

			this.Param.Reset();

			this.Param.Param_ID = this.col_ID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_FactureUsine_Detail SP = new SPs.spS_FactureUsine_Detail(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_FactureUsineID.ColumnIndex)) {

						this.col_FactureUsineID = DR.GetSqlInt32(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_FactureUsineID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = DR.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ProducteurEntentePaiementID.ColumnIndex)) {

						this.col_ProducteurEntentePaiementID = DR.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ProducteurEntentePaiementID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = DR.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ZoneID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = DR.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_LotID.ColumnIndex)) {

						this.col_LotID = DR.GetSqlInt32(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_LotID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = DR.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_LivraisonID.ColumnIndex)) {

						this.col_LivraisonID = DR.GetSqlInt32(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_LivraisonID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = DR.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = DR.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Code.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Volume.ColumnIndex)) {

						this.col_Volume = DR.GetSqlDouble(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Volume.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Taux.ColumnIndex)) {

						this.col_Taux = DR.GetSqlDouble(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Taux.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Montant.ColumnIndex)) {

						this.col_Montant = DR.GetSqlDouble(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Montant.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Taux_Usine_Override.ColumnIndex)) {

						this.col_Taux_Usine_Override = DR.GetSqlBoolean(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Taux_Usine_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_PermisID.ColumnIndex)) {

						this.col_PermisID = DR.GetSqlInt32(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_PermisID.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_FactureUsine_Detail", "Refresh");
			}
		}
	}
}
