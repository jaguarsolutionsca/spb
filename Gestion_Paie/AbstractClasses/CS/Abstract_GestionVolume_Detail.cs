using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [GestionVolume_Detail] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_GestionVolume_Detail {

		Params.spS_GestionVolume_Detail Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_GestionVolume_Detail class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_GestionVolume_Detail(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'GestionVolume_Detail'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "GestionVolume_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_GestionVolume_Detail(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_GestionVolume_Detail class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_GestionVolume_Detail(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'GestionVolume_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "GestionVolume_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_GestionVolume_Detail(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_GestionVolume_Detail class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_GestionVolume_Detail(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'GestionVolume_Detail'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "GestionVolume_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_GestionVolume_Detail(true);
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

		private System.Data.SqlTypes.SqlInt32 col_GestionVolumeID;
		/// <summary>
		/// Returns the value of the GestionVolumeID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;GestionVolumeID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_GestionVolumeID {

			get {

				return (this.col_GestionVolumeID);
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

		private System.Data.SqlTypes.SqlDouble col_VolumeBrut;
		/// <summary>
		/// Returns the value of the VolumeBrut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeBrut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeBrut {

			get {

				return (this.col_VolumeBrut);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeReduction;
		/// <summary>
		/// Returns the value of the VolumeReduction column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeReduction&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeReduction {

			get {

				return (this.col_VolumeReduction);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeNet;
		/// <summary>
		/// Returns the value of the VolumeNet column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeNet&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeNet {

			get {

				return (this.col_VolumeNet);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_GestionVolumeID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.col_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeReduction = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeNet = System.Data.SqlTypes.SqlDouble.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [GestionVolume_Detail] table.
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
			SPs.spS_GestionVolume_Detail SP = new SPs.spS_GestionVolume_Detail(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_GestionVolumeID.ColumnIndex)) {

						this.col_GestionVolumeID = DR.GetSqlInt32(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_GestionVolumeID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = DR.GetSqlString(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = DR.GetSqlString(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeBrut.ColumnIndex)) {

						this.col_VolumeBrut = DR.GetSqlDouble(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeBrut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeReduction.ColumnIndex)) {

						this.col_VolumeReduction = DR.GetSqlDouble(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeReduction.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeNet.ColumnIndex)) {

						this.col_VolumeNet = DR.GetSqlDouble(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeNet.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_GestionVolume_Detail", "Refresh");
			}
		}
	}
}
