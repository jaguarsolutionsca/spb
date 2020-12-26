using System;

namespace Gestion_Paie.SqlDataAdapters {

	/// <summary>
	/// This class represents a full operational System.Data.SqlClient.SqlDataAdapter that can be
	/// used against the [Fournisseur] table. The four basics operations are supported: Insert, Update, Delete and Select.
	/// </summary>
	public sealed class SqlDataAdapter_Fournisseur {

		private string connectionString;
		private System.Data.SqlClient.SqlConnection sqlConnection;
		private System.Data.SqlClient.SqlTransaction sqlTransaction;
		private bool CloseConnectionAfterUse = true;
		private Gestion_Paie.DataClasses.ConnectionType lastKnownConnectionType = Gestion_Paie.DataClasses.ConnectionType.None;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter;
		private bool hasBeenConfigured = false;

		/// <summary>
		/// Returns the current type of connection that is going or has been used
		/// against the Sql Server database. It can be: ConnectionString, SqlConnection
		/// or SqlTransaction
		/// </summary>
		public Gestion_Paie.DataClasses.ConnectionType ConnectionType {

			get {

				return(this.lastKnownConnectionType);
			}
		}

		/// <summary>
		/// Returns the connection string used to access the Sql Server database.
		/// </summary>
		public string ConnectionString {

			get {

				if (this.lastKnownConnectionType != Gestion_Paie.DataClasses.ConnectionType.ConnectionString) {

					throw new InvalidOperationException("The connection string was not set in the class constructor.");
				}

				return(this.connectionString);
			}
		}

		/// <summary>
		/// Returns the SqlConnection used to access the Sql Server database.
		/// </summary>
		public System.Data.SqlClient.SqlConnection SqlConnection {

			get {

				if (this.lastKnownConnectionType != Gestion_Paie.DataClasses.ConnectionType.SqlConnection) {

					throw new InvalidOperationException("The SqlConnection was not set in the class constructor.");
				}

				return(this.sqlConnection);
			}
		}

		/// <summary>
		/// Returns the SqlTransaction used to access the Sql Server database.
		/// </summary>
		public System.Data.SqlClient.SqlTransaction SqlTransaction{

			get {

				if (this.lastKnownConnectionType != Gestion_Paie.DataClasses.ConnectionType.SqlTransaction) {

					throw new InvalidOperationException("The SqlTransaction was not set in the class constructor.");
				}

				return(this.sqlTransaction);
			}
		}

