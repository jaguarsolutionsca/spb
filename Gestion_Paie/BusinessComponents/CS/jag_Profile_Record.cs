using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [jag_Profile] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.jag_Profile_Collection"/> class to do so.
	/// </summary>
	public sealed class jag_Profile_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the jag_Profile_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.jag_Profile_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public jag_Profile_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public jag_Profile_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_Profile'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "jag_Profile", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ID {
		
			get {
			
				return(this.col_ID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ID = value;
				}
			}
		}
		
		internal bool col_NomWasSet = false;
		private bool col_NomWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Nom = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Nom {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Nom);
			}
			set {
			
				this.col_NomWasUpdated = true;
				this.col_NomWasSet = true;
				this.col_Nom = value;
			}
		}

		internal bool col_PasswordWasSet = false;
		private bool col_PasswordWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Password = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Password {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Password);
			}
			set {
			
				this.col_PasswordWasUpdated = true;
				this.col_PasswordWasSet = true;
				this.col_Password = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_NomWasUpdated = false;
			this.col_NomWasSet = false;
			this.col_Nom = System.Data.SqlTypes.SqlString.Null;

			this.col_PasswordWasUpdated = false;
			this.col_PasswordWasSet = false;
			this.col_Password = System.Data.SqlTypes.SqlString.Null;

			Params.spS_jag_Profile Param = new Params.spS_jag_Profile(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_jag_Profile Sp = new SPs.spS_jag_Profile();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_jag_Profile.Resultset1.Fields.Column_Nom.ColumnIndex)) {

						this.col_Nom = sqlDataReader.GetSqlString(SPs.spS_jag_Profile.Resultset1.Fields.Column_Nom.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_jag_Profile.Resultset1.Fields.Column_Password.ColumnIndex)) {

						this.col_Password = sqlDataReader.GetSqlString(SPs.spS_jag_Profile.Resultset1.Fields.Column_Password.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_Profile_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NomWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PasswordWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_jag_Profile Param = new Params.spU_jag_Profile(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_NomWasUpdated) {

				Param.Param_Nom = this.col_Nom;
				Param.Param_ConsiderNull_Nom = true;
			}

			if (this.col_PasswordWasUpdated) {

				Param.Param_Password = this.col_Password;
				Param.Param_ConsiderNull_Password = true;
			}

			SPs.spU_jag_Profile Sp = new SPs.spU_jag_Profile();
			if (Sp.Execute(ref Param)) {

				this.col_NomWasUpdated = false;
				this.col_PasswordWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_Profile_Record", "Update");
			}		
		}

		private jag_ProfileSettings_Collection internal_jag_ProfileSettings_Col_ProfileID_Collection = null;
		public jag_ProfileSettings_Collection jag_ProfileSettings_Col_ProfileID_Collection {

			get {

				if (this.internal_jag_ProfileSettings_Col_ProfileID_Collection == null) {

					this.internal_jag_ProfileSettings_Col_ProfileID_Collection = new jag_ProfileSettings_Collection(this.connectionString);
					this.internal_jag_ProfileSettings_Col_ProfileID_Collection.LoadFrom_ProfileID(this.col_ID, this);
				}

				return(this.internal_jag_ProfileSettings_Col_ProfileID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_jag_Profile_Display Param = new Params.spS_jag_Profile_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_jag_Profile_Display Sp = new SPs.spS_jag_Profile_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_jag_Profile_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_jag_Profile_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_Profile_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
