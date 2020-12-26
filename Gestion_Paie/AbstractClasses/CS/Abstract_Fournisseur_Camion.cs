using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Fournisseur_Camion] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Fournisseur_Camion {

		Params.spS_Fournisseur_Camion Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Fournisseur_Camion class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Fournisseur_Camion(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur_Camion'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur_Camion", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Fournisseur_Camion(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Fournisseur_Camion class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Fournisseur_Camion(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur_Camion'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur_Camion", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Fournisseur_Camion(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Fournisseur_Camion class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Fournisseur_Camion(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur_Camion'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur_Camion", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Fournisseur_Camion(true);
			this.Param.SetUpConnection(sqlTransaction);
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

		private System.Data.SqlTypes.SqlDouble col_MasseLimite;
		/// <summary>
		/// Returns the value of the MasseLimite column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MasseLimite&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_MasseLimite {

			get {

				return (this.col_MasseLimite);
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

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_FournisseurID = System.Data.SqlTypes.SqlString.Null;
			this.col_VR = System.Data.SqlTypes.SqlString.Null;
			this.col_MasseLimite = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Fournisseur_Camion] table.
		/// </summary>
		/// <param name="col_FournisseurID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;FournisseurID&quot; column.</param>
		/// <param name="col_VR">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VR&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlString col_FournisseurID, System.Data.SqlTypes.SqlString col_VR) {

			bool Status;
			Reset();

			if (col_FournisseurID.IsNull) {

				throw new ArgumentNullException("col_FournisseurID" , "The primary key 'col_FournisseurID' can not have a Null value!");
			}

			if (col_VR.IsNull) {

				throw new ArgumentNullException("col_VR" , "The primary key 'col_VR' can not have a Null value!");
			}


			this.col_FournisseurID = col_FournisseurID;
			this.col_VR = col_VR;

			this.Param.Reset();

			this.Param.Param_FournisseurID = this.col_FournisseurID;
			this.Param.Param_VR = this.col_VR;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Fournisseur_Camion SP = new SPs.spS_Fournisseur_Camion(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Fournisseur_Camion.Resultset1.Fields.Column_MasseLimite.ColumnIndex)) {

						this.col_MasseLimite = DR.GetSqlDouble(SPs.spS_Fournisseur_Camion.Resultset1.Fields.Column_MasseLimite.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur_Camion.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = DR.GetSqlBoolean(SPs.spS_Fournisseur_Camion.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Fournisseur_Camion", "Refresh");
			}
		}
	}
}