		/// <summary>
		/// Returns the underlying System.Data.SqlClient.SqlDataAdapter object.
		/// </summary>
		public System.Data.SqlClient.SqlDataAdapter SqlDataAdapter {

			get {

				return(this.sqlDataAdapter);
			}
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Fournisseur class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public SqlDataAdapter_Fournisseur(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

			this.connectionString = connectionString;
			this.lastKnownConnectionType = Gestion_Paie.DataClasses.ConnectionType.ConnectionString;

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Fournisseur class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public SqlDataAdapter_Fournisseur(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {

				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

			this.sqlConnection = sqlConnection;
			this.lastKnownConnectionType = Gestion_Paie.DataClasses.ConnectionType.SqlConnection;

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Fournisseur class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public SqlDataAdapter_Fournisseur(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {

				throw new ArgumentNullException("sqlTransaction", "Invalid transaction!");
			}

			this.sqlTransaction = sqlTransaction;
			this.lastKnownConnectionType = Gestion_Paie.DataClasses.ConnectionType.SqlTransaction;

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Fournisseur class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="FK_InstitutionBanquaireID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Fournisseur(string connectionString, System.Data.SqlTypes.SqlString FK_PaysID, System.Data.SqlTypes.SqlString FK_InstitutionBanquaireID, string tableName) : this(connectionString) {

			this.Configure(FK_PaysID, FK_InstitutionBanquaireID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Fournisseur class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="FK_InstitutionBanquaireID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Fournisseur(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlTypes.SqlString FK_PaysID, System.Data.SqlTypes.SqlString FK_InstitutionBanquaireID, string tableName) : this(sqlConnection) {

			this.Configure(FK_PaysID, FK_InstitutionBanquaireID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Fournisseur class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="FK_InstitutionBanquaireID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Fournisseur(System.Data.SqlClient.SqlTransaction sqlTransaction, System.Data.SqlTypes.SqlString FK_PaysID, System.Data.SqlTypes.SqlString FK_InstitutionBanquaireID, string tableName) : this(sqlTransaction) {

			this.Configure(FK_PaysID, FK_InstitutionBanquaireID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Fournisseur class.
		/// The table name in the DataSet will be: Fournisseur
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="FK_InstitutionBanquaireID">Value for this foreign key.</param>
		public SqlDataAdapter_Fournisseur(string connectionString, System.Data.SqlTypes.SqlString FK_PaysID, System.Data.SqlTypes.SqlString FK_InstitutionBanquaireID) : this(connectionString) {

			this.Configure(FK_PaysID, FK_InstitutionBanquaireID, "Fournisseur");
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Fournisseur class.
		/// The table name in the DataSet will be: Fournisseur
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="FK_InstitutionBanquaireID">Value for this foreign key.</param>
		public SqlDataAdapter_Fournisseur(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlTypes.SqlString FK_PaysID, System.Data.SqlTypes.SqlString FK_InstitutionBanquaireID) : this(sqlConnection) {

			this.Configure(FK_PaysID, FK_InstitutionBanquaireID, "Fournisseur");
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Fournisseur class.
		/// The table name in the DataSet will be: Fournisseur
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="FK_InstitutionBanquaireID">Value for this foreign key.</param>
		public SqlDataAdapter_Fournisseur(System.Data.SqlClient.SqlTransaction sqlTransaction, System.Data.SqlTypes.SqlString FK_PaysID, System.Data.SqlTypes.SqlString FK_InstitutionBanquaireID) : this(sqlTransaction) {

			this.Configure(FK_PaysID, FK_InstitutionBanquaireID, "Fournisseur");
		}

		/// <summary>
		/// Configures the SqlDataAdapter.
		/// The table name in the DataSet will be: Fournisseur
		/// </summary>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="FK_InstitutionBanquaireID">Value for this foreign key.</param>
		public void Configure(System.Data.SqlTypes.SqlString FK_PaysID, System.Data.SqlTypes.SqlString FK_InstitutionBanquaireID) {

			this.Configure(FK_PaysID, FK_InstitutionBanquaireID, "Fournisseur");
		}

		/// <summary>
		/// Configures the SqlDataAdapter.
		/// </summary>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="FK_InstitutionBanquaireID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public void Configure(System.Data.SqlTypes.SqlString FK_PaysID, System.Data.SqlTypes.SqlString FK_InstitutionBanquaireID, string tableName) {

			this.hasBeenConfigured = true;

			this.sqlDataAdapter = null;

			System.Data.SqlClient.SqlCommand sqlSelectCommand;
			System.Data.SqlClient.SqlCommand sqlInsertCommand;
			System.Data.SqlClient.SqlCommand sqlUpdateCommand;
			System.Data.SqlClient.SqlCommand sqlDeleteCommand;
			System.Data.SqlClient.SqlParameter sqlParameter;
			
			sqlSelectCommand = new System.Data.SqlClient.SqlCommand();
			sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
			sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
			sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();

			System.Data.SqlClient.SqlConnection localSqlConnection = null;
			switch (this.lastKnownConnectionType) {

				case Gestion_Paie.DataClasses.ConnectionType.ConnectionString:

					string connectionString = this.ConnectionString;
				
					if (connectionString.Length == 0) {

						connectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
						if (connectionString.Length == 0) {

							connectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
						}
					}

					if (connectionString.Length == 0) {

						throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.SqlDataAdapters.SqlDataAdapter_Fournisseur)");
					}

					localSqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);

					sqlSelectCommand.Connection = localSqlConnection;
					sqlInsertCommand.Connection = localSqlConnection;
					sqlUpdateCommand.Connection = localSqlConnection;
					sqlDeleteCommand.Connection = localSqlConnection;

					break;

				case Gestion_Paie.DataClasses.ConnectionType.SqlConnection:

					localSqlConnection = this.SqlConnection;

					sqlSelectCommand.Connection = localSqlConnection;
					sqlInsertCommand.Connection = localSqlConnection;
					sqlUpdateCommand.Connection = localSqlConnection;
					sqlDeleteCommand.Connection = localSqlConnection;

					break;

				case Gestion_Paie.DataClasses.ConnectionType.SqlTransaction:

					sqlSelectCommand.Connection = this.sqlTransaction.Connection;
					sqlSelectCommand.Transaction = this.sqlTransaction;

					sqlInsertCommand.Connection = this.sqlTransaction.Connection;
					sqlInsertCommand.Transaction = this.sqlTransaction;

					sqlUpdateCommand.Connection = this.sqlTransaction.Connection;
					sqlUpdateCommand.Transaction = this.sqlTransaction;

					sqlDeleteCommand.Connection = this.sqlTransaction.Connection;
					sqlDeleteCommand.Transaction = this.sqlTransaction;

					break;
			}

			sqlSelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlSelectCommand.CommandText = "spS_Fournisseur";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "PaysID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_PaysID.IsNull) {

				sqlParameter.Value = FK_PaysID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@InstitutionBanquaireID", System.Data.SqlDbType.VarChar, 3);
			sqlParameter.SourceColumn = "InstitutionBanquaireID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_InstitutionBanquaireID.IsNull) {

				sqlParameter.Value = FK_InstitutionBanquaireID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ReturnXML", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = false;
			sqlSelectCommand.Parameters.Add(sqlParameter);


			sqlInsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlInsertCommand.CommandText = "spI_Fournisseur";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@CleTri", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "CleTri";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Nom", System.Data.SqlDbType.VarChar, 40);
			sqlParameter.SourceColumn = "Nom";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@AuSoinsDe", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "AuSoinsDe";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rue", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Rue";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Ville";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "PaysID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Code_postal", System.Data.SqlDbType.VarChar, 7);
			sqlParameter.SourceColumn = "Code_postal";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telecopieur", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telecopieur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone2";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Desc", System.Data.SqlDbType.VarChar, 20);
			sqlParameter.SourceColumn = "Telephone2_Desc";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone2_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone3";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Desc", System.Data.SqlDbType.VarChar, 20);
			sqlParameter.SourceColumn = "Telephone3_Desc";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone3_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@No_membre", System.Data.SqlDbType.VarChar, 10);
			sqlParameter.SourceColumn = "No_membre";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Resident", System.Data.SqlDbType.Char, 1);
			sqlParameter.SourceColumn = "Resident";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Email";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@WWW", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "WWW";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires", System.Data.SqlDbType.VarChar, 255);
			sqlParameter.SourceColumn = "Commentaires";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@AfficherCommentaires", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "AfficherCommentaires";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DepotDirect", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "DepotDirect";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@InstitutionBanquaireID", System.Data.SqlDbType.VarChar, 3);
			sqlParameter.SourceColumn = "InstitutionBanquaireID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Banque_transit", System.Data.SqlDbType.VarChar, 5);
			sqlParameter.SourceColumn = "Banque_transit";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Banque_folio", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Banque_folio";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@No_TPS", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "No_TPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@No_TVQ", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "No_TVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PayerA", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "PayerA";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PayerAID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "PayerAID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Statut", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Statut";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Nom", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Rep_Nom";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Telephone", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Rep_Telephone";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Rep_Telephone_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Email", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Rep_Email";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@EnAnglais", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "EnAnglais";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Actif", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Actif";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MRCProducteurID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "MRCProducteurID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaiementManuel", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "PaiementManuel";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Journal", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Journal";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RecoitTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "RecoitTPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RecoitTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "RecoitTVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ModifierTrigger", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "ModifierTrigger";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsProducteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsChargeur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsChargeur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsAutre", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsAutre";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@AfficherCommentairesSurPermit", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "AfficherCommentairesSurPermit";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PasEmissionPermis", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "PasEmissionPermis";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Generique", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Generique";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Membre_OGC", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Membre_OGC";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@InscritTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "InscritTPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@InscritTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "InscritTVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsOGC", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsOGC";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Nom", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Rep2_Nom";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Telephone", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Rep2_Telephone";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Rep2_Telephone_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Email", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Rep2_Email";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Commentaires", System.Data.SqlDbType.VarChar, 255);
			sqlParameter.SourceColumn = "Rep2_Commentaires";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);


			sqlUpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlUpdateCommand.CommandText = "spU_Fournisseur";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@CleTri", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "CleTri";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_CleTri", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Nom", System.Data.SqlDbType.VarChar, 40);
			sqlParameter.SourceColumn = "Nom";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Nom", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@AuSoinsDe", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "AuSoinsDe";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_AuSoinsDe", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rue", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Rue";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rue", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Ville";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Ville", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "PaysID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PaysID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Code_postal", System.Data.SqlDbType.VarChar, 7);
			sqlParameter.SourceColumn = "Code_postal";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Code_postal", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone_Poste", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telecopieur", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telecopieur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telecopieur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone2";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone2", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Desc", System.Data.SqlDbType.VarChar, 20);
			sqlParameter.SourceColumn = "Telephone2_Desc";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone2_Desc", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone2_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone2_Poste", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone3";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone3", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Desc", System.Data.SqlDbType.VarChar, 20);
			sqlParameter.SourceColumn = "Telephone3_Desc";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone3_Desc", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone3_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone3_Poste", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@No_membre", System.Data.SqlDbType.VarChar, 10);
			sqlParameter.SourceColumn = "No_membre";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_No_membre", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Resident", System.Data.SqlDbType.Char, 1);
			sqlParameter.SourceColumn = "Resident";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Resident", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Email";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Email", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@WWW", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "WWW";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_WWW", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires", System.Data.SqlDbType.VarChar, 255);
			sqlParameter.SourceColumn = "Commentaires";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Commentaires", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@AfficherCommentaires", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "AfficherCommentaires";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_AfficherCommentaires", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DepotDirect", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "DepotDirect";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DepotDirect", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@InstitutionBanquaireID", System.Data.SqlDbType.VarChar, 3);
			sqlParameter.SourceColumn = "InstitutionBanquaireID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_InstitutionBanquaireID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Banque_transit", System.Data.SqlDbType.VarChar, 5);
			sqlParameter.SourceColumn = "Banque_transit";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Banque_transit", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Banque_folio", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Banque_folio";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Banque_folio", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@No_TPS", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "No_TPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_No_TPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@No_TVQ", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "No_TVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_No_TVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PayerA", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "PayerA";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PayerA", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PayerAID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "PayerAID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PayerAID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Statut", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Statut";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Statut", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Nom", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Rep_Nom";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep_Nom", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Telephone", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Rep_Telephone";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep_Telephone", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Rep_Telephone_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep_Telephone_Poste", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Email", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Rep_Email";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep_Email", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@EnAnglais", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "EnAnglais";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_EnAnglais", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Actif", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Actif";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Actif", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MRCProducteurID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "MRCProducteurID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_MRCProducteurID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaiementManuel", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "PaiementManuel";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PaiementManuel", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Journal", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Journal";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Journal", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RecoitTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "RecoitTPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_RecoitTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RecoitTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "RecoitTVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_RecoitTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ModifierTrigger", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "ModifierTrigger";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ModifierTrigger", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsProducteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IsProducteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IsTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsChargeur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsChargeur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IsChargeur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsAutre", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsAutre";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IsAutre", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@AfficherCommentairesSurPermit", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "AfficherCommentairesSurPermit";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_AfficherCommentairesSurPermit", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PasEmissionPermis", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "PasEmissionPermis";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PasEmissionPermis", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Generique", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Generique";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Generique", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Membre_OGC", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Membre_OGC";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Membre_OGC", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@InscritTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "InscritTPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_InscritTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@InscritTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "InscritTVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_InscritTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsOGC", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsOGC";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IsOGC", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Nom", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Rep2_Nom";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep2_Nom", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Telephone", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Rep2_Telephone";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep2_Telephone", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Rep2_Telephone_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep2_Telephone_Poste", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Email", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Rep2_Email";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep2_Email", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Commentaires", System.Data.SqlDbType.VarChar, 255);
			sqlParameter.SourceColumn = "Rep2_Commentaires";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rep2_Commentaires", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);


			sqlDeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlDeleteCommand.CommandText = "spD_Fournisseur";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlDeleteCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlDeleteCommand.Parameters.Add(sqlParameter);


			// Let's create the SqlDataAdapter
			this.sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();

			this.sqlDataAdapter.SelectCommand = sqlSelectCommand;
			this.sqlDataAdapter.InsertCommand = sqlInsertCommand;
			this.sqlDataAdapter.UpdateCommand = sqlUpdateCommand;
			this.sqlDataAdapter.DeleteCommand = sqlDeleteCommand;

			this.sqlDataAdapter.TableMappings.AddRange (

				new System.Data.Common.DataTableMapping[] {

					new System.Data.Common.DataTableMapping (
						 "Fournisseur"
						,tableName
						,new System.Data.Common.DataColumnMapping[] {
							 new System.Data.Common.DataColumnMapping("ID", "ID")
							,new System.Data.Common.DataColumnMapping("CleTri", "CleTri")
							,new System.Data.Common.DataColumnMapping("Nom", "Nom")
							,new System.Data.Common.DataColumnMapping("AuSoinsDe", "AuSoinsDe")
							,new System.Data.Common.DataColumnMapping("Rue", "Rue")
							,new System.Data.Common.DataColumnMapping("Ville", "Ville")
							,new System.Data.Common.DataColumnMapping("PaysID", "PaysID")
							,new System.Data.Common.DataColumnMapping("Code_postal", "Code_postal")
							,new System.Data.Common.DataColumnMapping("Telephone", "Telephone")
							,new System.Data.Common.DataColumnMapping("Telephone_Poste", "Telephone_Poste")
							,new System.Data.Common.DataColumnMapping("Telecopieur", "Telecopieur")
							,new System.Data.Common.DataColumnMapping("Telephone2", "Telephone2")
							,new System.Data.Common.DataColumnMapping("Telephone2_Desc", "Telephone2_Desc")
							,new System.Data.Common.DataColumnMapping("Telephone2_Poste", "Telephone2_Poste")
							,new System.Data.Common.DataColumnMapping("Telephone3", "Telephone3")
							,new System.Data.Common.DataColumnMapping("Telephone3_Desc", "Telephone3_Desc")
							,new System.Data.Common.DataColumnMapping("Telephone3_Poste", "Telephone3_Poste")
							,new System.Data.Common.DataColumnMapping("No_membre", "No_membre")
							,new System.Data.Common.DataColumnMapping("Resident", "Resident")
							,new System.Data.Common.DataColumnMapping("Email", "Email")
							,new System.Data.Common.DataColumnMapping("WWW", "WWW")
							,new System.Data.Common.DataColumnMapping("Commentaires", "Commentaires")
							,new System.Data.Common.DataColumnMapping("AfficherCommentaires", "AfficherCommentaires")
							,new System.Data.Common.DataColumnMapping("DepotDirect", "DepotDirect")
							,new System.Data.Common.DataColumnMapping("InstitutionBanquaireID", "InstitutionBanquaireID")
							,new System.Data.Common.DataColumnMapping("Banque_transit", "Banque_transit")
							,new System.Data.Common.DataColumnMapping("Banque_folio", "Banque_folio")
							,new System.Data.Common.DataColumnMapping("No_TPS", "No_TPS")
							,new System.Data.Common.DataColumnMapping("No_TVQ", "No_TVQ")
							,new System.Data.Common.DataColumnMapping("PayerA", "PayerA")
							,new System.Data.Common.DataColumnMapping("PayerAID", "PayerAID")
							,new System.Data.Common.DataColumnMapping("Statut", "Statut")
							,new System.Data.Common.DataColumnMapping("Rep_Nom", "Rep_Nom")
							,new System.Data.Common.DataColumnMapping("Rep_Telephone", "Rep_Telephone")
							,new System.Data.Common.DataColumnMapping("Rep_Telephone_Poste", "Rep_Telephone_Poste")
							,new System.Data.Common.DataColumnMapping("Rep_Email", "Rep_Email")
							,new System.Data.Common.DataColumnMapping("EnAnglais", "EnAnglais")
							,new System.Data.Common.DataColumnMapping("Actif", "Actif")
							,new System.Data.Common.DataColumnMapping("MRCProducteurID", "MRCProducteurID")
							,new System.Data.Common.DataColumnMapping("PaiementManuel", "PaiementManuel")
							,new System.Data.Common.DataColumnMapping("Journal", "Journal")
							,new System.Data.Common.DataColumnMapping("RecoitTPS", "RecoitTPS")
							,new System.Data.Common.DataColumnMapping("RecoitTVQ", "RecoitTVQ")
							,new System.Data.Common.DataColumnMapping("ModifierTrigger", "ModifierTrigger")
							,new System.Data.Common.DataColumnMapping("IsProducteur", "IsProducteur")
							,new System.Data.Common.DataColumnMapping("IsTransporteur", "IsTransporteur")
							,new System.Data.Common.DataColumnMapping("IsChargeur", "IsChargeur")
							,new System.Data.Common.DataColumnMapping("IsAutre", "IsAutre")
							,new System.Data.Common.DataColumnMapping("AfficherCommentairesSurPermit", "AfficherCommentairesSurPermit")
							,new System.Data.Common.DataColumnMapping("PasEmissionPermis", "PasEmissionPermis")
							,new System.Data.Common.DataColumnMapping("Generique", "Generique")
							,new System.Data.Common.DataColumnMapping("Membre_OGC", "Membre_OGC")
							,new System.Data.Common.DataColumnMapping("InscritTPS", "InscritTPS")
							,new System.Data.Common.DataColumnMapping("InscritTVQ", "InscritTVQ")
							,new System.Data.Common.DataColumnMapping("IsOGC", "IsOGC")
							,new System.Data.Common.DataColumnMapping("Rep2_Nom", "Rep2_Nom")
							,new System.Data.Common.DataColumnMapping("Rep2_Telephone", "Rep2_Telephone")
							,new System.Data.Common.DataColumnMapping("Rep2_Telephone_Poste", "Rep2_Telephone_Poste")
							,new System.Data.Common.DataColumnMapping("Rep2_Email", "Rep2_Email")
							,new System.Data.Common.DataColumnMapping("Rep2_Commentaires", "Rep2_Commentaires")
						}
					)
				}
			);
		}

		/// <summary>
		/// Populates the supplied DataSet object. By default,
		///the populated table name in the DataSet will be: Fournisseur.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet) {

			this.FillDataSet(ref dataSet, "Fournisseur", -1, -1);
		}

		/// <summary>
		/// Populates the supplied DataSet object.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet, string tableName) {

			this.FillDataSet(ref dataSet, tableName, -1, -1);
		}

		/// <summary>
		/// Populates the supplied DataSet object. By default,
		///the populated table name in the DataSet will be: Fournisseur.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet, int startRecord, int maxRecords) {

			this.FillDataSet(ref dataSet, "Fournisseur", startRecord, maxRecords);
		}

		/// <summary>
		/// Populates the supplied DataSet object.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet, string tableName, int startRecord, int maxRecords) {

			if (!this.hasBeenConfigured) {

				throw new InvalidOperationException("This SqlDataAdapter has not been configured. Call the Configure method first.");
			}

			if (this.lastKnownConnectionType == Gestion_Paie.DataClasses.ConnectionType.SqlConnection && this.sqlConnection != null) {
			
				CloseConnectionAfterUse = (this.SqlConnection.State != System.Data.ConnectionState.Open);
			}

			if (dataSet == null) {

				dataSet = new System.Data.DataSet();
			}

			if (startRecord == -1) {

				this.sqlDataAdapter.Fill(dataSet, tableName);
			}
			else {

				this.sqlDataAdapter.Fill(dataSet, startRecord, maxRecords, tableName);
			}

			if (this.CloseConnectionAfterUse && this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open) {

				this.sqlConnection.Close();
			}
		}	
	}
}
