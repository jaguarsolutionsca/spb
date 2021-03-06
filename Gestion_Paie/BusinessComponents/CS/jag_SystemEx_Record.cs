﻿using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [jag_SystemEx] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.jag_SystemEx_Collection"/> class to do so.
	/// </summary>
	public sealed class jag_SystemEx_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the jag_SystemEx_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.jag_SystemEx_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public jag_SystemEx_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_Name">[To be supplied.]</param>
		public jag_SystemEx_Record(string connectionString, System.Data.SqlTypes.SqlString col_Name) {

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString != String.Empty) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_SystemEx'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "jag_SystemEx", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_Name = col_Name;
		}
		
		internal System.Data.SqlTypes.SqlString col_Name = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Name {
		
			get {
			
				return(this.col_Name);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Name = value;
				}
			}
		}
		
		internal bool col_ValueWasSet = false;
		private bool col_ValueWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Value = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Value {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Value);
			}
			set {
			
				this.col_ValueWasUpdated = true;
				this.col_ValueWasSet = true;
				this.col_Value = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_ValueWasUpdated = false;
			this.col_ValueWasSet = false;
			this.col_Value = System.Data.SqlTypes.SqlString.Null;

			Params.spS_jag_SystemEx Param = new Params.spS_jag_SystemEx(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_Name.IsNull) {

				Param.Param_Name = this.col_Name;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_jag_SystemEx Sp = new SPs.spS_jag_SystemEx();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_jag_SystemEx.Resultset1.Fields.Column_Value.ColumnIndex)) {

						this.col_Value = sqlDataReader.GetSqlString(SPs.spS_jag_SystemEx.Resultset1.Fields.Column_Value.ColumnIndex);
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = true;

					return(true);
				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = false;

					return(false);
				}
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_SystemEx_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ValueWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_jag_SystemEx Param = new Params.spU_jag_SystemEx(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_Name = this.col_Name;

			if (this.col_ValueWasUpdated) {

				Param.Param_Value = this.col_Value;
				Param.Param_ConsiderNull_Value = true;
			}

			SPs.spU_jag_SystemEx Sp = new SPs.spU_jag_SystemEx();
			if (Sp.Execute(ref Param)) {

				this.col_ValueWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_SystemEx_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_jag_SystemEx_Display Param = new Params.spS_jag_SystemEx_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_Name = this.col_Name;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_jag_SystemEx_Display Sp = new SPs.spS_jag_SystemEx_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_jag_SystemEx_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_jag_SystemEx_Display";
						}
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_SystemEx_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
