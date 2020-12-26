using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Cert_Proprietaire] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Cert_Proprietaire {

		Params.spS_Cert_Proprietaire Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Cert_Proprietaire class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Cert_Proprietaire(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Cert_Proprietaire'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Cert_Proprietaire", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Cert_Proprietaire(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Cert_Proprietaire class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Cert_Proprietaire(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Cert_Proprietaire'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Cert_Proprietaire", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Cert_Proprietaire(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Cert_Proprietaire class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Cert_Proprietaire(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Cert_Proprietaire'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Cert_Proprietaire", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Cert_Proprietaire(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlString col_Agence;
		/// <summary>
		/// Returns the value of the Agence column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Agence&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Agence {

			get {

				return (this.col_Agence);
			}
		}

		private System.Data.SqlTypes.SqlString col_NO_ACT;
		/// <summary>
		/// Returns the value of the NO_ACT column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NO_ACT&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_NO_ACT {

			get {

				return (this.col_NO_ACT);
			}
		}

		private System.Data.SqlTypes.SqlString col_Nom;
		/// <summary>
		/// Returns the value of the Nom column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Nom&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Nom {

			get {

				return (this.col_Nom);
			}
		}

		private System.Data.SqlTypes.SqlString col_Representant;
		/// <summary>
		/// Returns the value of the Representant column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Representant&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Representant {

			get {

				return (this.col_Representant);
			}
		}

		private System.Data.SqlTypes.SqlString col_ADRESSE;
		/// <summary>
		/// Returns the value of the ADRESSE column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ADRESSE&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ADRESSE {

			get {

				return (this.col_ADRESSE);
			}
		}

		private System.Data.SqlTypes.SqlString col_Ville;
		/// <summary>
		/// Returns the value of the Ville column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Ville&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Ville {

			get {

				return (this.col_Ville);
			}
		}

		private System.Data.SqlTypes.SqlString col_CODE_POST;
		/// <summary>
		/// Returns the value of the CODE_POST column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;CODE_POST&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_CODE_POST {

			get {

				return (this.col_CODE_POST);
			}
		}

		private System.Data.SqlTypes.SqlString col_TEL_RES;
		/// <summary>
		/// Returns the value of the TEL_RES column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TEL_RES&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_TEL_RES {

			get {

				return (this.col_TEL_RES);
			}
		}

		private System.Data.SqlTypes.SqlString col_TEL_BUR;
		/// <summary>
		/// Returns the value of the TEL_BUR column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TEL_BUR&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_TEL_BUR {

			get {

				return (this.col_TEL_BUR);
			}
		}

		private System.Data.SqlTypes.SqlString col_FournisseurID;
		/// <summary>
		/// Returns the value of the FournisseurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;FournisseurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_FournisseurID {

			get {

				return (this.col_FournisseurID);
			}
		}

		private System.Data.SqlTypes.SqlString col_FournisseurNom;
		/// <summary>
		/// Returns the value of the FournisseurNom column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;FournisseurNom&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_FournisseurNom {

			get {

				return (this.col_FournisseurNom);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Traite;
		/// <summary>
		/// Returns the value of the Traite column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Traite&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Traite {

			get {

				return (this.col_Traite);
			}
		}

		private System.Data.SqlTypes.SqlString col_Methode;
		/// <summary>
		/// Returns the value of the Methode column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Methode&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Methode {

			get {

				return (this.col_Methode);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_Agence = System.Data.SqlTypes.SqlString.Null;
			this.col_NO_ACT = System.Data.SqlTypes.SqlString.Null;
			this.col_Nom = System.Data.SqlTypes.SqlString.Null;
			this.col_Representant = System.Data.SqlTypes.SqlString.Null;
			this.col_ADRESSE = System.Data.SqlTypes.SqlString.Null;
			this.col_Ville = System.Data.SqlTypes.SqlString.Null;
			this.col_CODE_POST = System.Data.SqlTypes.SqlString.Null;
			this.col_TEL_RES = System.Data.SqlTypes.SqlString.Null;
			this.col_TEL_BUR = System.Data.SqlTypes.SqlString.Null;
			this.col_FournisseurID = System.Data.SqlTypes.SqlString.Null;
			this.col_FournisseurNom = System.Data.SqlTypes.SqlString.Null;
			this.col_Traite = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Methode = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Cert_Proprietaire] table.
		/// </summary>
		/// <param name="col_Agence">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Agence&quot; column.</param>
		/// <param name="col_NO_ACT">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NO_ACT&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlString col_Agence, System.Data.SqlTypes.SqlString col_NO_ACT) {

			bool Status;
			Reset();

			if (col_Agence.IsNull) {

				throw new ArgumentNullException("col_Agence" , "The primary key 'col_Agence' can not have a Null value!");
			}

			if (col_NO_ACT.IsNull) {

				throw new ArgumentNullException("col_NO_ACT" , "The primary key 'col_NO_ACT' can not have a Null value!");
			}


			this.col_Agence = col_Agence;
			this.col_NO_ACT = col_NO_ACT;

			this.Param.Reset();

			this.Param.Param_Agence = this.col_Agence;
			this.Param.Param_NO_ACT = this.col_NO_ACT;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Cert_Proprietaire SP = new SPs.spS_Cert_Proprietaire(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Nom.ColumnIndex)) {

						this.col_Nom = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Nom.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Representant.ColumnIndex)) {

						this.col_Representant = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Representant.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_ADRESSE.ColumnIndex)) {

						this.col_ADRESSE = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_ADRESSE.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Ville.ColumnIndex)) {

						this.col_Ville = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Ville.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_CODE_POST.ColumnIndex)) {

						this.col_CODE_POST = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_CODE_POST.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_TEL_RES.ColumnIndex)) {

						this.col_TEL_RES = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_TEL_RES.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_TEL_BUR.ColumnIndex)) {

						this.col_TEL_BUR = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_TEL_BUR.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_FournisseurID.ColumnIndex)) {

						this.col_FournisseurID = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_FournisseurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_FournisseurNom.ColumnIndex)) {

						this.col_FournisseurNom = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_FournisseurNom.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Traite.ColumnIndex)) {

						this.col_Traite = DR.GetSqlBoolean(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Traite.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Methode.ColumnIndex)) {

						this.col_Methode = DR.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Methode.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Cert_Proprietaire", "Refresh");
			}
		}
	}
}
