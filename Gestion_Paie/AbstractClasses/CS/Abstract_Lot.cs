using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Lot] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Lot {

		Params.spS_Lot Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Lot class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Lot(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Lot", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Lot(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Lot class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Lot(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Lot", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Lot(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Lot class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Lot(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Lot", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Lot(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlString col_CantonID;
		/// <summary>
		/// Returns the value of the CantonID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;CantonID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_CantonID {

			get {

				return (this.col_CantonID);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rang;
		/// <summary>
		/// Returns the value of the Rang column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rang&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rang {

			get {

				return (this.col_Rang);
			}
		}

		private System.Data.SqlTypes.SqlString col_Lot;
		/// <summary>
		/// Returns the value of the Lot column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Lot&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Lot {

			get {

				return (this.col_Lot);
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

		private System.Data.SqlTypes.SqlSingle col_Superficie_total;
		/// <summary>
		/// Returns the value of the Superficie_total column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Superficie_total&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Superficie_total {

			get {

				return (this.col_Superficie_total);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Superficie_boisee;
		/// <summary>
		/// Returns the value of the Superficie_boisee column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Superficie_boisee&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Superficie_boisee {

			get {

				return (this.col_Superficie_boisee);
			}
		}

		private System.Data.SqlTypes.SqlString col_ProprietaireID;
		/// <summary>
		/// Returns the value of the ProprietaireID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ProprietaireID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ProprietaireID {

			get {

				return (this.col_ProprietaireID);
			}
		}

		private System.Data.SqlTypes.SqlString col_ContingentID;
		/// <summary>
		/// Returns the value of the ContingentID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContingentID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ContingentID {

			get {

				return (this.col_ContingentID);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_Contingent_Date;
		/// <summary>
		/// Returns the value of the Contingent_Date column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Contingent_Date&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Contingent_Date {

			get {

				return (this.col_Contingent_Date);
			}
		}

		private System.Data.SqlTypes.SqlString col_Droit_coupeID;
		/// <summary>
		/// Returns the value of the Droit_coupeID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Droit_coupeID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Droit_coupeID {

			get {

				return (this.col_Droit_coupeID);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_Droit_coupe_Date;
		/// <summary>
		/// Returns the value of the Droit_coupe_Date column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Droit_coupe_Date&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Droit_coupe_Date {

			get {

				return (this.col_Droit_coupe_Date);
			}
		}

		private System.Data.SqlTypes.SqlString col_Entente_paiementID;
		/// <summary>
		/// Returns the value of the Entente_paiementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Entente_paiementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Entente_paiementID {

			get {

				return (this.col_Entente_paiementID);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_Entente_paiement_Date;
		/// <summary>
		/// Returns the value of the Entente_paiement_Date column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Entente_paiement_Date&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Entente_paiement_Date {

			get {

				return (this.col_Entente_paiement_Date);
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

		private System.Data.SqlTypes.SqlString col_Sequence;
		/// <summary>
		/// Returns the value of the Sequence column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Sequence&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Sequence {

			get {

				return (this.col_Sequence);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Partie;
		/// <summary>
		/// Returns the value of the Partie column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Partie&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Partie {

			get {

				return (this.col_Partie);
			}
		}

		private System.Data.SqlTypes.SqlString col_Matricule;
		/// <summary>
		/// Returns the value of the Matricule column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Matricule&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Matricule {

			get {

				return (this.col_Matricule);
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

		private System.Data.SqlTypes.SqlString col_Secteur;
		/// <summary>
		/// Returns the value of the Secteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Secteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Secteur {

			get {

				return (this.col_Secteur);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Cadastre;
		/// <summary>
		/// Returns the value of the Cadastre column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Cadastre&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Cadastre {

			get {

				return (this.col_Cadastre);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Reforme;
		/// <summary>
		/// Returns the value of the Reforme column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Reforme&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Reforme {

			get {

				return (this.col_Reforme);
			}
		}

		private System.Data.SqlTypes.SqlString col_LotsComplementaires;
		/// <summary>
		/// Returns the value of the LotsComplementaires column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LotsComplementaires&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_LotsComplementaires {

			get {

				return (this.col_LotsComplementaires);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Certifie;
		/// <summary>
		/// Returns the value of the Certifie column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Certifie&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Certifie {

			get {

				return (this.col_Certifie);
			}
		}

		private System.Data.SqlTypes.SqlString col_NumeroCertification;
		/// <summary>
		/// Returns the value of the NumeroCertification column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NumeroCertification&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_NumeroCertification {

			get {

				return (this.col_NumeroCertification);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_OGC;
		/// <summary>
		/// Returns the value of the OGC column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;OGC&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_OGC {

			get {

				return (this.col_OGC);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_CantonID = System.Data.SqlTypes.SqlString.Null;
			this.col_Rang = System.Data.SqlTypes.SqlString.Null;
			this.col_Lot = System.Data.SqlTypes.SqlString.Null;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.col_Superficie_total = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Superficie_boisee = System.Data.SqlTypes.SqlSingle.Null;
			this.col_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
			this.col_ContingentID = System.Data.SqlTypes.SqlString.Null;
			this.col_Contingent_Date = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Droit_coupeID = System.Data.SqlTypes.SqlString.Null;
			this.col_Droit_coupe_Date = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Entente_paiementID = System.Data.SqlTypes.SqlString.Null;
			this.col_Entente_paiement_Date = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Sequence = System.Data.SqlTypes.SqlString.Null;
			this.col_Partie = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Matricule = System.Data.SqlTypes.SqlString.Null;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.col_Secteur = System.Data.SqlTypes.SqlString.Null;
			this.col_Cadastre = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Reforme = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_LotsComplementaires = System.Data.SqlTypes.SqlString.Null;
			this.col_Certifie = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_NumeroCertification = System.Data.SqlTypes.SqlString.Null;
			this.col_OGC = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Lot] table.
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
			SPs.spS_Lot SP = new SPs.spS_Lot(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_CantonID.ColumnIndex)) {

						this.col_CantonID = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_CantonID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Rang.ColumnIndex)) {

						this.col_Rang = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Rang.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Lot.ColumnIndex)) {

						this.col_Lot = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Lot.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Superficie_total.ColumnIndex)) {

						this.col_Superficie_total = DR.GetSqlSingle(SPs.spS_Lot.Resultset1.Fields.Column_Superficie_total.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Superficie_boisee.ColumnIndex)) {

						this.col_Superficie_boisee = DR.GetSqlSingle(SPs.spS_Lot.Resultset1.Fields.Column_Superficie_boisee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_ProprietaireID.ColumnIndex)) {

						this.col_ProprietaireID = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_ProprietaireID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_ContingentID.ColumnIndex)) {

						this.col_ContingentID = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_ContingentID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Contingent_Date.ColumnIndex)) {

						this.col_Contingent_Date = DR.GetSqlDateTime(SPs.spS_Lot.Resultset1.Fields.Column_Contingent_Date.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Droit_coupeID.ColumnIndex)) {

						this.col_Droit_coupeID = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Droit_coupeID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Droit_coupe_Date.ColumnIndex)) {

						this.col_Droit_coupe_Date = DR.GetSqlDateTime(SPs.spS_Lot.Resultset1.Fields.Column_Droit_coupe_Date.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Entente_paiementID.ColumnIndex)) {

						this.col_Entente_paiementID = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Entente_paiementID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Entente_paiement_Date.ColumnIndex)) {

						this.col_Entente_paiement_Date = DR.GetSqlDateTime(SPs.spS_Lot.Resultset1.Fields.Column_Entente_paiement_Date.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = DR.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_Actif.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Sequence.ColumnIndex)) {

						this.col_Sequence = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Sequence.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Partie.ColumnIndex)) {

						this.col_Partie = DR.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_Partie.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Matricule.ColumnIndex)) {

						this.col_Matricule = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Matricule.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_ZoneID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Secteur.ColumnIndex)) {

						this.col_Secteur = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Secteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Cadastre.ColumnIndex)) {

						this.col_Cadastre = DR.GetSqlInt32(SPs.spS_Lot.Resultset1.Fields.Column_Cadastre.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Reforme.ColumnIndex)) {

						this.col_Reforme = DR.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_Reforme.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_LotsComplementaires.ColumnIndex)) {

						this.col_LotsComplementaires = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_LotsComplementaires.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Certifie.ColumnIndex)) {

						this.col_Certifie = DR.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_Certifie.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_NumeroCertification.ColumnIndex)) {

						this.col_NumeroCertification = DR.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_NumeroCertification.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_OGC.ColumnIndex)) {

						this.col_OGC = DR.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_OGC.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Lot", "Refresh");
			}
		}
	}
}
