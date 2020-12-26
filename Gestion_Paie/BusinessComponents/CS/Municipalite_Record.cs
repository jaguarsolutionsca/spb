using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Municipalite] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Municipalite_Collection"/> class to do so.
	/// </summary>
	public sealed class Municipalite_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Municipalite_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Municipalite_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Municipalite_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Municipalite_Record(string connectionString, System.Data.SqlTypes.SqlString col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Municipalite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Municipalite", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlString col_ID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ID {
		
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
		
		internal bool col_DescriptionWasSet = false;
		private bool col_DescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Description = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Description {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Description);
			}
			set {
			
				this.col_DescriptionWasUpdated = true;
				this.col_DescriptionWasSet = true;
				this.col_Description = value;
			}
		}

		internal bool col_MrcIDWasSet = false;
		private bool col_MrcIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_MrcID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MrcID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MrcID);
			}
			set {
			
				this.col_MrcIDWasUpdated = true;
				this.col_MrcIDWasSet = true;
				this.col_MrcID_Record = null;
				this.col_MrcID = value;
			}
		}

		
		private MRC_Record col_MrcID_Record = null;
		public MRC_Record Col_MrcID_MRC_Record {
		
			get {

				if (this.col_MrcID_Record == null) {
				
					this.col_MrcID_Record = new MRC_Record(this.connectionString, this.col_MrcID);
				}
				
				return(this.col_MrcID_Record);
			}
		}

		internal bool col_AgenceIDWasSet = false;
		private bool col_AgenceIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_AgenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_AgenceID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_AgenceID);
			}
			set {
			
				this.col_AgenceIDWasUpdated = true;
				this.col_AgenceIDWasSet = true;
				this.col_AgenceID_Record = null;
				this.col_AgenceID = value;
			}
		}

		
		private Agence_Record col_AgenceID_Record = null;
		public Agence_Record Col_AgenceID_Agence_Record {
		
			get {

				if (this.col_AgenceID_Record == null) {
				
					this.col_AgenceID_Record = new Agence_Record(this.connectionString, this.col_AgenceID);
				}
				
				return(this.col_AgenceID_Record);
			}
		}

		internal bool col_ActifWasSet = false;
		private bool col_ActifWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Actif {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Actif);
			}
			set {
			
				this.col_ActifWasUpdated = true;
				this.col_ActifWasSet = true;
				this.col_Actif = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			this.col_MrcIDWasUpdated = false;
			this.col_MrcIDWasSet = false;
			this.col_MrcID = System.Data.SqlTypes.SqlString.Null;

			this.col_AgenceIDWasUpdated = false;
			this.col_AgenceIDWasSet = false;
			this.col_AgenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Municipalite Param = new Params.spS_Municipalite(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Municipalite Sp = new SPs.spS_Municipalite();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_Municipalite.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite.Resultset1.Fields.Column_MrcID.ColumnIndex)) {

						this.col_MrcID = sqlDataReader.GetSqlString(SPs.spS_Municipalite.Resultset1.Fields.Column_MrcID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite.Resultset1.Fields.Column_AgenceID.ColumnIndex)) {

						this.col_AgenceID = sqlDataReader.GetSqlString(SPs.spS_Municipalite.Resultset1.Fields.Column_AgenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Municipalite.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MrcIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AgenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Municipalite Param = new Params.spU_Municipalite(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_MrcIDWasUpdated) {

				Param.Param_MrcID = this.col_MrcID;
				Param.Param_ConsiderNull_MrcID = true;
			}

			if (this.col_AgenceIDWasUpdated) {

				Param.Param_AgenceID = this.col_AgenceID;
				Param.Param_ConsiderNull_AgenceID = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			SPs.spU_Municipalite Sp = new SPs.spU_Municipalite();
			if (Sp.Execute(ref Param)) {

				this.col_DescriptionWasUpdated = false;
				this.col_MrcIDWasUpdated = false;
				this.col_AgenceIDWasUpdated = false;
				this.col_ActifWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Record", "Update");
			}		
		}

		private Municipalite_Secteur_Collection internal_Municipalite_Secteur_Col_MunicipaliteID_Collection = null;
		public Municipalite_Secteur_Collection Municipalite_Secteur_Col_MunicipaliteID_Collection {

			get {

				if (this.internal_Municipalite_Secteur_Col_MunicipaliteID_Collection == null) {

					this.internal_Municipalite_Secteur_Col_MunicipaliteID_Collection = new Municipalite_Secteur_Collection(this.connectionString);
					this.internal_Municipalite_Secteur_Col_MunicipaliteID_Collection.LoadFrom_MunicipaliteID(this.col_ID, this);
				}

				return(this.internal_Municipalite_Secteur_Col_MunicipaliteID_Collection);
			}
		}

		private Municipalite_Zone_Collection internal_Municipalite_Zone_Col_MunicipaliteID_Collection = null;
		public Municipalite_Zone_Collection Municipalite_Zone_Col_MunicipaliteID_Collection {

			get {

				if (this.internal_Municipalite_Zone_Col_MunicipaliteID_Collection == null) {

					this.internal_Municipalite_Zone_Col_MunicipaliteID_Collection = new Municipalite_Zone_Collection(this.connectionString);
					this.internal_Municipalite_Zone_Col_MunicipaliteID_Collection.LoadFrom_MunicipaliteID(this.col_ID, this);
				}

				return(this.internal_Municipalite_Zone_Col_MunicipaliteID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Municipalite_Display Param = new Params.spS_Municipalite_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Municipalite_Display Sp = new SPs.spS_Municipalite_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Municipalite_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
