using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Contingentement] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Contingentement {

		Params.spS_Contingentement Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Contingentement(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Contingentement(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Contingentement(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contingentement(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Contingentement(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contingentement(true);
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

		private System.Data.SqlTypes.SqlBoolean col_ContingentUsine;
		/// <summary>
		/// Returns the value of the ContingentUsine column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContingentUsine&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_ContingentUsine {

			get {

				return (this.col_ContingentUsine);
			}
		}

		private System.Data.SqlTypes.SqlString col_UsineID;
		/// <summary>
		/// Returns the value of the UsineID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UsineID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_UsineID {

			get {

				return (this.col_UsineID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_RegroupementID;
		/// <summary>
		/// Returns the value of the RegroupementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;RegroupementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_RegroupementID {

			get {

				return (this.col_RegroupementID);
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

		private System.Data.SqlTypes.SqlInt32 col_PeriodeContingentement;
		/// <summary>
		/// Returns the value of the PeriodeContingentement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PeriodeContingentement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_PeriodeContingentement {

			get {

				return (this.col_PeriodeContingentement);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_PeriodeDebut;
		/// <summary>
		/// Returns the value of the PeriodeDebut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PeriodeDebut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_PeriodeDebut {

			get {

				return (this.col_PeriodeDebut);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_PeriodeFin;
		/// <summary>
		/// Returns the value of the PeriodeFin column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PeriodeFin&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_PeriodeFin {

			get {

				return (this.col_PeriodeFin);
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

		private System.Data.SqlTypes.SqlSingle col_Volume_Usine;
		/// <summary>
		/// Returns the value of the Volume_Usine column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Usine&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Usine {

			get {

				return (this.col_Volume_Usine);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Facteur;
		/// <summary>
		/// Returns the value of the Facteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Facteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Facteur {

			get {

				return (this.col_Facteur);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Volume_Fixe;
		/// <summary>
		/// Returns the value of the Volume_Fixe column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Fixe&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Fixe {

			get {

				return (this.col_Volume_Fixe);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_Date_Calcul;
		/// <summary>
		/// Returns the value of the Date_Calcul column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Date_Calcul&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Date_Calcul {

			get {

				return (this.col_Date_Calcul);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_CalculAccepte;
		/// <summary>
		/// Returns the value of the CalculAccepte column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;CalculAccepte&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_CalculAccepte {

			get {

				return (this.col_CalculAccepte);
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

		private System.Data.SqlTypes.SqlSingle col_Volume_Regroupement;
		/// <summary>
		/// Returns the value of the Volume_Regroupement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Regroupement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Regroupement {

			get {

				return (this.col_Volume_Regroupement);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Volume_RegroupementPourcentage;
		/// <summary>
		/// Returns the value of the Volume_RegroupementPourcentage column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_RegroupementPourcentage&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_RegroupementPourcentage {

			get {

				return (this.col_Volume_RegroupementPourcentage);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_MaxVolumeFixe_Pourcentage;
		/// <summary>
		/// Returns the value of the MaxVolumeFixe_Pourcentage column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MaxVolumeFixe_Pourcentage&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_MaxVolumeFixe_Pourcentage {

			get {

				return (this.col_MaxVolumeFixe_Pourcentage);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_MaxVolumeFixe_ContingentementID;
		/// <summary>
		/// Returns the value of the MaxVolumeFixe_ContingentementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MaxVolumeFixe_ContingentementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_MaxVolumeFixe_ContingentementID {

			get {

				return (this.col_MaxVolumeFixe_ContingentementID);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_UseVolumeFixeUnique;
		/// <summary>
		/// Returns the value of the UseVolumeFixeUnique column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UseVolumeFixeUnique&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_UseVolumeFixeUnique {

			get {

				return (this.col_UseVolumeFixeUnique);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_MasseContingentVoyageDefaut;
		/// <summary>
		/// Returns the value of the MasseContingentVoyageDefaut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MasseContingentVoyageDefaut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_MasseContingentVoyageDefaut {

			get {

				return (this.col_MasseContingentVoyageDefaut);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ContingentUsine = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_UsineID = System.Data.SqlTypes.SqlString.Null;
			this.col_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.col_PeriodeContingentement = System.Data.SqlTypes.SqlInt32.Null;
			this.col_PeriodeDebut = System.Data.SqlTypes.SqlInt32.Null;
			this.col_PeriodeFin = System.Data.SqlTypes.SqlInt32.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.col_Volume_Usine = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Facteur = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Date_Calcul = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_CalculAccepte = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;
			this.col_Volume_Regroupement = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Volume_RegroupementPourcentage = System.Data.SqlTypes.SqlSingle.Null;
			this.col_MaxVolumeFixe_Pourcentage = System.Data.SqlTypes.SqlSingle.Null;
			this.col_MaxVolumeFixe_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_UseVolumeFixeUnique = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_MasseContingentVoyageDefaut = System.Data.SqlTypes.SqlSingle.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Contingentement] table.
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
			SPs.spS_Contingentement SP = new SPs.spS_Contingentement(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_ContingentUsine.ColumnIndex)) {

						this.col_ContingentUsine = DR.GetSqlBoolean(SPs.spS_Contingentement.Resultset1.Fields.Column_ContingentUsine.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_UsineID.ColumnIndex)) {

						this.col_UsineID = DR.GetSqlString(SPs.spS_Contingentement.Resultset1.Fields.Column_UsineID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_RegroupementID.ColumnIndex)) {

						this.col_RegroupementID = DR.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_RegroupementID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = DR.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_Annee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeContingentement.ColumnIndex)) {

						this.col_PeriodeContingentement = DR.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeContingentement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeDebut.ColumnIndex)) {

						this.col_PeriodeDebut = DR.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeDebut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeFin.ColumnIndex)) {

						this.col_PeriodeFin = DR.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeFin.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = DR.GetSqlString(SPs.spS_Contingentement.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = DR.GetSqlString(SPs.spS_Contingentement.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Usine.ColumnIndex)) {

						this.col_Volume_Usine = DR.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Usine.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Facteur.ColumnIndex)) {

						this.col_Facteur = DR.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Facteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex)) {

						this.col_Volume_Fixe = DR.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Date_Calcul.ColumnIndex)) {

						this.col_Date_Calcul = DR.GetSqlDateTime(SPs.spS_Contingentement.Resultset1.Fields.Column_Date_Calcul.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_CalculAccepte.ColumnIndex)) {

						this.col_CalculAccepte = DR.GetSqlBoolean(SPs.spS_Contingentement.Resultset1.Fields.Column_CalculAccepte.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = DR.GetSqlString(SPs.spS_Contingentement.Resultset1.Fields.Column_Code.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Regroupement.ColumnIndex)) {

						this.col_Volume_Regroupement = DR.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Regroupement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_RegroupementPourcentage.ColumnIndex)) {

						this.col_Volume_RegroupementPourcentage = DR.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_RegroupementPourcentage.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_MaxVolumeFixe_Pourcentage.ColumnIndex)) {

						this.col_MaxVolumeFixe_Pourcentage = DR.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_MaxVolumeFixe_Pourcentage.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_MaxVolumeFixe_ContingentementID.ColumnIndex)) {

						this.col_MaxVolumeFixe_ContingentementID = DR.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_MaxVolumeFixe_ContingentementID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_UseVolumeFixeUnique.ColumnIndex)) {

						this.col_UseVolumeFixeUnique = DR.GetSqlBoolean(SPs.spS_Contingentement.Resultset1.Fields.Column_UseVolumeFixeUnique.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_MasseContingentVoyageDefaut.ColumnIndex)) {

						this.col_MasseContingentVoyageDefaut = DR.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_MasseContingentVoyageDefaut.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Contingentement", "Refresh");
			}
		}
	}
}
