using System;

namespace Gestion_Paie.SqlDataAdapters {

	/// <summary>
	/// This class represents a full operational System.Data.SqlClient.SqlDataAdapter that can be
	/// used against the [Municipalite_Zone] table. The four basics operations are supported: Insert, Update, Delete and Select.
	/// </summary>
	public sealed class SqlDataAdapter_Municipalite_Zone {

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
		/// Creates a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public SqlDataAdapter_Municipalite_Zone(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Municipalite_Zone'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Municipalite_Zone", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public SqlDataAdapter_Municipalite_Zone(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Municipalite_Zone'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Municipalite_Zone", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public SqlDataAdapter_Municipalite_Zone(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Municipalite_Zone'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Municipalite_Zone", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Municipalite_Zone(string connectionString, System.Data.SqlTypes.SqlString FK_MunicipaliteID, string tableName) : this(connectionString) {

			this.Configure(FK_MunicipaliteID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Municipalite_Zone(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlTypes.SqlString FK_MunicipaliteID, string tableName) : this(sqlConnection) {

			this.Configure(FK_MunicipaliteID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Municipalite_Zone(System.Data.SqlClient.SqlTransaction sqlTransaction, System.Data.SqlTypes.SqlString FK_MunicipaliteID, string tableName) : this(sqlTransaction) {

			this.Configure(FK_MunicipaliteID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// The table name in the DataSet will be: Municipalite_Zone
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		public SqlDataAdapter_Municipalite_Zone(string connectionString, System.Data.SqlTypes.SqlString FK_MunicipaliteID) : this(connectionString) {

			this.Configure(FK_MunicipaliteID, "Municipalite_Zone");
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// The table name in the DataSet will be: Municipalite_Zone
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		public SqlDataAdapter_Municipalite_Zone(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlTypes.SqlString FK_MunicipaliteID) : this(sqlConnection) {

			this.Configure(FK_MunicipaliteID, "Municipalite_Zone");
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Municipalite_Zone class.
		/// The table name in the DataSet will be: Municipalite_Zone
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		public SqlDataAdapter_Municipalite_Zone(System.Data.SqlClient.SqlTransaction sqlTransaction, System.Data.SqlTypes.SqlString FK_MunicipaliteID) : this(sqlTransaction) {

			this.Configure(FK_MunicipaliteID, "Municipalite_Zone");
		}

		/// <summary>
		/// Configures the SqlDataAdapter.
		/// The table name in the DataSet will be: Municipalite_Zone
		/// </summary>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		public void Configure(System.Data.SqlTypes.SqlString FK_MunicipaliteID) {

			this.Configure(FK_MunicipaliteID, "Municipalite_Zone");
		}

		/// <summary>
		/// Configures the SqlDataAdapter.
		/// </summary>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public void Configure(System.Data.SqlTypes.SqlString FK_MunicipaliteID, string tableName) {

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

						throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.SqlDataAdapters.SqlDataAdapter_Municipalite_Zone)");
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
			sqlSelectCommand.CommandText = "spS_Municipalite_Zone";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "MunicipaliteID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_MunicipaliteID.IsNull) {

				sqlParameter.Value = FK_MunicipaliteID;
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
			sqlInsertCommand.CommandText = "spI_Municipalite_Zone";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "MunicipaliteID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Description";
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


			sqlUpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlUpdateCommand.CommandText = "spU_Municipalite_Zone";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "MunicipaliteID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Description";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Description", System.Data.SqlDbType.Bit, 1);
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


			sqlDeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlDeleteCommand.CommandText = "spD_Municipalite_Zone";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlDeleteCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlDeleteCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "MunicipaliteID";
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
						 "Municipalite_Zone"
						,tableName
						,new System.Data.Common.DataColumnMapping[] {
							 new System.Data.Common.DataColumnMapping("ID", "ID")
							,new System.Data.Common.DataColumnMapping("MunicipaliteID", "MunicipaliteID")
							,new System.Data.Common.DataColumnMapping("Description", "Description")
							,new System.Data.Common.DataColumnMapping("Actif", "Actif")
						}
					)
				}
			);
		}

		/// <summary>
		/// Populates the supplied DataSet object. By default,
		///the populated table name in the DataSet will be: Municipalite_Zone.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet) {

			this.FillDataSet(ref dataSet, "Municipalite_Zone", -1, -1);
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
		///the populated table name in the DataSet will be: Municipalite_Zone.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet, int startRecord, int maxRecords) {

			this.FillDataSet(ref dataSet, "Municipalite_Zone", startRecord, maxRecords);
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
