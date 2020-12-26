using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Contingentement_VolumeFixe] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Contingentement_VolumeFixe {

		Params.spS_Contingentement_VolumeFixe Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement_VolumeFixe class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Contingentement_VolumeFixe(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_VolumeFixe'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement_VolumeFixe", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Contingentement_VolumeFixe(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement_VolumeFixe class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Contingentement_VolumeFixe(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_VolumeFixe'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement_VolumeFixe", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contingentement_VolumeFixe(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement_VolumeFixe class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Contingentement_VolumeFixe(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_VolumeFixe'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement_VolumeFixe", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contingentement_VolumeFixe(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_ContingentementID;
		/// <summary>
		/// Returns the value of the ContingentementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContingentementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_ContingentementID {

			get {

				return (this.col_ContingentementID);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Superficie_Min;
		/// <summary>
		/// Returns the value of the Superficie_Min column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Superficie_Min&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Superficie_Min {

			get {

				return (this.col_Superficie_Min);
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

		private System.Data.SqlTypes.SqlInt32 col_NombreMois;
		/// <summary>
		/// Returns the value of the NombreMois column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NombreMois&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_NombreMois {

			get {

				return (this.col_NombreMois);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_UseNombreMois;
		/// <summary>
		/// Returns the value of the UseNombreMois column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UseNombreMois&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_UseNombreMois {

			get {

				return (this.col_UseNombreMois);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Superficie_Min = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
			this.col_NombreMois = System.Data.SqlTypes.SqlInt32.Null;
			this.col_UseNombreMois = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Contingentement_VolumeFixe] table.
		/// </summary>
		/// <param name="col_ContingentementID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContingentementID&quot; column.</param>
		/// <param name="col_Superficie_Min">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Superficie_Min&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_ContingentementID, System.Data.SqlTypes.SqlSingle col_Superficie_Min) {

			bool Status;
			Reset();

			if (col_ContingentementID.IsNull) {

				throw new ArgumentNullException("col_ContingentementID" , "The primary key 'col_ContingentementID' can not have a Null value!");
			}

			if (col_Superficie_Min.IsNull) {

				throw new ArgumentNullException("col_Superficie_Min" , "The primary key 'col_Superficie_Min' can not have a Null value!");
			}


			this.col_ContingentementID = col_ContingentementID;
			this.col_Superficie_Min = col_Superficie_Min;

			this.Param.Reset();

			this.Param.Param_ContingentementID = this.col_ContingentementID;
			this.Param.Param_Superficie_Min = this.col_Superficie_Min;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Contingentement_VolumeFixe SP = new SPs.spS_Contingentement_VolumeFixe(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex)) {

						this.col_Volume_Fixe = DR.GetSqlSingle(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_NombreMois.ColumnIndex)) {

						this.col_NombreMois = DR.GetSqlInt32(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_NombreMois.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_UseNombreMois.ColumnIndex)) {

						this.col_UseNombreMois = DR.GetSqlBoolean(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_UseNombreMois.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Contingentement_VolumeFixe", "Refresh");
			}
		}
	}
}
