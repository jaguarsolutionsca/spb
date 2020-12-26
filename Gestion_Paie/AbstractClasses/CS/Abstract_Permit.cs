using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Permit] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Permit {

		Params.spS_Permit Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Permit class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Permit(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Permit'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Permit", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Permit(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Permit class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Permit(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Permit'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Permit", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Permit(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Permit class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Permit(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Permit'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Permit", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Permit(true);
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

		private System.Data.SqlTypes.SqlDateTime col_DatePermit;
		/// <summary>
		/// Returns the value of the DatePermit column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DatePermit&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DatePermit {

			get {

				return (this.col_DatePermit);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateDebut;
		/// <summary>
		/// Returns the value of the DateDebut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateDebut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateDebut {

			get {

				return (this.col_DateDebut);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateFin;
		/// <summary>
		/// Returns the value of the DateFin column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateFin&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateFin {

			get {

				return (this.col_DateFin);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Annee;
		/// <summary>
		/// Returns the value of the Annee column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Annee&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Annee {

			get {

				return (this.col_Annee);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Periode;
		/// <summary>
		/// Returns the value of the Periode column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Periode&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Periode {

			get {

				return (this.col_Periode);
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

		private System.Data.SqlTypes.SqlBoolean col_PermitSciage;
		/// <summary>
		/// Returns the value of the PermitSciage column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PermitSciage&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_PermitSciage {

			get {

				return (this.col_PermitSciage);
			}
		}

		private System.Data.SqlTypes.SqlString col_TransporteurID;
		/// <summary>
		/// Returns the value of the TransporteurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TransporteurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_TransporteurID {

			get {

				return (this.col_TransporteurID);
			}
		}

		private System.Data.SqlTypes.SqlString col_VR;
		/// <summary>
		/// Returns the value of the VR column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VR&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_VR {

			get {

				return (this.col_VR);
			}
		}

		private System.Data.SqlTypes.SqlString col_ProducteurDroitCoupeID;
		/// <summary>
		/// Returns the value of the ProducteurDroitCoupeID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ProducteurDroitCoupeID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ProducteurDroitCoupeID {

			get {

				return (this.col_ProducteurDroitCoupeID);
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

		private System.Data.SqlTypes.SqlBoolean col_PermitLivre;
		/// <summary>
		/// Returns the value of the PermitLivre column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PermitLivre&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_PermitLivre {

			get {

				return (this.col_PermitLivre);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_PermitImprime;
		/// <summary>
		/// Returns the value of the PermitImprime column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PermitImprime&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_PermitImprime {

			get {

				return (this.col_PermitImprime);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_PermitAnnule;
		/// <summary>
		/// Returns the value of the PermitAnnule column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PermitAnnule&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_PermitAnnule {

			get {

				return (this.col_PermitAnnule);
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

		private System.Data.SqlTypes.SqlString col_EssenceSciage;
		/// <summary>
		/// Returns the value of the EssenceSciage column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EssenceSciage&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_EssenceSciage {

			get {

				return (this.col_EssenceSciage);
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

		private System.Data.SqlTypes.SqlString col_Remarques;
		/// <summary>
		/// Returns the value of the Remarques column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Remarques&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Remarques {

			get {

				return (this.col_Remarques);
			}
		}

		private System.Data.SqlTypes.SqlString col_ChargeurID;
		/// <summary>
		/// Returns the value of the ChargeurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ChargeurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ChargeurID {

			get {

				return (this.col_ChargeurID);
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

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_DatePermit = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_DateDebut = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_DateFin = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Periode = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_PermitSciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_VR = System.Data.SqlTypes.SqlString.Null;
			this.col_ProducteurDroitCoupeID = System.Data.SqlTypes.SqlString.Null;
			this.col_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;
			this.col_PermitLivre = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_PermitImprime = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_PermitAnnule = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_LotID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_EssenceSciage = System.Data.SqlTypes.SqlString.Null;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;
			this.col_Remarques = System.Data.SqlTypes.SqlString.Null;
			this.col_ChargeurID = System.Data.SqlTypes.SqlString.Null;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Permit] table.
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
			SPs.spS_Permit SP = new SPs.spS_Permit(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_DatePermit.ColumnIndex)) {

						this.col_DatePermit = DR.GetSqlDateTime(SPs.spS_Permit.Resultset1.Fields.Column_DatePermit.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_DateDebut.ColumnIndex)) {

						this.col_DateDebut = DR.GetSqlDateTime(SPs.spS_Permit.Resultset1.Fields.Column_DateDebut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_DateFin.ColumnIndex)) {

						this.col_DateFin = DR.GetSqlDateTime(SPs.spS_Permit.Resultset1.Fields.Column_DateFin.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = DR.GetSqlInt32(SPs.spS_Permit.Resultset1.Fields.Column_Annee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_Periode.ColumnIndex)) {

						this.col_Periode = DR.GetSqlInt32(SPs.spS_Permit.Resultset1.Fields.Column_Periode.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_PermitSciage.ColumnIndex)) {

						this.col_PermitSciage = DR.GetSqlBoolean(SPs.spS_Permit.Resultset1.Fields.Column_PermitSciage.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_VR.ColumnIndex)) {

						this.col_VR = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_VR.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ProducteurDroitCoupeID.ColumnIndex)) {

						this.col_ProducteurDroitCoupeID = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ProducteurDroitCoupeID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ProducteurEntentePaiementID.ColumnIndex)) {

						this.col_ProducteurEntentePaiementID = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ProducteurEntentePaiementID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_PermitLivre.ColumnIndex)) {

						this.col_PermitLivre = DR.GetSqlBoolean(SPs.spS_Permit.Resultset1.Fields.Column_PermitLivre.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_PermitImprime.ColumnIndex)) {

						this.col_PermitImprime = DR.GetSqlBoolean(SPs.spS_Permit.Resultset1.Fields.Column_PermitImprime.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_PermitAnnule.ColumnIndex)) {

						this.col_PermitAnnule = DR.GetSqlBoolean(SPs.spS_Permit.Resultset1.Fields.Column_PermitAnnule.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_LotID.ColumnIndex)) {

						this.col_LotID = DR.GetSqlInt32(SPs.spS_Permit.Resultset1.Fields.Column_LotID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_EssenceSciage.ColumnIndex)) {

						this.col_EssenceSciage = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_EssenceSciage.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_Code.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_Remarques.ColumnIndex)) {

						this.col_Remarques = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_Remarques.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ChargeurID.ColumnIndex)) {

						this.col_ChargeurID = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ChargeurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ZoneID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = DR.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Permit", "Refresh");
			}
		}
	}
}
